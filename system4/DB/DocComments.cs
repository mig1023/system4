using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocComments
    {
        [Key]
        public int Id { get; set; }

        public int DocId { get; set; }

        public string Login { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
