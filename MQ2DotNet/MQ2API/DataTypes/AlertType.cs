namespace MQ2DotNet.MQ2API.DataTypes
{
    // TODO: Check and handle indexed members for AlertType
    public class AlertType : MQ2DataType
    {
        public AlertListType List => GetMember<AlertListType>("List");
        public IntType Size => GetMember<IntType>("Size");
    }
}