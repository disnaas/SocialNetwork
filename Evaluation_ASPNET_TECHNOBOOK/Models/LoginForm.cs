using Evaluation_ASPNET_TECHNOBOOK.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Models
{
    public class LoginForm
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Votre adresse email :")]
        public string AdresseMail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Votre mot de passe :")]
        public string Password { get; set; }
    }
}