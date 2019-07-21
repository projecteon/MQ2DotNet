using System;

namespace MQ2DotNet.MQ2API
{
    /// <summary>
    /// Indicates that the class should be used to represent an MQ2Type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MQ2TypeAttribute : Attribute
    {
        /// <summary>
        /// The name of the MQ2Type represented by the class
        /// </summary>
        public string TypeName { get; }

        /// <summary>
        /// Indicate that the class should be used to represent an MQ2Type of <paramref name="typeName"/>
        /// </summary>
        /// <param name="typeName"></param>
        public MQ2TypeAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }
}