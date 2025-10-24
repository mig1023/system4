using System.ComponentModel.DataAnnotations;

namespace system4.BLL.CreateDoc
{
    public class DocForm
    {
        public int VisaType { get; set; }

        public int PayType { get; set; }

        public bool Urgent { get; set; }

        public List<ApplicantForm> Applicants { get; set; }

        public ApplicantForm? ApplicantDwhom { get; set; }
        
        [Required(ErrorMessage = "↓ Не выбрано на кого заключается договор")]
        public string LName { get; set; }

        [Required(ErrorMessage = "↓ Не выбрано на кого заключается договор")]
        public string FName { get; set; }

        [Required(ErrorMessage = "↓ Не выбрано на кого заключается договор")]
        public string MName { get; set; }

        [Required(ErrorMessage = "↓ Не указан номер паспорта")]
        public string PassNum { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "↓ Не указана дата выдачи паспорта")]
        public DateTime? PassDate { get; set; }

        [Required(ErrorMessage = "↓ Не указано кем выдан паспорт")]
        public string PassWhom { get; set; }

        public string? DovNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DovDate { get; set; }

        [Required(ErrorMessage = "↓ Не указан контактный телефон")]
        [Phone(ErrorMessage = "↓ Неверный формат телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "↓ Не указан адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "↓ Не указан EMail")]
        [EmailAddress(ErrorMessage = "↓ Неверный формат EMail")]
        public string InfoMail { get; set; }

        public string? Comment { get; set; }

        public string? Requests { get; set; }

        public List<Service> Services { get; set; }

        public bool Shipping { get; set; }
        public string ShippingAddr { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingInfo { get; set; }
        public bool ShippingOverload { get; set; }

        public bool SMS { get; set; }
        public string SmsMobile { get; set; }

        public DocForm()
        {
            Applicants = new List<ApplicantForm>();
            Services = new List<Service>();
        }

        public DocForm(DAL.Appointment appointment, List<DAL.Services> services)
        {
            Applicants = new List<ApplicantForm>();

            foreach (var appdata in appointment.AppData)
            {
                var applicant = new ApplicantForm
                {
                    ApplId = appdata.Id,
                    RLName = appdata.RLName,
                    RFName = appdata.RFName,
                    RMName = appdata.RMName,
                    BirthDate = appdata.BirthDate,
                    FlyDate = appdata.AppSDate,
                };
                Applicants.Add(applicant);
            }

            Services = new List<Service>();

            foreach (var data in services)
            {
                var service = new Service
                {
                    Name = data.ServiceId > 0 ? data.ServiceId.ToString() : data.ServiceName,
                    Text = data.Name,
                    Enabled = false,
                    ValueType = data.ValueType,
                };
                Services.Add(service);
            }

            Shipping = appointment.Shipping == 1;
            ShippingAddr = appointment.ShAddress;

            SMS = appointment.SMS == 1;
            SmsMobile = appointment.Mobile;
        }
    }
}
