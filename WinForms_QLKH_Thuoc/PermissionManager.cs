using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormQLKH
{
    public class PermissionManager
    {
        public static bool CanAdd(string roleID)
        {
            return roleID == "Role1" || roleID == "Role2";
        }
        public static bool CanUpdate(string roleID)
        {
            return roleID == "Role1";
        }
        public static bool CanDelete(string roleID)
        {
            return roleID == "Role1";
        }
        public static bool CanSearch(string roleID)
        {
            return roleID == "Role1" || roleID == "Role2";
        }
    }
}
