using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Models
{
    public class DemandeAmis
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? UsersID { get; set; }
        public int? AmisID { get; set; }
    }
}