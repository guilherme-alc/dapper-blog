using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("Tag")]
    public class PostTagReport
    {
        public string TagName { get; set; }
        public int PostCount { get; set; }
    }
}
