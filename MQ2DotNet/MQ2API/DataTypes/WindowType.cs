namespace MQ2DotNet.MQ2API.DataTypes
{
    public class WindowType : MQ2DataType
    {
        public WindowType()
        {
            List = new ListMember(this);
            Child = new IndexedMember<WindowType>(this, "Child");
        }

        public IntType Address => GetMember<IntType>("Address");
        public BoolType Open => GetMember<BoolType>("Open");
        public IndexedMember<WindowType> Child { get; }
        public WindowType Parent => GetMember<WindowType>("Parent");
        public WindowType FirstChild => GetMember<WindowType>("FirstChild");
        public WindowType Next => GetMember<WindowType>("Next");
        public IntType VScrollMax => GetMember<IntType>("VScrollMax");
        public IntType VScrollPos => GetMember<IntType>("VScrollPos");
        public IntType VScrollPct => GetMember<IntType>("VScrollPct");
        public IntType HScrollMax => GetMember<IntType>("HScrollMax");
        public IntType HScrollPos => GetMember<IntType>("HScrollPos");
        public IntType HScrollPct => GetMember<IntType>("HScrollPct");
        public BoolType Children => GetMember<BoolType>("Children");
        public BoolType Siblings => GetMember<BoolType>("Siblings");
        public BoolType Minimized => GetMember<BoolType>("Minimized");
        public BoolType MouseOver => GetMember<BoolType>("MouseOver");
        public IntType X => GetMember<IntType>("X");
        public IntType Y => GetMember<IntType>("Y");
        public IntType Width => GetMember<IntType>("Width");
        public IntType Height => GetMember<IntType>("Height");
        public ArgbType BGColor => GetMember<ArgbType>("BGColor");
        public StringType Text => GetMember<StringType>("Text");
        public StringType Tooltip => GetMember<StringType>("Tooltip");
        public BoolType Checked => GetMember<BoolType>("Checked");
        public BoolType Highlighted => GetMember<BoolType>("Highlighted");
        public BoolType Enabled => GetMember<BoolType>("Enabled");
        public IntType Style => GetMember<IntType>("Style");
        public StringType Name => GetMember<StringType>("Name");
        public StringType ScreenID => GetMember<StringType>("ScreenID");
        public StringType Type => GetMember<StringType>("Type");
        public IntType Items => GetMember<IntType>("Items");
        public BoolType HisTradeReady => GetMember<BoolType>("HisTradeReady");
        public BoolType MyTradeReady => GetMember<BoolType>("MyTradeReady");
        public IntType GetCurSel => GetMember<IntType>("GetCurSel");
        public ListMember List { get; }

        public class ListMember
        {
            private readonly WindowType _owner;

            public ListMember(WindowType owner)
            {
                _owner = owner;
            }

            public StringType this[int row, int column = 0] => _owner.GetMember<StringType>("List", $"{row},{column}");
            public IntType this[string text, int column = 0, bool exactMatch = false] => _owner.GetMember<IntType>("List", $"{(exactMatch ? "=" : "")}{text},{column}");
        }
    }
}