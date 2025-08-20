using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class AppComments
    {
        [Key]
        public int Id { get; set; }

        public int AppID { get; set; }

        public string Login { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
