using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Models
{
    public class UtilisateursForm
    {
        [Required]
        [DisplayName("Votre nom :")]
        public string Nom { get; set; }
        [Required]
        [DisplayName("Votre prénom :")]
        public string Prenom { get; set; }
        [Required]
        [DisplayName("Votre adresse email :")]
        public string AdresseMail { get; set; }
        [Required]
        [DisplayName("Votre mot de passe :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Retapez votre mot de passe :")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Votre date de naissance :")]
        public DateTime DateNaissance { get; set; }
    }
}