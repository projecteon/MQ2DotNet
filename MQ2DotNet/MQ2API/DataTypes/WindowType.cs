// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    /// <summary>
    /// This type is used for both windows and controls on the window
    /// Some members are only applicable to controls e.g. Checked
    /// </summary>
    public class WindowType : MQ2DataType
    {
        public WindowType()
        {
            List = new ListMember(this);
            Child = new IndexedMember<WindowType>(this, "Child");
        }

        /// <summary>
        /// Memory address of the CSIDLWND struct
        /// </summary>
        public IntType Address => GetMember<IntType>("Address");

        /// <summary>
        /// Returns TRUE if the window is open
        /// </summary>
        public BoolType Open => GetMember<BoolType>("Open");
        
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
        public IntType VScrollMax => GetMember<IntType>("VScrollMax");

        /// <summary>
        /// Vertical scrollbar position
        /// </summary>
        public IntType VScrollPos => GetMember<IntType>("VScrollPos");

        /// <summary>
        /// Vertical scrollbar position in % to range from 0 to 100
        /// </summary>
        public IntType VScrollPct => GetMember<IntType>("VScrollPct");

        /// <summary>
        /// Horizontal scrollbar range
        /// </summary>
        public IntType HScrollMax => GetMember<IntType>("HScrollMax");

        /// <summary>
        /// Horizontal scrollbar position
        /// </summary>
        public IntType HScrollPos => GetMember<IntType>("HScrollPos");

        /// <summary>
        /// Horizontal scrollbar position in % to range from 0 to 100
        /// </summary>
        public IntType HScrollPct => GetMember<IntType>("HScrollPct");

        /// <summary>
        /// Returns TRUE if the window has children
        /// </summary>
        public BoolType Children => GetMember<BoolType>("Children");

        /// <summary>
        /// Returns TRUE if the window has siblings
        /// </summary>
        public BoolType Siblings => GetMember<BoolType>("Siblings");

        /// <summary>
        /// Returns TRUE if the window is minimized
        /// </summary>
        public BoolType Minimized => GetMember<BoolType>("Minimized");

        /// <summary>
        /// Returns TRUE if the mouse is currently over the window
        /// </summary>
        public BoolType MouseOver => GetMember<BoolType>("MouseOver");

        /// <summary>
        /// Screen X position
        /// </summary>
        public IntType X => GetMember<IntType>("X");

        /// <summary>
        /// Screen Y position
        /// </summary>
        public IntType Y => GetMember<IntType>("Y");

        /// <summary>
        /// Width in pixels
        /// </summary>
        public IntType Width => GetMember<IntType>("Width");

        /// <summary>
        /// Height in pixels
        /// </summary>
        public IntType Height => GetMember<IntType>("Height");

        /// <summary>
        /// Background color
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public ArgbType BGColor => GetMember<ArgbType>("BGColor");

        /// <summary>
        /// Window's text
        /// </summary>
        public StringType Text => GetMember<StringType>("Text");

        /// <summary>
        /// TooltipReference text
        /// </summary>
        public StringType Tooltip => GetMember<StringType>("Tooltip");

        /// <summary>
        /// Returns TRUE if the button has been checked
        /// </summary>
        public BoolType Checked => GetMember<BoolType>("Checked");

        /// <summary>
        /// Returns TRUE if the window is highlighted
        /// </summary>
        public BoolType Highlighted => GetMember<BoolType>("Highlighted");

        /// <summary>
        /// Returns TRUE if the window is enabled
        /// </summary>
        public BoolType Enabled => GetMember<BoolType>("Enabled");

        /// <summary>
        /// Window style code
        /// </summary>
        public IntType Style => GetMember<IntType>("Style");

        /// <summary>
        /// Name of window piece, e.g. "ChatWindow" for top level windows, or the piece name for child windows. Note: this is Custom UI dependent
        /// </summary>
        public StringType Name => GetMember<StringType>("Name");

        /// <summary>
        /// ScreenID of window piece. Note: This is not Custom UI dependent, it must be the same on all UIs
        /// </summary>
        public StringType ScreenID => GetMember<StringType>("ScreenID");

        /// <summary>
        /// Type of window piece (Screen for top level windows, or Listbox, Button, Gauge, Label, Editbox, Slider, etc)
        /// </summary>
        public StringType Type => GetMember<StringType>("Type");

        /// <summary>
        /// Number of items in a Listbox or Combobox
        /// </summary>
        public IntType Items => GetMember<IntType>("Items");

        /// <summary>
        /// Has the other person clicked the Trade button?
        /// </summary>
        public BoolType HisTradeReady => GetMember<BoolType>("HisTradeReady");

        /// <summary>
        /// Have I clicked the Trade button?
        /// </summary>
        public BoolType MyTradeReady => GetMember<BoolType>("MyTradeReady");

        /// <summary>
        /// The 1 based index of the currently selected item in a listbox or combobox
        /// </summary>
        public IntType GetCurSel => GetMember<IntType>("GetCurSel");

        /// <summary>
        /// Access to list box items
        /// </summary>
        public ListMember List { get; }

        public class ListMember
        {
            private readonly WindowType _owner;

            public ListMember(WindowType owner)
            {
                _owner = owner;
            }

            /// <summary>
            /// Text of an item at a given location in the list, row and column are 1 based indexes
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public StringType this[int row, int column = 0] => _owner.GetMember<StringType>("List", $"{row},{column}");

            /// <summary>
            /// Returns the 1 based index of an item in the list with a specified text
            /// </summary>
            /// <param name="text"></param>
            /// <param name="column">The column (1 based) in which to search</param>
            /// <param name="exactMatch">If true, match exact text only, otherwise partial</param>
            /// <returns></returns>
            public IntType this[string text, int column = 0, bool exactMatch = false] => _owner.GetMember<IntType>("List", $"{(exactMatch ? "=" : "")}{text},{column}");
        }
    }
}