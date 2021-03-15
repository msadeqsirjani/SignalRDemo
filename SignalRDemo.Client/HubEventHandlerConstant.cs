namespace SignalRDemo.Client
{
    public static class HubEventHandlerConstant
    {
        public static string WatchHubServerWatch = "Watch";
        public static string WatchHubClientUpdate = "Update";

        public static string AccountHubServerJoinUser = "JoinUser";
        public static string AccountHubClientIntroduce = "Introduce";

        public static string ColorHubServerJoinGroup = "JoinUser";
        public static string ColorHubServerRemoveGroup = "RemoveGroup";
        public static string ColorHubServerTriggerGroup = "TriggerGroup";


        public static string ColorHubClientTriggerColor = "TriggerColor";
    }
}
