namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// This is the type for your bank (not including shared bank or other bank features).
    /// https://docs.macroquest.org/reference/data-types/datatype-bank/
    /// </summary>
    [MQ2Type("bank")]
    public class BankType : MQ2DataType
    {
        public BankType(MQ2TypeFactory typeFactory, MQ2TypeVar typeVar) : base(typeFactory, typeVar)
        {
            FreeSlots = new IndexedMember<IntType, int, IntType, string>(this, "FreeSlots");
            TotalSlots = new IndexedMember<IntType, int, IntType, string>(this, "TotalSlots");
        }

        /// <summary>
        /// How many bag slots (base slots for bags/items) your bank has.
        /// </summary>
        public int? BagSlots => GetMember<IntType>("BagSlots");

        /// <summary>
        /// How many free (empty) slots your bank has. This includes slots where you have a bag and the bag has empty slots. 
        /// It accepts an index specifying one of the case insensitive bag sizes (tiny, small, medium, large, giant) or the corresponding number (0, 1, 2, 3, 4). 
        /// An invalid string specifying size will return NULL. Specifying a numeric value less than 0 will use 0 and a value greater than 4 will use 4.
        /// </summary>
        public IndexedMember<IntType, int, IntType, string> FreeSlots { get; }

        /// <summary>
        /// How many total slots your bank has. This includes slots where you have a bag and the bag has items in. 
        /// It accepts an index specifying one of the bag sizes or the corresponding number (see FreeSlots for a longer explanation).
        /// </summary>
        public IndexedMember<IntType, int, IntType, string> TotalSlots { get; }

        /// <summary>
        /// How much platinum you have in your bank.
        /// </summary>
        public int? Platinum => GetMember<IntType>("Platinum");

        /// <summary>
        /// How much gold you have in your bank.
        /// </summary>
        public int? Gold => GetMember<IntType>("Gold");

        /// <summary>
        /// How much silver you have in your bank.
        /// </summary>
        public int? Silver => GetMember<IntType>("Silver");

        /// <summary>
        /// How much copper you have in your bank.
        /// </summary>
        public int? Copper => GetMember<IntType>("Copper");
    }
}
