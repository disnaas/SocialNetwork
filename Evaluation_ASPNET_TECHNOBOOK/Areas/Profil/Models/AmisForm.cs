using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Models
{
    public class AmisForm
    {
        [DisplayName("Nom")]
        public string Nom { get; set; }
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        [DisplayName("Date de naissance")]
        public DateTime DateNaissance { get; set; }
        [DisplayName("Date d'inscription")]
        public DateTime? DateDinscription { get; set; }
        public int? UsersID { get; set; }

    }
}