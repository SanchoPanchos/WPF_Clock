using System;
using System.Collections.Generic;
using System.Linq;

namespace WPF_HW1.Model
{
    class EntityWrapper
    {
        /// <summary>
        /// Отримати користувача по логіну та паролю
        /// </summary>
        /// <param name="username">логін</param>
        /// <param name="password">пароль</param>
        /// <returns>Користувач з заданими логіном та паролем</returns>
        public static User GetUserByLoginAndPassword(string username, string password)
        {
            using (var context = new MyContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }

        /// <summary>
        /// Отримати користувача по унікальному ідентифікатору
        /// </summary>
        /// <param name="guid">унікальний ідентифікатор</param>
        /// <returns>Коритсувач з заданим ідентифікатором</returns>
        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new MyContext())
            {
                User a = context.Users.FirstOrDefault(u => u.Guid == guid);
                return a;
            }
        }

        /// <summary>
        /// Отримати список з годинниками заданого користувача
        /// </summary>
        /// <param name="userId">унікальний ідентифікатор користувача</param>
        /// <returns>Список з годинниками заданого користувача</returns>
        public static List<TimeClock> GetTimeClocksByUserId(Guid userId)
        {
            using (var context = new MyContext())
            {
                return context.TimeClocks.AsNoTracking().Where(r => r.UserID == userId).ToList();
            }
        }

        /// <summary>
        /// Додати користувача
        /// </summary>
        /// <param name="user">користувач</param>
        public static void AddUser(User user)
        {
            using (var context = new MyContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Додати годинник
        /// </summary>
        /// <param name="timeClock">годинник</param>
        public static void AddTimeClock(TimeClock timeClock)
        {
            using (var context = new MyContext())
            {
                context.Users.Attach(timeClock.User);
                context.TimeClocks.Add(timeClock);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Видалити годинник
        /// </summary>
        /// <param name="guid">унікальний ідентифікатор годинника</param>
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

