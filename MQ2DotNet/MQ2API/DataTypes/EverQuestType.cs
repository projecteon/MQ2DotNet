namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for EverQuestType
    public class EverQuestType : MQ2DataType
    {
        public StringType GameState => GetMember<StringType>("GameState");
        public StringType LoginName => GetMember<StringType>("LoginName");
        public StringType Server => GetMember<StringType>("Server");
        public StringType LastCommand => GetMember<StringType>("LastCommand");
        public StringType LastTell => GetMember<StringType>("LastTell");
        public IntType Running => GetMember<IntType>("Running");
        public IntType MouseX => GetMember<IntType>("MouseX");
        public IntType MouseY => GetMember<IntType>("MouseY");
        public IntType Ping => GetMember<IntType>("Ping");
        public IntType ChatChannels => GetMember<IntType>("ChatChannels");
        public StringType ChatChannelByNumber => GetMember<StringType>("ChatChannelByNumber");
        public BoolType ChatChannelByName => GetMember<BoolType>("ChatChannelByName");
        public IntType ViewportX => GetMember<IntType>("ViewportX");
        public IntType ViewportY => GetMember<IntType>("ViewportY");
        public IntType ViewportXMax => GetMember<IntType>("ViewportXMax");
        public IntType ViewportYMax => GetMember<IntType>("ViewportYMax");
        public IntType ViewportXCenter => GetMember<IntType>("ViewportXCenter");
        public IntType ViewportYCenter => GetMember<IntType>("ViewportYCenter");
        public BoolType LClickedObject => GetMember<BoolType>("LClickedObject");
        public StringType WinTitle => GetMember<StringType>("WinTitle");
        public IntType PID => GetMember<IntType>("PID");
        public IntType xScreenMode => GetMember<IntType>("xScreenMode");
        public StringType PPriority => GetMember<StringType>("PPriority");
        public BoolType LayoutCopyInProgress => GetMember<BoolType>("LayoutCopyInProgress");
        public WindowType LastMouseOver => GetMember<WindowType>("LastMouseOver");
        public CharSelectListType CharSelectList => GetMember<CharSelectListType>("CharSelectList");
        public StringType CurrentUI => GetMember<StringType>("CurrentUI");
        public BoolType IsDefaultUILoaded => GetMember<BoolType>("IsDefaultUILoaded");
    }
}