using System;
using System.Web.Script.Serialization;
using WPF_HW1.Model;

namespace WPF_HW1.Utils
{
    public class UserManager
    {
        
        public static Guid GetCurrentUserID(){
            return Guid.Parse(ReadWriteManager.ReadFromFile(Constants.ClientDataDirPath, "Data", ".txt"));
        }

        public static void SaveCurrentUserID(Guid guid){
            ReadWriteManager.WriteToFile(Constants.ClientDataDirPath, "Data", ".txt", guid.ToString());
        }

        public static User GetCurrentUser()
        {
            return EntityWrapper.GetUserByGuid(GetCurrentUserID());
        }
    }
}
