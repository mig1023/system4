using System.ComponentModel.DataAnnotations;

namespace system4.BLL.CreateDoc
{
    public class ApplicantForm
    {
        public bool Removed { get; set; }

        public bool DocPerson { get; set; }

        [Required(ErrorMessage = "↓ Не указана фамилия")]
        [RegularExpression(@"^[А-Яа-я\s\-]+$", ErrorMessage = "↓ Неверный формат фамилии")]
        public string RLName { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [RegularExpression(@"^[А-Яа-я\s\-]+$", ErrorMessage = "↓ Неверный формат имени")]
        public string RFName { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        [RegularExpression(@"^[А-Яа-я\s\-]+$", ErrorMessage = "↓ Неверный формат отчества")]
        public string RMName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "↓ Не указана дата рождения")]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "↓ Не указана дата вылета")]
        public DateTime FlyDate { get; set; }

        [Required(ErrorMessage = "Не указан BankID")]
        [RegularExpression(@"^(\d{4}\/\d{8}|автоматически)$", ErrorMessage = "↓ Неверный формат BankID")]
        public string BankId { get; set; }

        [Required(ErrorMessage = "↓ Не указан запрос")]
        public int? Request { get; set; }

        public bool Concil { get; set; }

        public bool NRes { get; set; }
    }
}
