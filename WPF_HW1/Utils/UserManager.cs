using System;
using System.Web.Script.Serialization;
using WPF_HW1.Model;

namespace WPF_HW1.Utils
{
    public class UserManager
    {
        public static User GetCurrentUser(){
            return new JavaScriptSerializer().Deserialize<User>(ReadWriteManager.ReadFromFile(Constants.ClientDataDirPath, "Data", ".txt"));
        }

        public static void SaveCurrentUser(User user){
            string json = new JavaScriptSerializer().Serialize(user);
            ReadWriteManager.WriteToFile(Constants.ClientDataDirPath, "Data", ".txt", json);
        }
    }
}
