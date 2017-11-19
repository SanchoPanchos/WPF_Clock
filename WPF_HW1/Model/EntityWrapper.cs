using System;
using System.Collections.Generic;
using System.Linq;

namespace WPF_HW1.Model
{
    class EntityWrapper
    {
        
        public static User GetUserByLoginAndPassword(string username, string password)
        {
            using (var context = new MyContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new MyContext())
            {
                User a = context.Users.FirstOrDefault(u => u.Guid == guid);
                return a;
            }
        }

        
        public static List<TimeClock> GetTimeClocksByUserId(Guid userId)
        {
            using (var context = new MyContext())
            {
                return context.TimeClocks.AsNoTracking().Where(r => r.UserID == userId).ToList();
            }
        }

        
        public static void AddUser(User user)
        {
            using (var context = new MyContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        
        public static void AddTimeClock(TimeClock timeClock)
        {
            using (var context = new MyContext())
            {
                context.Users.Attach(timeClock.User);
                context.TimeClocks.Add(timeClock);
                context.SaveChanges();
            }
        }

        public static void DeleteTimeClock(Guid guid)
        {
            using (var context = new MyContext())
            {
                TimeClock temp = new TimeClock() { Guid = guid };
                context.TimeClocks.Attach(temp);
                context.TimeClocks.Remove(temp);
                context.SaveChanges();
            }
        }
    }
}

