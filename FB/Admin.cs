using FB.NotificationNamespace;
using FB.PostNamespace;
using FB.ValidationUserOrAdmin;
using System;


namespace FB
{
    namespace AdminNamespace
    {
        using AN = FB.AdminNamespace;
        public class Admin
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Post[] Posts { get; set; }
            public Notification[] Notifications { get; set; }
            public int PostCount { get; set; }
            public int NotificationCount { get; set; }
            public static int MyIdPosts { get; set; }
            public void Show()
            {
                Console.WriteLine("=======ADMIN=======");
                Console.WriteLine($"ID : {Id}");
                Console.WriteLine($"Username : {Username}");
                Console.WriteLine($"Email : {Email}");
                if (Posts != null)
                {
                    foreach (var item in Posts)
                    {
                        item.Show();
                    }
                }
            }
            public void ShowNotification()
            {
                Console.WriteLine("=======ADMIN=======");
                Console.WriteLine($"ID : {Id}");
                Console.WriteLine($"Username : {Username}");
                Console.WriteLine($"Email : {Email}");
                if (Notifications != null)
                {
                    foreach (var item in Notifications)
                    {
                        item.Show();
                    }
                }
            }
            public Post NewPost()
            {
                Console.WriteLine("Type your status : ");
                Post post = new Post
                {
                    Content = Console.ReadLine(),
                    CreationDateTime = DateTime.Now,
                    Id = ++MyIdPosts,
                    ViewCount = 0,
                };
                return post;
            }
            public void AddPost()
            {
                Post[] posts = new Post[++PostCount];
                if (Posts != null)
                {
                    Posts.CopyTo(posts, 0);
                }
                posts[posts.Length - 1] = NewPost();
                Posts = posts;
            }
            public void AddNotification(Notification notification) {
                Notification[] notifications = new Notification[++NotificationCount];
                if (Notifications != null)
                {
                    Notifications.CopyTo(notifications, 0);
                }
                notifications[notifications.Length - 1] = notification;
                Notifications = notifications;
            }
            public void SearchPostWithIdAndLike(int id)
            {
                foreach (var item in Posts)
                {
                    if (id == item.Id)
                    {
                        ++item.ViewCount;
                        item.Show();
                        Console.WriteLine("1)Like");
                        Console.WriteLine("2)Back");
                        int choose1 = int.Parse(Console.ReadLine());
                        if (choose1 == 1)
                        {
                            Notification notification = new Notification
                            {
                                DateTime = DateTime.Now,
                                FromUser = Validation.User.Name,
                                Id = Validation.User.Id,
                                Text = $"User {Validation.User.Name} liked post"
                            };
                            Validation.Admin.AddNotification(notification);
                            SendMail.SendEmail("Liked post", $"{Validation.User.Name} liked your post");
                            ++item.LikeCount;
                            Console.Clear();
                            item.Show();
                        }
                        break;
                    }
                }
            }
        }
    }
}
