using System;

namespace ViewModels
{
    public class Posts
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
