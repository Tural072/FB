using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB
{
    namespace NotificationNamespace
    {
        public class Notification
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public DateTime DateTime { get; set; }
            public string  FromUser { get; set; }
            public void Show() {
                Console.WriteLine("========Notifications========");
                Console.WriteLine($"ID : {Id}");
                Console.WriteLine($"Content : {Text}");
                Console.WriteLine($"Date time : {DateTime}");
                Console.WriteLine($"From which users : {FromUser}");
            }
        }
    }
}
