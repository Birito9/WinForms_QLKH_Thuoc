namespace WebAPI_QLKH.StateManager
{
    public class StateManager
    {
        public static string UserName { get; private set; }
        public static string RoleID { get; private set; }

        public static void SetUserState(string userName, string roleID)
        {
            UserName = userName;
            RoleID = roleID;
        }
        public static void ClearUserState()
        {
            UserName = null;
            RoleID = null;
        }
    }
}
