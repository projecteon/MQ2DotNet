namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// This is the type for all things inventory related.
    /// https://docs.macroquest.org/reference/data-types/datatype-inventory/
    /// </summary>
    [MQ2Type("inventory")]
    public class InventoryType : MQ2DataType
    {
        public InventoryType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
        }

        /// <summary>
        /// Your bank, only including the primary slots and currencies (not including shared or other features)
        /// </summary>
        public BankType Bank => GetMember<BankType>("Bank");
    }
}
