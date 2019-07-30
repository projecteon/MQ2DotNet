using JetBrains.Annotations;

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// This type is used for both windows and controls on the window
    /// Some members are only applicable to controls e.g. Checked
    /// </summary>
    [PublicAPI]
    [MQ2Type("window")]
    public class WindowType : MQ2DataType
    {
        internal WindowType(MQ2TypeFactory mq2TypeFactory, MQ2TypeVar typeVar) : base(mq2TypeFactory, typeVar)
        {
            List = new ListMember(this);
            Child = new IndexedMember<WindowType>(this, "Child");
        }

        /// <summary>
        /// Memory address of the CSIDLWND struct
        /// </summary>
        public int? Address => GetMember<IntType>("Address");

        /// <summary>
        /// Returns TRUE if the window is open
        /// </summary>
        public bool Open => GetMember<BoolType>("Open");
        
        /// <summary>
        /// A child item by name
        /// </summary>
        public IndexedMember<WindowType> Child { get; }

        /// <summary>
        /// Parent window
        /// </summary>
        public WindowType Parent => GetMember<WindowType>("Parent");

        /// <summary>
        /// First child window/control
        /// </summary>
        public WindowType FirstChild => GetMember<WindowType>("FirstChild");

        /// <summary>
        /// Next sibling window
        /// </summary>
        public WindowType Next => GetMember<WindowType>("Next");

        /// <summary>
        /// Vertical scrollbar range
        /// </summary>
        public int? VScrollMax => GetMember<IntType>("VScrollMax");

        /// <summary>
        /// Vertical scrollbar position
        /// </summary>
        public int? VScrollPos => GetMember<IntType>("VScrollPos");

        /// <summary>
        /// Vertical scrollbar position in % to range from 0 to 100
        /// </summary>
        public int? VScrollPct => GetMember<IntType>("VScrollPct");

        /// <summary>
        /// Horizontal scrollbar range
        /// </summary>
        public int? HScrollMax => GetMember<IntType>("HScrollMax");

        /// <summary>
        /// Horizontal scrollbar position
        /// </summary>
        public int? HScrollPos => GetMember<IntType>("HScrollPos");

        /// <summary>
        /// Horizontal scrollbar position in % to range from 0 to 100
        /// </summary>
        public int? HScrollPct => GetMember<IntType>("HScrollPct");

        /// <summary>
        /// Returns TRUE if the window has children
        /// </summary>
        public bool Children => GetMember<BoolType>("Children");

        /// <summary>
        /// Returns TRUE if the window has siblings
        /// </summary>
        public bool Siblings => GetMember<BoolType>("Siblings");

        /// <summary>
        /// Returns TRUE if the window is minimized
        /// </summary>
        public bool Minimized => GetMember<BoolType>("Minimized");

        /// <summary>
        /// Returns TRUE if the mouse is currently over the window
        /// </summary>
        public bool MouseOver => GetMember<BoolType>("MouseOver");

        /// <summary>
        /// Screen X position
        /// </summary>
        public int? X => GetMember<IntType>("X");

        /// <summary>
        /// Screen Y position
        /// </summary>
        public int? Y => GetMember<IntType>("Y");

        /// <summary>
        /// Width in pixels
        /// </summary>
        public int? Width => GetMember<IntType>("Width");

        /// <summary>
        /// Height in pixels
        /// </summary>
        public int? Height => GetMember<IntType>("Height");

        /// <summary>
        /// Background color
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public ArgbType BGColor => GetMember<ArgbType>("BGColor");

        /// <summary>
        /// Window's text
        /// </summary>
        public string Text => GetMember<StringType>("Text");

        /// <summary>
        /// TooltipReference text
        /// </summary>
        public string Tooltip => GetMember<StringType>("Tooltip");

        /// <summary>
        /// Returns TRUE if the button has been checked
        /// </summary>
        public bool Checked => GetMember<BoolType>("Checked");

        /// <summary>
        /// Returns TRUE if the window is highlighted
        /// </summary>
        public bool Highlighted => GetMember<BoolType>("Highlighted");

        /// <summary>
        /// Returns TRUE if the window is enabled
        /// </summary>
        public bool Enabled => GetMember<BoolType>("Enabled");

        /// <summary>
        /// Window style code
        /// </summary>
        public int? Style => GetMember<IntType>("Style");

        /// <summary>
        /// Name of window piece, e.g. "ChatWindow" for top level windows, or the piece name for child windows. Note: this is Custom UI dependent
        /// </summary>
        public string Name => GetMember<StringType>("Name");

        /// <summary>
        /// ScreenID of window piece. Note: This is not Custom UI dependent, it must be the same on all UIs
        /// </summary>
        public string ScreenID => GetMember<StringType>("ScreenID");

        /// <summary>
        /// Type of window piece (Screen for top level windows, or Listbox, Button, Gauge, Label, Editbox, Slider, etc)
        /// </summary>
        public string Type => GetMember<StringType>("Type");

        /// <summary>
        /// Number of items in a Listbox or Combobox
        /// </summary>
        public int? Items => GetMember<IntType>("Items");

        /// <summary>
        /// Has the other person clicked the Trade button?
        /// </summary>
        public bool HisTradeReady => GetMember<BoolType>("HisTradeReady");

        /// <summary>
        /// Have I clicked the Trade button?
        /// </summary>
        public bool MyTradeReady => GetMember<BoolType>("MyTradeReady");

        /// <summary>
        /// The 1 based index of the currently selected item in a listbox or combobox
        /// </summary>
        public int? GetCurSel => GetMember<IntType>("GetCurSel");

        /// <summary>
        /// Access to list box items
        /// </summary>
        public ListMember List { get; }

        /// <summary>
        /// Sends a left mouse button down notification to the window/control
        /// </summary>
        public void LeftMouseDown() => GetMember<MQ2DataType>("LeftMouseDown");

        /// <summary>
        /// Sends a left mouse button up notification to the window/control
        /// </summary>
        public void LeftMouseUp() => GetMember<MQ2DataType>("LeftMouseUp");

        /// <summary>
        /// Sends a left mouse button held notification to the window/control
        /// </summary>
        public void LeftMouseHeld() => GetMember<MQ2DataType>("LeftMouseHeld");

        /// <summary>
        /// Sends a left mouse button held up notification to the window/control
        /// </summary>
        public void LeftMouseHeldUp() => GetMember<MQ2DataType>("LeftMouseHeldUp");

        /// <summary>
        /// Sends a right mouse button down notification to the window/control
        /// </summary>
        public void RightMouseDown() => GetMember<MQ2DataType>("RightMouseDown");

        /// <summary>
        /// Sends a right mouse button up notification to the window/control
        /// </summary>
        public void RightMouseUp() => GetMember<MQ2DataType>("RightMouseUp");

        /// <summary>
        /// Sends a right mouse button held notification to the window/control
        /// </summary>
        public void RightMouseHeld() => GetMember<MQ2DataType>("RightMouseHeld");

        /// <summary>
        /// Sends a right mouse held up notification to the window/control
        /// </summary>
        public void RightMouseHeldUp() => GetMember<MQ2DataType>("RightMouseHeldUp");

        /// <summary>
        /// Open the window
        /// </summary>
        public void DoOpen() => GetMember<MQ2DataType>("DoOpen");

        /// <summary>
        /// Close the window
        /// </summary>
        public void DoClose() => GetMember<MQ2DataType>("DoClose");

        /// <summary>
        /// Select an item in a listbox or combobox
        /// </summary>
        /// <param name="index">1 based index of the item to select</param>
        public void Select(int index) => GetMember<MQ2DataType>("Select", index.ToString());

        /// <summary>
        /// Provides custom index access for list box items
        /// </summary>
        public class ListMember
        {
            private readonly WindowType _owner;

            internal ListMember(WindowType owner)
            {
                _owner = owner;
            }

            /// <summary>
            /// Text of an item at a given location in the list, row and column are 1 based indexes
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public string this[int row, int column = 0] => _owner.GetMember<StringType>("List", $"{row},{column}");

            /// <summary>
            /// Returns the 1 based index of an item in the list with a specified text
            /// </summary>
            /// <param name="text"></param>
            /// <param name="column">The column (1 based) in which to search</param>
            /// <param name="exactMatch">If true, match exact text only, otherwise partial</param>
            /// <returns></returns>
            public int? this[string text, int column = 0, bool exactMatch = false] => _owner.GetMember<IntType>("List", $"{(exactMatch ? "=" : "")}{text},{column}");
        }
    }
}