using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStatus = Hfttf.TaskManagement.Core.Entities.TaskStatus;

namespace Hfttf.TaskManagement.Infrastructure.Data.SeedData
{
    public class SeedDatabase
    {
        public static async System.Threading.Tasks.Task SeedAsync(TaskManagementContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                context.Database.Migrate();

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(GetAddresses());
                    await context.SaveChangesAsync();
                }
                if (!context.BankInformations.Any())
                {
                    context.BankInformations.AddRange(GetBankInformations());
                    await context.SaveChangesAsync();
                }
                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(GetDepartments());
                    await context.SaveChangesAsync();
                }
                if (!context.EducationInformations.Any())
                {
                    context.EducationInformations.AddRange(GetEducationInformations());
                    await context.SaveChangesAsync();
                }
                if (!context.EmergencyContactInfos.Any())
                {
                    context.EmergencyContactInfos.AddRange(GetEmergencyContactInfos());
                    await context.SaveChangesAsync();
                }
                if (!context.Experiences.Any())
                {
                    context.Experiences.AddRange(GetExperiences());
                    await context.SaveChangesAsync();
                }
                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(GetJobs());
                    await context.SaveChangesAsync();
                }
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(GetProjects());
                    await context.SaveChangesAsync();
                }
                if (!context.Leaders.Any())
                {
                    context.Leaders.AddRange(GetLeaders());
                    await context.SaveChangesAsync();
                }
                if (!context.Leaves.Any())
                {
                    context.Leaves.AddRange(GetLeaves());
                    await context.SaveChangesAsync();
                }
                if (!context.TaskStatuses.Any())
                {
                    context.TaskStatuses.AddRange(GetTaskStatuses());
                    await context.SaveChangesAsync();
                }
                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(GetTasks());
                    await context.SaveChangesAsync();
                }
                if (!context.UserSalaries.Any())
                {
                    context.UserSalaries.AddRange(GetUserSalaries());
                    await context.SaveChangesAsync();
                }
                if (!context.UserAssignments.Any())
                {
                    context.UserAssignments.AddRange(GetUserAssignments());
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception exception)
            {

                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<SeedDatabase>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(1000);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }
        private static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address() { City="İstanbul", Country="Türkiye", ZipCode="34000", ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", Description="Orta Mah, Demirkapı Cd. No:13, Bayrampaşa/İstanbul"  },
                new Address() { City="İstanbul", Country="Türkiye", ZipCode="34000", ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", Description="Mimar Kemalettin, Ordu Cd. No:7, Fatih/İstanbul"  },
                new Address() { City="İstanbul", Country="Türkiye", ZipCode="34000", ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", Description="Yeni, Cengiz Topel Cd. No:173, Gaziosmanpaşa/İstanbul"  },
                new Address() { City="İzmir",    Country="Türkiye", ZipCode="35000", ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", Description="Bozyaka, Eski İzmir Cd. No:211,Karabağlar/İzmir"  },
                new Address() { City="İzmir",    Country="Türkiye", ZipCode="35000", ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", Description="Akdeniz, Gazi Blv. No:41, Konak/İzmir"  },
            };
        }

        private static IEnumerable<BankInformation> GetBankInformations()
        {
            return new List<BankInformation>
            {
                new BankInformation() { AccountNo="5207 5285 4577 5268", BankName="İş Bankası",         IBANNo="TR 1200 0800 1748 6541 2585 4003"  },
                new BankInformation() { AccountNo="6707 5675 4577 3768", BankName="Halk Bankası",       IBANNo="TR 1300 0600 1748 6541 2495 4883"  },
                new BankInformation() { AccountNo="1474 5255 4577 6678", BankName="Garanti Bankası",    IBANNo="TR 1400 0700 1748 6681 2945 6633"  },
                new BankInformation() { AccountNo="0585 5305 2237 5578", BankName="Yapı Kredi Bankası", IBANNo="TR 1500 0500 1748 6541 2585 5513"  },
                new BankInformation() { AccountNo="9437 5985 1134 1868", BankName="İş Bankası",         IBANNo="TR 1200 0800 1258 6541 2145 4333"  }
            };
        }

        private static IEnumerable<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department() { Name="Bilgi İşlem Departmanı" },
                new Department() { Name="Ağ Güvenlik Departmanı" },
                new Department() { Name="Yazılım Departmanı" },
                new Department() { Name="İnsan Kaynakları Departmanı" }

            };
        }
        private static IEnumerable<EducationInformation> GetEducationInformations()
        {
            return new List<EducationInformation>
            {
                new EducationInformation() {  StartDate="Eylül 2005", EndDate="Haziran 2009", SchoolName="İstanbul Üniversitesi",    ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", Section="Matematik Mühendisliği"  },
                new EducationInformation() {  StartDate="Eylül 2001", EndDate="Haziran 2005", SchoolName="Atatürk Anadolu Lisesi",   ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", Section="Anadolu Lisesi"},
                new EducationInformation() {  StartDate="Eylül 2010", EndDate="Haziran 2014", SchoolName="Marmara Üniversitesi",     ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", Section="Bilgisayar Mühendisliği"},
                new EducationInformation() {  StartDate="Eylül 2006", EndDate="Haziran 2010", SchoolName="Cumhuriyet Anadolu Lisesi",ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", Section="Anadolu Lisesi"},
                new EducationInformation() {  StartDate="Eylül 2004", EndDate="Haziran 2008", SchoolName="Ege Üniversitesi",         ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", Section="Elektrik Mühendisliği",   },

            };
        }

        private static IEnumerable<EmergencyContactInfo> GetEmergencyContactInfos()
        {
            return new List<EmergencyContactInfo>
            {
                new EmergencyContactInfo() { Name="Mehmet Kaya",  Phone="0 555 444 55 44", RelationShip="Baba", ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0" },
                new EmergencyContactInfo() { Name="Salim Yılmaz", Phone="0 544 333 11 77", RelationShip="Baba", ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f" },
                new EmergencyContactInfo() { Name="Fatma Kırca",  Phone="0 533 222 22 88", RelationShip="Eş",   ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21"},
                new EmergencyContactInfo() { Name="Elif Kaya",    Phone="0 522 111 33 99", RelationShip="Eş",   ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0"}

            };
        }
        private static IEnumerable<Experience> GetExperiences()
        {
            return new List<Experience>
            {
                new Experience() { ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", StartDate="Temmuz 2005", EndDate="Kasım 2007", Job="Yazılım Geliştirici", Company="ABC Şirketi"  },
                new Experience() { ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", StartDate="Temmuz 2010", EndDate="Kasım 2013", Job="Web Tasarımcısı",   Company="DEF Şirketi" },
                new Experience() { ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", StartDate="Temmuz 2008", EndDate="Kasım 2013", Job="Proje Yöneticisi",  Company="QWE Şirketi" },
                new Experience() { ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", StartDate="Temmuz 2013", EndDate="Kasım 2015", Job="Veritabanı Uzmanı", Company="GTH Şirketi"}

            };
        }
        private static IEnumerable<Job> GetJobs()
        {
            return new List<Job>
            {
                new Job() { Name="Yazılım Geliştirici" },
                new Job() { Name="Web Tasarımcısı"},
                new Job() { Name="Proje Yöneticisi" },
                new Job() {  Name="Veritabanı Uzmanı"},
                new Job() {  Name="İnsan Kaynakları Uzmanı"}

            };
        }
        private static IEnumerable<Leader> GetLeaders()
        {
            return new List<Leader>
            {
                new Leader() { ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", ProjectId=1 },
                new Leader() { ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", ProjectId=2 },
                new Leader() { ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", ProjectId=3 },

            };
        }

        private static IEnumerable<Leave> GetLeaves()
        {
            return new List<Leave>
            {
                new Leave() { ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-7), UpdatedDate=DateTime.Now.AddDays(-5), StartDate=DateTime.Now.AddDays(-7), EndDate=DateTime.Now.AddDays(2), NumberOfDay="9", Title="Yıllık İzin" },
                new Leave() { ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", CreateBy="Mustafa Kaya",UpdateBy="Mustafa Kaya", CreatedDate=DateTime.Now.AddDays(-9), UpdatedDate=DateTime.Now.AddDays(-7), StartDate=DateTime.Now.AddDays(-9), EndDate=DateTime.Now.AddDays(1), NumberOfDay="10", Title="Yıllık İzin"},
                new Leave() { ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", CreateBy="Mustafa Kaya",UpdateBy="Mustafa Kaya", CreatedDate=DateTime.Now.AddDays(-5), UpdatedDate=DateTime.Now.AddDays(-5), StartDate=DateTime.Now.AddDays(-5), EndDate=DateTime.Now.AddDays(2), NumberOfDay="7", Title="Yıllık İzin"},
                new Leave() { ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-3), UpdatedDate=DateTime.Now.AddDays(-2), StartDate=DateTime.Now.AddDays(-3), EndDate=DateTime.Now.AddDays(3), NumberOfDay="6", Title="Yıllık İzin"},
                new Leave() { ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", CreateBy="Ali Yılmaz",  UpdateBy="Ali Yılmaz",   CreatedDate=DateTime.Now.AddDays(-6), UpdatedDate=DateTime.Now.AddDays(-4), StartDate=DateTime.Now.AddDays(-6), EndDate=DateTime.Now.AddDays(4), NumberOfDay="10", Title="Yıllık İzin"}

            };
        }

        private static IEnumerable<Project> GetProjects()
        {
            return new List<Project>
            {
                new Project() { LeaderId=1 ,CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-10), StartDate=DateTime.Now.AddDays(-15), EndDate=DateTime.Now.AddDays(7),  Title="Kurumsal Web Sitesi Oluşturma", Priority=PriorityLevel.Medium, Description="TROYA firmasının genel işlemlerini gerçekleştirebileceği bir web sitesi oluşturmak"},
                new Project() { LeaderId=2 ,CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-17), UpdatedDate=DateTime.Now.AddDays(-9), StartDate=DateTime.Now.AddDays(-15),  EndDate=DateTime.Now.AddDays(8),  Title="Personel Takip Sistemi Oluşturma", Priority=PriorityLevel.Medium, Description="PERFECT firmasının personellerini takip ettiği personel yönetim sistemi oluşturmak" },
                new Project() { LeaderId=3 ,CreateBy="Ali Yılmaz", UpdateBy="Ali Yılmaz",  CreatedDate=DateTime.Now.AddDays(-16), UpdatedDate=DateTime.Now.AddDays(-14), StartDate=DateTime.Now.AddDays(-15),   EndDate=DateTime.Now.AddDays(9),  Title="Veritabanı Oluşturma", Priority=PriorityLevel.Medium, Description="BOOMBER firmasının genel verilerini kontrol ettiği veritabanını oluşturmak" },               

            };
        }
        private static IEnumerable<Core.Entities.Task> GetTasks()
        {
            return new List<Core.Entities.Task>
            {
                new Core.Entities.Task() { CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17),  DueDate=DateTime.Now.AddDays(-12),   Title="Site Tasarımı Belirleme", Priority=PriorityLevel.Medium, Description="TROYA firması tavsiyelerine göre web tasarımının bileşenlerinin hazırlanması", TaskStatusId=1 , ProjectId=1},
                new Core.Entities.Task() { CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-16),  DueDate=DateTime.Now.AddDays(-15),   Title="Site Tasarımı Düzenleme", Priority=PriorityLevel.Medium, Description="TROYA firması tavsiyelerine göre web tasarımının iyileştirilmesi ve düzenlenmesi",TaskStatusId=2, ProjectId=1},
                new Core.Entities.Task() { CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-15), UpdatedDate=DateTime.Now.AddDays(-9),   DueDate=DateTime.Now.AddDays(-10),   Title="Sistem Analizi Yapma", Priority=PriorityLevel.Medium, Description="Sistemde bulunması gereken use-case lerin ve nesnelerin belirlenmesi",TaskStatusId=1 , ProjectId=2},
                new Core.Entities.Task() { CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-15), UpdatedDate=DateTime.Now.AddDays(-9),   DueDate=DateTime.Now.AddDays(-11),   Title="Use-Case'leri oluşturma", Priority=PriorityLevel.Medium, Description="Sistemde bulunması gereken use-case lerin ve nesnelerin oluşturulması",TaskStatusId=2, ProjectId=2},
                new Core.Entities.Task() { CreateBy="Ali Yılmaz", UpdateBy="Ali Yılmaz",    CreatedDate=DateTime.Now.AddDays(-7), UpdatedDate=DateTime.Now.AddDays(-6),    DueDate=DateTime.Now.AddDays(-2),    Title="Veritabanı Tablolarını belirleme", Priority=PriorityLevel.Medium, Description="Verilerin kaydedileceği nesnelerin ve tabloların belirlenmesi",TaskStatusId=3 , ProjectId=3},
                new Core.Entities.Task() { CreateBy="Ali Yılmaz", UpdateBy="Ali Yılmaz",    CreatedDate=DateTime.Now.AddDays(-7), UpdatedDate=DateTime.Now.AddDays(-5),    DueDate=DateTime.Now.AddDays(-1),    Title="Veritabanı Tablolarını oluşturma", Priority=PriorityLevel.Medium, Description="Verilerin kaydedileceği nesnelerin ve tabloların oluşturulması",TaskStatusId=4 , ProjectId=3},
            };
        }
        private static IEnumerable<TaskStatus> GetTaskStatuses()
        {
            return new List<TaskStatus>
            {
                new TaskStatus() {Status=StatusLevel.Pending },
                new TaskStatus() {Status=StatusLevel.InProgress },
                new TaskStatus() {Status=StatusLevel.OnHold},
                new TaskStatus() {Status=StatusLevel.Cancelled}
            };
        }

        private static IEnumerable<UserAssignment> GetUserAssignments()
        {
            return new List<UserAssignment>
            {
                new UserAssignment() {CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17), ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", TaskId=1 },
                new UserAssignment() {CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17), ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", TaskId=4 },
                new UserAssignment() {CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17), ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", TaskId=5 },
                new UserAssignment() {CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17), ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f", TaskId=1 },
                new UserAssignment() {CreateBy="Ali Yılmaz", UpdateBy="Ali Yılmaz",    CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17), ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21", TaskId=2 },
                new UserAssignment() {CreateBy="Ali Yılmaz", UpdateBy="Ali Yılmaz",    CreatedDate=DateTime.Now.AddDays(-18), UpdatedDate=DateTime.Now.AddDays(-17), ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0", TaskId=3 }
            
            };
        }

        private static IEnumerable<UserSalary> GetUserSalaries()
        {
            return new List<UserSalary>
            {
                new UserSalary() { Salary=5800, CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-6), UpdatedDate=DateTime.Now.AddDays(-5), ApplicationUserId="532db8c3-01fe-4abf-b12a-fd327ccc59c0" },
                new UserSalary() { Salary=7200, CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-6), UpdatedDate=DateTime.Now.AddDays(-5), ApplicationUserId="627531db-66ff-4da8-a411-f88bc1ac0e21" },
                new UserSalary() { Salary=6700, CreateBy="Ahmet Kırca", UpdateBy="Ahmet Kırca",  CreatedDate=DateTime.Now.AddDays(-5), UpdatedDate=DateTime.Now.AddDays(-5), ApplicationUserId="c9ce4c23-92ec-4de7-b54a-f79cc7746e4f" },
            };
        }


    }

}
