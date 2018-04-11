using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adneom.Distributeur.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit avoir au moins {2} et au maximum {1}caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Mot de passe")]
        [Compare("Password", ErrorMessage = "Votre mot de passe n'est pas identique la cele confirmé.")]
        public string ConfirmPassword { get; set; }
    }
}
