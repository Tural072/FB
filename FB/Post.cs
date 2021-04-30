using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB
{
    namespace PostNamespace
    {
        public class Post
        {
            public int Id { get; set; }
            public string Content { get; set; }
            public DateTime CreationDateTime { get; set; }
            public int LikeCount { get; set; }
            public int ViewCount { get; set; }
            public void Show() {
                Console.WriteLine("=======POSTS=======");
                Console.WriteLine($"ID : {Id}");
                Console.WriteLine($"Content : {Content}");
                Console.WriteLine($"Date time : {CreationDateTime}");
                Console.WriteLine($"Like : {LikeCount}");
                Console.WriteLine($"View : {ViewCount}");
            }
            
        }
    }
}
