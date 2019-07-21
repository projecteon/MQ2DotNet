using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using MQ2DotNet.MQ2API.DataTypes;

namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Creates a wrapper class from an MQ2TypeVar
    /// </summary>
    public static class MQ2TypeFactory
    {
        private static readonly Dictionary<IntPtr, Func<MQ2TypeVar, MQ2DataType>> _constructors = new Dictionary<IntPtr, Func<MQ2TypeVar, MQ2DataType>>();
        private static readonly List<Assembly> _registeredAssemblies = new List<Assembly>();
        private static readonly object _lock = new object();

        static MQ2TypeFactory()
        {
            // Register types in any already loaded assemblies, and add an event handler for future loaded ones
            AppDomain.CurrentDomain.AssemblyLoad += (s, e) => RegisterTypesInAssembly(e.LoadedAssembly);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                RegisterTypesInAssembly(assembly);
        }

        private static void RegisterTypesInAssembly(Assembly assembly)
        {
            // Ensure assemblies are only processed once
            // Hoping that this combined with registering the event prior to all existing types is enough to ensure exactly once processing of each...
            lock (_lock)
            {
                if (_registeredAssemblies.Contains(assembly))
                    return;
                _registeredAssemblies.Add(assembly);
            }

            // Can ignore any assemblies that don't reference this one
            var thisAssembly = Assembly.GetExecutingAssembly();
            if (assembly != thisAssembly && !assembly.GetReferencedAssemblies().Contains(thisAssembly.GetName()))
                return;

            // Find all subclasses of MQ2DataType, and get their MQ2Type attribute
            foreach (var type in assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(MQ2DataType))))
            {
                var mq2Type = type.GetCustomAttribute<MQ2TypeAttribute>();
                // Not sure why you'd want it without the attribute but I'll allow it
                if (mq2Type == null)
                    continue;

                // It needs a public constructor with a single MQ2TypeVar as a parameter
                var ctor = type.GetConstructor(new[] {typeof(MQ2TypeVar)});

                // If the type is defined in this assembly, allow an internal constructor too
                if (ctor == null && assembly == Assembly.GetExecutingAssembly())
                    ctor = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(c =>
                    {
                        var parameters = c.GetParameters();
                        return c.IsAssembly && parameters.Length == 1 && parameters[0].ParameterType == typeof(MQ2TypeVar);
                    });

                if (ctor == null)
                    throw new MissingMethodException($"{type.Name} is marked as an MQ2Type, but does not have a constructor taking an MQ2TypeVar");
                
                // Create a lambda that creates an instance of this type
                // Ivan says it's fast: https://ru.stackoverflow.com/questions/860901/%D0%A1%D1%83%D1%89%D0%B5%D1%81%D1%82%D0%B2%D1%83%D0%B5%D1%82-%D0%BB%D0%B8-%D0%B2%D0%BE%D0%B7%D0%BC%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D1%8C-%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%B2%D0%B0%D1%82%D1%8C-%D0%BE%D0%B1%D1%8A%D0%B5%D0%BA%D1%82-%D0%BE%D0%BF%D1%80%D0%B5%D0%B4%D0%B5%D0%BB%D0%B5%D0%BD%D0%BD%D0%BE%D0%B3%D0%BE-%D1%82%D0%B8%D0%BF%D0%B0-%D0%B1%D0%B5%D0%B7-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F/860921#860921
                var parameter = Expression.Parameter(typeof(MQ2TypeVar));
                var constructor = Expression.Lambda<Func<MQ2TypeVar, MQ2DataType>>(Expression.New(ctor, parameter), parameter).Compile();
                Register(mq2Type.TypeName, constructor);
            }
        }

        /// <summary>
        /// Create the appropriate wrapper type given an MQ2TypeVar
        /// </summary>
        /// <param name="typeVar"></param>
        /// <returns></returns>
        internal static MQ2DataType Create(MQ2TypeVar typeVar)
        {
            // If we have a special constructor registered, use it, otherwise create an MQ2DataType by default
            var dataType = _constructors.ContainsKey(typeVar.pType)
                ? _constructors[typeVar.pType](typeVar)
                : new MQ2DataType(typeVar);

            return dataType;
        }

        [DllImport("MQ2Main.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr FindMQ2DataType(string name);

        /// <summary>
        /// Register a type
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="constructor"></param>
        private static void Register(string typeName, Func<MQ2TypeVar, MQ2DataType> constructor)
        {
            var dataType = FindMQ2DataType(typeName);

            if (dataType == IntPtr.Zero)
                throw new KeyNotFoundException($"Could not find data type: {typeName}");

            if (_constructors.ContainsKey(dataType))
                throw new InvalidOperationException($"An MQ2DataType for {typeName} has already been registered");

            _constructors[dataType] = constructor;
        }
    }
}