using System.Linq;
using system4.DAL;
using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Get
    {
        public static User User(string login)
        {
            using (var db = new EntityContext())
            {
                var user = db.Users
                    .SingleOrDefault(x => x.Login == login);

                if (user == null)
                    return null;

                return user;
            }
        }

        public static List<Appointment> AppsByDate(DateTime date, int centerId)
        {
            using (var db = new EntityContext())
            {
                var apps = db.Appointments
                    .Where(x => (x.AppDate == date.Date) && (x.CenterId == centerId))
                    .ToList();

                return apps;
            }
        }

        public static List<int> AppsByDate(DateTime date, int page, int size, out int count)
        {
            using (var db = new EntityContext())
            {
                var allApp = db.Appointments
                    .Where(x => x.AppDate == date.Date)
                    .Select(x => x.Id)
                    .ToList();

                count = allApp.Count;

                var apps = allApp
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return apps;
            }
        }

        public static List<int> AppsByPassnum(string pass, int page, int size, out int count)
        {
            using (var db = new EntityContext())
            {
                var allApps = db.AppData
                    .Where(x => x.PassNum == pass)
                    .Distinct()
                    .Select(x => x.AppId)
                    .ToList();

                count = allApps.Count;

                var apps = allApps
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return apps;
            }
        }

        public static int AppByNum(string appNum)
        {
            using (var db = new EntityContext())
            {
                var app = db.Appointments
                    .SingleOrDefault(x => x.AppNum == appNum);

                return app?.Id ?? 0;
            }
        }

        public static Dictionary<DateTime, int> AppsCountByPeriod(DateTime start, DateTime end,
            int centerId, bool agency = false)
        {
            var isAgency = agency ? 1 : 0;

            using (var db = new EntityContext())
            {
                var apps = db.Appointments
                    .Where(x => (x.AppDate >= start) && (x.AppDate <= end) && (x.CenterId == centerId) && (x.Status != 2))
                    .GroupBy(x => x.AppDate)
                    .Select(x => new { Date = x.Key, Apps = x.Sum(y => y.NCount) });

                var data = new Dictionary<DateTime, int>();

                foreach (var app in apps)
                    data.Add(app.Date, app.Apps);

                return data;
            }
        }

        public static Appointment App(int appId)
        {
            using (var db = new EntityContext())
            {
                var app = db.Appointments
                    .SingleOrDefault(x => x.Id == appId);

                return app;
            }
        }

        public static List<AppData> AppData(int appId)
        {
            using (var db = new EntityContext())
            {
                var apps = db.AppData
                    .Where(x => x.AppId == appId)
                    .ToList();

                return apps;
            }
        }

        public static List<AppComments> AppComments(int appId)
        {
            using (var db = new EntityContext())
            {
                var comments = db.AppComments
                    .Where(x => x.AppID == appId)
                    .ToList();

                return comments;
            }
        }

        public static List<int> DocsByDate(DateTime date, int page, int size,
            bool juridical, out int count)
        {
            using (var db = new EntityContext())
            {
                var allDocs = db.DocPack
                    .Where(x => x.PDate == date.Date)
                    .Where(x => juridical ? x.JurId > 0 : x.JurId == 0)
                    .Select(x => x.Id)
                    .ToList();

                count = allDocs.Count;

                var docs = allDocs
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return docs;
            }
        }

        public static List<int> DocsByPassnum(string pass, int page, int size,
            bool juridical, out int count)
        {
            using (var db = new EntityContext())
            {
                var lists = db.DocPackList
                    .Where(x => x.PassNum == pass)
                    .Select(x => x.PackInfoId)
                    .ToList();

                var infos = db.DocPackInfo
                    .Where(x => lists.Contains(x.Id))
                    .Select(x => x.PackId)
                    .Distinct()
                    .ToList();

                count = infos.Count;

                var docs = db.DocPack
                    .Where(x => infos.Contains(x.Id))
                    .Select(x => x.Id)
                    .Distinct()
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return docs;
            }
        }

        public static int DocByBankId(string bankid)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPackInfo
                    .SingleOrDefault(x => x.BankId == bankid);

                return doc?.PackId ?? 0;
            }
        }

        public static int DocByNum(string agreementNo) =>
            Doc(agreementNo)?.Id ?? 0;

        public static DocPack Doc(string agreementNo)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPack
                    .SingleOrDefault(x => x.AgreementNo == Formats.OnlyNumeric(agreementNo));

                return doc;
            }
        }

        public static DocPack Doc(int docId)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPack
                    .SingleOrDefault(x => x.Id == docId);

                return doc;
            }
        }

        public static List<DocPackInfo> DocInfo(int docId)
        {
            using (var db = new EntityContext())
            {
                var docinfo = db.DocPackInfo
                    .Where(x => x.PackId == docId)
                    .ToList();

                return docinfo;
            }
        }

        public static List<DocPackList> DocList(int docInfoId)
        {
            using (var db = new EntityContext())
            {
                var doclist = db.DocPackList
                    .Where(x => x.PackInfoId == docInfoId)
                    .ToList();

                return doclist;
            }
        }

        public static List<DocComments> DocComments(int docId)
        {
            using (var db = new EntityContext())
            {
                var comments = db.DocComments
                    .Where(x => x.DocId == docId)
                    .ToList();

                return comments;
            }
        }

        public static DocPackOptional DocPackOptional(int docId)
        {
            using (var db = new EntityContext())
            {
                var options = db.DocPackOptional
                    .SingleOrDefault(x => x.DocPackId == docId);

                return options;
            }
        }

        public static List<Branches> Branches()
        {
            using (var db = new EntityContext())
            {
                var branches =  db.Branches
                    .Where(x => x.IsDeleted == 0)
                    .ToList();

                return branches;
            }
        }

        public static Branches Branches(int centerId)
        {
            using (var db = new EntityContext())
            {
                var branch = db.Branches
                    .SingleOrDefault(x => x.Id == centerId);

                return branch;
            }
        }

        public static List<VisaTypes> VisaTypes()
        {
            using (var db = new EntityContext())
            {
                var type = db.VisaTypes
                    .ToList();

                return type;
            }
        }

        public static VisaTypes VisaTypes(int visaId)
        {
            using (var db = new EntityContext())
            {
                var visa = db.VisaTypes
                    .SingleOrDefault(x => x.Id == visaId);

                return visa;
            }
        }

        public static List<VisaTypes> VisaTypesByCenter(int centerId)
        {
            using (var db = new EntityContext())
            {
                var visas = new List<VisaTypes>();

                foreach (var visa in db.VisaTypes)
                {
                    var centers = visa.Centers
                        .Split(',')
                        .Select(x => int.Parse(x))
                        .ToList();

                    if (centers.Contains(centerId))
                    {
                        visas.Add(visa);
                    }
                }

                return visas;
            }
        }

        public static TimeData TimeDataById(int slotId)
        {
            using (var db = new EntityContext())
            {
                var slot = db.TimeData
                    .SingleOrDefault(x => x.SlotId == slotId);

                return slot;
            }
        }

        public static List<TimeData> TimeDataByTimeslot(int timeslotId, int dayNum)
        {
            using (var db = new EntityContext())
            {
                var slot = db.TimeData
                    .Where(x => (x.TimeId == timeslotId) && (x.isDeleted == 0))
                    .Where(x => x.DayNum == dayNum)
                    .OrderBy(x => x.TStart)
                    .ToList();

                return slot;
            }
        }

        public static TimeData TimeDataByTStart(int timeslotId, int tStart, int dayNum)
        {
            using (var db = new EntityContext())
            {
                var slot = db.TimeData
                    .Where(x => (x.TimeId == timeslotId) && (x.isDeleted == 0) && (x.TStart <= tStart) && (x.DayNum == dayNum))
                    .OrderByDescending(x => x.TStart)
                    .First();

                return slot;
            }
        }

        public static Timeslots Timeslots(int centerId, DateTime date, bool agency = false)
        {
            var isAgency = agency ? 1 : 0;

            using (var db = new EntityContext())
            {
                var slot = db.Timeslots
                    .Where(x => (x.BranchID == centerId) && (x.IsDeleted == 0) && (x.Agency == isAgency))
                    .Where(x => x.TDate <= date)
                    .OrderByDescending(x => x.TDate)
                    .First();

                return slot;
            }
        }

        public static Dictionary<DateTime, Dictionary<int, int>> Timeslots(int centerId, bool agency = false)
        {
            var isAgency = agency ? 1 : 0;

            using (var db = new EntityContext())
            {
                var slots = from tms in db.Timeslots
                            join tmd in db.TimeData on tms.Id equals tmd.TimeId
                            where tms.BranchID == centerId && tms.IsDeleted == 0 && tmd.isDeleted == 0 && tms.Agency == isAgency
                            group tmd by new { tms.Id, tmd.DayNum, tms.TDate } into timeslots
                            select new
                            {
                                Date = timeslots.Key.TDate,
                                Visas = timeslots.Sum(x => x.Visas),
                                Day = timeslots.Key.DayNum,
                            };

                var data = new Dictionary<DateTime, Dictionary<int, int>>();

                foreach (var slot in slots)
                {
                    if (!data.ContainsKey(slot.Date))
                        data.Add(slot.Date, new Dictionary<int, int>());

                    data[slot.Date].Add(slot.Day, slot.Visas);
                }

                return data;
            }
        }

        public static List<DocHistory> DocHistory(int docid)
        {
            using (var db = new EntityContext())
            {
                var history = db.DocHistory
                    .Where(x => x.DocId == docid)
                    .ToList();

                return history;
            }
        }

        public static List<DocHistory> DocHistoryByPassnum(string passnum)
        {
            using (var db = new EntityContext())
            {
                var history = db.DocHistory
                    .Where(x => x.PassNum == passnum)
                    .ToList();

                return history;
            }
        }

        public static List<DocHistory> DocHistoryByBankId(string bankId)
        {
            using (var db = new EntityContext())
            {
                var history = db.DocHistory
                    .Where(x => x.BankId == bankId)
                    .ToList();

                return history;
            }
        }

        public static PriceRate PriceRate(int rateId)
        {
            using (var db = new EntityContext())
            {
                var price = db.PriceRate
                    .SingleOrDefault(x => x.Id == rateId);

                return price;
            }
        }

        public static PriceRate PriceRate(string currency, DateTime date, int centerId)
        {
            using (var db = new EntityContext())
            {
                var price = db.PriceRate
                    .Where(x => (x.BranchId == centerId) && (x.RDate <= date) && (x.Currency == currency))
                    .Where(x => x.isDeleted == 0)
                    .OrderByDescending(x => x.RDate)
                    .SingleOrDefault();

                return price;
            }
        }

        public static List<PriceList> PriceList(int rateId, int visaType)
        {
            using (var db = new EntityContext())
            {
                var price = db.PriceList
                    .Where(x => x.RateId == rateId)
                    .Where(x => x.VisaId == visaType)
                    .ToList();

                return price;
            }
        }

        public static List<ServicesPriceRates> ServicesPriceRates(int rateId)
        {
            using (var db = new EntityContext())
            {
                var price = db.ServicesPriceRates
                    .Where(x => x.PriceRateId == rateId)
                    .ToList();

                return price;
            }
        }

        public static List<DAL.Services> ServicesByDocId(int docId)
        {
            using (var db = new EntityContext())
            {
                var services = 
                    from dps in db.DocPackService
                    join s in db.Services on dps.ServiceId equals s.Id
                    join sf in db.ServiceFields on dps.ServiceId equals sf.ServiceId
                    join sint in db.ServiceFieldValuesINT on dps.Id equals sint.DocPackServiceId
                    where dps.PackId == docId
                    select new
                    {
                        serviceId = s.Id,
                        name = s.Name,
                        valueType = sf.ValueType,
                        value = sint.Value
                    };

                var servicesList = new List<DAL.Services>();

                foreach (var service in services)
                {
                    var serviceListElement = new DAL.Services
                    {
                        ServiceId = service.serviceId,
                        Name = service.name,
                        ValueType = service.valueType,
                        Value = service.value,
                    };

                    servicesList.Add(serviceListElement);
                }

                return servicesList;
            }
        }

        public static Companies Companies(int companyId)
        {
            using (var db = new EntityContext())
            {
                var company = db.Companies
                    .SingleOrDefault(x => x.Id == companyId);

                return company;
            }
        }
        
        public static List<DAL.Services> ServicesByCenter(int centerId)
        {
            using (var db = new EntityContext())
            {
                var services =
                    from s in db.Services
                    join sb in db.ServicesBranches on s.Id equals sb.ServiceId
                    join sf in db.ServiceFields on s.Id equals sf.ServiceId
                    where sb.BranchId == centerId
                    select new
                    {
                        serviceId = s.Id,
                        name = s.Name,
                        valueType = sf.ValueType
                    };

                var servicesList = new List<DAL.Services>();

                foreach (var service in services)
                {
                    var serviceListElement = new DAL.Services
                    {
                        ServiceId = service.serviceId,
                        Name = service.name,
                        ValueType = service.valueType,
                    };

                    servicesList.Add(serviceListElement);
                }

                return servicesList;
            }
        }

        public static List<Holidays> Holidays(int centerId)
        {
            using (var db = new EntityContext())
            {
                var allHolidays = db.Holidays
                    .Where(x => x.HDate.Date >= DateTime.Now)
                    .ToList();

                var holidays = new List<Holidays>();

                foreach (var holiday in allHolidays)
                {
                    var centers = holiday.Centers
                        .Split(',')
                        .Select(x => int.Parse(x))
                        .ToList();

                    if (centers.Contains(centerId))
                    {
                        holidays.Add(holiday);
                    }
                }

                return holidays;
            }
        }
        
        public static List<Exclusions> Exclusions(int centerId)
        {
            using (var db = new EntityContext())
            {
                var allExclusions = db.Exclusions
                    .Where(x => x.EDate.Date >= DateTime.Now)
                    .ToList();

                var exclusions = new List<Exclusions>();

                foreach (var exclusion in allExclusions)
                {
                    var centers = exclusion.Centers
                        .Split(',')
                        .Select(x => int.Parse(x))
                        .ToList();

                    if (centers.Contains(centerId))
                    {
                        exclusions.Add(exclusion);
                    }
                }

                return exclusions;
            }
        }

        public static List<SchengenItalianBrd> SchengenItalianBrd()
        {
            using (var db = new EntityContext())
            {
                var brd = db.SchengenItalianBrd.ToList();
                return brd;
            }
        }

        public static List<Countries> Countries()
        {
            using (var db = new EntityContext())
            {
                var countries = db.Countries.ToList();
                return countries;
            }
        }
    }
}
