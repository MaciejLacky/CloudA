using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudA.Data
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        [Required(ErrorMessage = "Wpisz tytuł wydarzenia")]
        [Display(Name = "Tytuł PL")]
        public string TitlePL { get; set; }
        [Display(Name = "Tytuł ANG")]
        public string TitleEng { get; set; }
        [Display(Name = "Tytuł ROS")]
        public string TitleRos { get; set; }
        [Display(Name = "Data i godzina aktywności formularza od:")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Data i godzina aktywności formularza do:")]
        public DateTime DateTo { get; set; }
        [Display(Name = "Czy pokazywać zarejestrowanych?")]
        public bool IsRegister { get; set; }
        
        public string LogoUrl { get; set; }
        [Display(Name = "Maksymalna liczba osób")]
        public int MaxNumOfPeople { get; set; }
        [Display(Name = "Zarejestrowani")]
        public int NumOfRegistered { get; set; }
        [Display(Name = "Opis wydarzenia")]
        public string Content { get; set; }
        [NotMapped]
        [Display(Name ="Dodaj zdjęcie")]
        public List<IFormFile> ImageFile { get; set; }
        public virtual ICollection<Client> Clients
        {
            get;
            set;
        }
    }
}
