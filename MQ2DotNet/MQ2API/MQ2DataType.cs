using System;
using System.Collections.Generic;
using MQ2DotNet.MQ2API.DataTypes;

/* To create the member properties, grab everything in the switch statement from the cpp MQ2xxxType::GetMember function
 * Then in notepad++, find all:
 *      (case (\w+):|Dest\.Type)
 * Select all and copy, then find/replace:
 *      case (\w+):\s+Dest.Type = p(\w+);
 *      public \2 \1 => GetMember<\2>\("\1"\);
 * Note this doesn't handle index members
 */
namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Base class from which all wrapped MQ2 data types derive
    /// </summary>
    public class MQ2DataType
    {
        private MQ2TypeVar _typeVar;

        internal MQ2DataType()
        {
        }

        public MQ2DataType(MQ2TypeVar typeVar)
        {
            _typeVar = typeVar;
        }

        internal MQ2DataType(string typeName, MQ2VarPtr varPtr)
        {
            _typeVar.pType = MQ2TypeFactory.FindMQ2DataType(typeName);
            if (_typeVar.pType == IntPtr.Zero)
                throw new KeyNotFoundException($"MQ2Type not found: {typeName}");

            _typeVar.VarPtr = varPtr;
        }

        #region Helpers for derived classes
        protected T GetMember<T>(string name, string index = "") where T : MQ2DataType
        {
            return _typeVar.GetMember<T>(name, index);
        }

        public class IndexedMember<T, TIndex> where T : MQ2DataType
        {
            private readonly MQ2DataType _owner;
            private readonly string _name;

            public IndexedMember(MQ2DataType owner, string name)
            {
                _owner = owner;
                _name = name;
            }

            public T this[TIndex index] => _owner.GetMember<T>(_name, index.ToString());
        }

        public class IndexedMember<T1, TIndex1, T2, TIndex2> where T1 : MQ2DataType where T2 : MQ2DataType
        {
            private readonly MQ2DataType _owner;
            private readonly string _name;

            public IndexedMember(MQ2DataType owner, string name)
            {
                _owner = owner;
                _name = name;
            }

            public T1 this[TIndex1 index] => _owner.GetMember<T1>(_name, index.ToString());
            public T2 this[TIndex2 index] => _owner.GetMember<T2>(_name, index.ToString());
        }

        // This class is "needed" because IndexedMember<string, int> isn't valid because of the where TIndex : MQ2Type constraint
        public class IndexedStringMember<TIndex>
        {
            private readonly MQ2DataType _owner;
            private readonly string _name;

            public IndexedStringMember(MQ2DataType owner, string name)
            {
                _owner = owner;
                _name = name;
            }

            public string this[TIndex index] => _owner.GetMember<StringType>(_name, index.ToString());
        }

        // See above, horrible but it works
        public class IndexedStringMember<TIndex, T2, TIndex2> where T2 : MQ2DataType
        {
            private readonly MQ2DataType _owner;
            private readonly string _name;

            public IndexedStringMember(MQ2DataType owner, string name)
            {
                _owner = owner;
                _name = name;
            }

            public string this[TIndex index] => _owner.GetMember<StringType>(_name, index.ToString());
            public T2 this[TIndex2 index] => _owner.GetMember<T2>(_name, index.ToString());
        }

        public class IndexedMember<T> : IndexedMember<T, string> where T : MQ2DataType
        {
            public IndexedMember(MQ2DataType owner, string name) : base(owner, name)
            {
            }
        }
        #endregion

        public override string ToString()
        {
            return _typeVar.ToString();
        }

        // Exposed for use in basic types e.g. int, double, etc
        internal MQ2VarPtr VarPtr => _typeVar.VarPtr;
    }
}