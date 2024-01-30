using JetBrains.Annotations;
using MQ2DotNet.Services;
using System;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// MQ2 type for the keyring
    /// </summary>
    [PublicAPI]
    [MQ2Type("keyring")]
    public class KeyRingType : MQ2DataType
    {
        internal KeyRingType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
        }

        /// <summary>
        /// Index of the item in the list (1 based)
        /// </summary>
        public int? Count => GetMember<IntType>("Count");

        /// <summary>
        /// Name of the item
        /// </summary>
        public KeyRingItemType Stat => GetMember<KeyRingItemType>("Stat");

        /// <summary>
        /// Get the TLO using an index of type <typeparamref name="TIndex1"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public KeyRingItemType this[int index] => GetTLO<KeyRingItemType>("keyringitem", index.ToString());

        /// <summary>
        /// Get the TLO using an index of type <typeparamref name="TIndex1"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public KeyRingItemType this[string index] => GetTLO<KeyRingItemType>("keyringitem", index.ToString());

        private T GetTLO<T>(string name, string index = "") where T : MQ2DataType
        {
            // To get an MQ2TypeVar from a TLO, first we call FindMQ2Data to get a function pointer to the TLO's function
            var tlo = TLO.FindMQ2Data(name);// ?? throw new KeyNotFoundException();

            // Then we call that function, providing the index as a parameter
            if (tlo.pFunction == IntPtr.Zero || !tlo.Function(index, out var typeVar) || typeVar.Type == IntPtr.Zero)
                return null;

            return (T)_typeFactory.Create(typeVar);
        }
    }
}