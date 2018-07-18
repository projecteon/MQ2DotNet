using System;
// ReSharper disable UnusedMember.Global

namespace MQ2DotNet.MQ2API.DataTypes
{
    public class EverQuestType : MQ2DataType
    {
        internal EverQuestType(MQ2TypeVar typeVar) : base(typeVar)
        {
            CharSelectList = new IndexedMember<CharSelectListType, string, CharSelectListType, int>(this, "CharSelectList");
            ChatChannel = new IndexedStringMember<int, BoolType, string>(this, "ChatChannel");
        }

        /// <summary>
        /// Current game state, one of "PRECHARSELECT", "CHARSELECT", "INGAME", "UNKNOWN"
        /// </summary>
        public string GameState => GetMember<StringType>("GameState");

        /// <summary>
        /// Username of your account name
        /// </summary>
        public string LoginName => GetMember<StringType>("LoginName");

        /// <summary>
        /// Name of the server in short form e.g. firiona
        /// </summary>
        public string Server => GetMember<StringType>("Server");

        /// <summary>
        /// Last command executed
        /// </summary>
        public string LastCommand => GetMember<StringType>("LastCommand");

        /// <summary>
        /// Name of the person you last received a tell from
        /// </summary>
        public string LastTell => GetMember<StringType>("LastTell");

        /// <summary>
        /// Number of clock ticks this instance of eqgame.exe has been running for
        /// </summary>
        public IntType Running => GetMember<IntType>("Running");

        /// <summary>
        /// X (horizontal) coordinate of the mouse cursor in UI coordinate space, relative to the left edge of the game window
        /// </summary>
        public IntType MouseX => GetMember<IntType>("MouseX");

        /// <summary>
        /// Y (vertical) coordinate of the mouse cursor in UI coordinate space relative to the top edge of the game window
        /// </summary>
        public IntType MouseY => GetMember<IntType>("MouseY");

        /// <summary>
        /// Ping time to the EQ server in milliseconds
        /// </summary>
        public IntType Ping => GetMember<IntType>("Ping");

        /// <summary>
        /// Number of chat channels you are in
        /// </summary>
        public IntType ChatChannels => GetMember<IntType>("ChatChannels");

        /// <summary>
        /// Name of a chat channel by number, or true/false if you are in a chat channel by name
        /// </summary>
        public IndexedStringMember<int, BoolType, string> ChatChannel { get; }

        /// <summary>
        /// X (horizontal) start of viewport, always 0?
        /// </summary>
        public IntType ViewportX => GetMember<IntType>("ViewportX");

        /// <summary>
        /// Y (vertical) start of viewport, always 0?
        /// </summary>
        public IntType ViewportY => GetMember<IntType>("ViewportY");

        /// <summary>
        /// X (horizontal) end of viewport
        /// </summary>
        public IntType ViewportXMax => GetMember<IntType>("ViewportXMax");

        /// <summary>
        /// Y (vertical) end of viewport
        /// </summary>
        public IntType ViewportYMax => GetMember<IntType>("ViewportYMax");

        /// <summary>
        /// X (horizontal) center of viewport
        /// </summary>
        public IntType ViewportXCenter => GetMember<IntType>("ViewportXCenter");

        /// <summary>
        /// Y (vertical) center of viewport
        /// </summary>
        public IntType ViewportYCenter => GetMember<IntType>("ViewportYCenter");

        /// <summary>
        /// TODO: Document EverQuestType.LClickedObject
        /// </summary>
        public BoolType LClickedObject => GetMember<BoolType>("LClickedObject");

        /// <summary>
        /// Current window title
        /// </summary>
        public string WinTitle => GetMember<StringType>("WinTitle");
        
        /// <summary>
        /// Process ID of this eqgame.exe
        /// </summary>
        public IntType PID => GetMember<IntType>("PID");
        
        /// <summary>
        /// Screen mode, 2 = windowed ?
        /// </summary>
        public IntType ScreenMode => GetMember<IntType>("ScreenMode");

        /// <summary>
        /// Process priority of this eqgame.exe, one of "LOW", "BELOW NORMAL", "NORMAL", "ABOVE NORMAL", "REALTIME"
        /// </summary>
        public string PPriority => GetMember<StringType>("PPriority");

        /// <summary>
        /// Is a /copylayout currently in progress?
        /// </summary>
        public BoolType LayoutCopyInProgress => GetMember<BoolType>("LayoutCopyInProgress");

        /// <summary>
        /// Window the mouse cursor was last over
        /// </summary>
        public WindowType LastMouseOver => GetMember<WindowType>("LastMouseOver");

        /// <summary>
        /// Character in the character select list by name or position (1 based)
        /// </summary>
        public IndexedMember<CharSelectListType, string, CharSelectListType, int> CharSelectList { get; }

        /// <summary>
        /// Name of the current UI skin
        /// </summary>
        public string CurrentUI => GetMember<StringType>("CurrentUI");

        /// <summary>
        /// True if using default UI skin
        /// </summary>
        public BoolType IsDefaultUILoaded => GetMember<BoolType>("IsDefaultUILoaded");
    }
}