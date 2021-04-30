using FB.AdminNamespace;
using FB.UserNamespace;

namespace FB
{
    namespace ValidationUserOrAdmin
    {
        public class Validation
        {
            public static Admin[] Admins { get; set; }
            public static Admin Admin { get; set; }
            public static User[] Users { get; set; }
            public static User User { get; set; }
            public static bool ChechkAdmin(string username, string password)
            {
                foreach (var item in Admins)
                {
                    if ((username == item.Username||username==item.Email) && password == item.Password)
                    {
                        Admin = item;
                        return true;
                    }
                }
                return false;
            }
            public static bool ChechkUser(string username, string password)
            {
                foreach (var item in Users)
                {
                    if (username == item.Email && password == item.Password)
                    {
                        User = item;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
