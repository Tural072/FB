using FB.AdminNamespace;
using FB.UserNamespace;
using FB.NotificationNamespace;
using FB.ValidationUserOrAdmin;
using System;


namespace FB
{
    class Program
    {
        public static object Posts { get; private set; }

        static void Main(string[] args)
        {
            Admin admin = new Admin
            {
                Id = 1,
                Email = "tural.spotify.com@gmail.com",
                Password = "1",
                Username = "1"
            };
            User user = new User
            {
                Id = 1,
                Name = "Tural",
                Surename = "Tahirli",
                Age = 29,
                Email = "1",
                Password = "1"
            };
            Admin[] admins = new Admin[1] { admin };
            Validation.Admins = admins;
            User[] users = new User[1] { user };
            Validation.Users = users;
            int choose = 0;
            int choose1 = 0;
            int choose2 = 0;
            string username = null;
            string password = null;
            void AdminOrUser()
            {
                Console.WriteLine("1)Admin");
                Console.WriteLine("2)User");
                Console.WriteLine("3)Exit");
                Console.WriteLine("Enter your choiche : ");
                choose = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            void ShearchPostMenu()
            {
                Console.WriteLine("Enter posts ID : ");
                choose1 = int.Parse(Console.ReadLine());
                foreach (var item in admins)
                {
                    item.SearchPostWithIdAndLike(choose1);
                    Notification notification = new Notification
                    {
                        DateTime = DateTime.Now,
                        FromUser = Validation.User.Name,
                        Id = Validation.User.Id,
                        Text = $"User {Validation.User.Name} saw Post"
                    };
                    Validation.Admin.AddNotification(notification);
                    SendMail.SendEmail("Viewed post", $"{Validation.User.Name} viewed your post");
                }
            }
            void ChechkUserChoose()
            {
                if (choose == 1)
                {
                    foreach (var item in admins)
                    {
                        if (item.PostCount != 0)
                        {
                            Console.WriteLine($"From admin {item.Username} have {item.PostCount} post");
                            ShearchPostMenu();
                            if (choose == 1)
                            {
                                ChooseUser();
                                ChechkUserChoose();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"From admin {item.Username} not post yet");
                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                            Console.ResetColor();
                            ChooseUser();
                            ChechkUserChoose();
                        }
                    }
                }
                else if (choose == 2)
                {
                    AdminOrUser();
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }
            }
            void EnterUsernamePassword()
            {
                Console.WriteLine("Enter username or email  : ");
                username = Console.ReadLine();
                Console.WriteLine("Enter password : ");
                password = Console.ReadLine();
            }
            void ChechkUserMenu()
            {
                if (Validation.ChechkUser(username, password))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Sign in Succesfly");
                    System.Threading.Thread.Sleep(1500);
                    Console.ResetColor();
                    Console.Clear();
                    ChooseUser();
                    ChechkUserChoose();
                }
                else
                {
                    WrongUsernameOrPassword();
                }
            }
            void ChooseAdmin()
            {
                Console.Clear();
                Console.WriteLine("1)Type status");
                Console.WriteLine("2)Notifications");
                Console.WriteLine("3)Back");
                choose = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            void ChooseUser()
            {
                Console.Clear();
                Console.WriteLine("1)Search post with ID");
                Console.WriteLine("2)Back");
                Console.WriteLine("Enter your choiche : ");
                choose = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            void SignAndChoose()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sign in Succesfly");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                Console.ResetColor();
                ChooseAdmin();
            }
            void CheckAdminSelection()
            {
                if (choose == 1)
                {
                    Validation.Admin.AddPost();
                    foreach (var item in admins)
                    {
                        item.Show();
                    }
                    Console.WriteLine("1)Back");
                    choose2 = int.Parse(Console.ReadLine());
                    if (choose == 1)
                    {
                        ChooseAdmin();
                        CheckAdminSelection();
                    }
                }
                else if (choose == 2)
                {
                    Validation.Admin.ShowNotification();
                }
                else if (choose == 3)
                {
                    AdminOrUser();
                    MainMenu();
                }
            }
            void WrongUsernameOrPassword()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Wrong password or username backing to main menu...");
                System.Threading.Thread.Sleep(2000);
                Console.ResetColor();
                Console.Clear();
                AdminOrUser();
                MainMenu();
            }
            void ChechkAdminMenu()
            {
                if (Validation.ChechkAdmin(username, password))
                {
                    SignAndChoose();
                    CheckAdminSelection();
                }
                else
                {
                    WrongUsernameOrPassword();
                }
            }
            void MainMenu()
            {
                if (choose == 1)
                {
                    EnterUsernamePassword();
                    ChechkAdminMenu();
                }
                else if (choose == 2)
                {
                    EnterUsernamePassword();
                    ChechkUserMenu();
                }
                else if (choose == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong choice");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    Console.ResetColor();
                    AdminOrUser();
                    MainMenu();
                }
            }
            AdminOrUser();
            MainMenu();
        }
    }
}
