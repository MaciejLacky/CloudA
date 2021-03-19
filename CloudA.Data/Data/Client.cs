using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudA.Data
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        [Required(ErrorMessage = "Imie wymagane")]
        [Display(Name = "Imie")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nazwisko wymagane")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Miejscowosc wymagane")]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }
        [Required(ErrorMessage = "Adres email wymagany")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Szkoła wymagana")]
        [Display(Name = "Szkoła")]
        public string School { get; set; }
        [Required(ErrorMessage = "Zgoda wymagana")]
        [Display(Name = "Zgoda na przetwarzanie danych osobowych")]
        public bool permission1 { get; set; }
        [Required(ErrorMessage = "Zgoda wymagana")]
        [Display(Name = "Zgoda na marketing")]
        public bool permission2 { get; set; }
        public int IdEvent { get; set; }
        public virtual Event Event { get; set; }
    }
}
