// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// An alert list is a list of spawn searches
    /// </summary>
    public class AlertType : MQ2DataType
    {
        internal AlertType(MQ2TypeVar typeVar) : base(typeVar)
        {
            List = new IndexedMember<AlertListType, int>(this, "List");
        }

        /// <summary>
        /// Information about a spawn search on the alert list (0 based)
        /// </summary>
        public IndexedMember<AlertListType, int> List { get; }

        /// <summary>
        /// Number of spawn searches on the alert list
        /// </summary>
        public IntType Size => GetMember<IntType>("Size");
    }
}