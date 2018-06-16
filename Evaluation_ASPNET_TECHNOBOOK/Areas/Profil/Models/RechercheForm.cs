using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Models
{
    public class RechercheForm
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [DisplayName("Date d'inscription")]
        [DisplayFormat(NullDisplayText = "Jamais été inscrit")]
        public DateTime? DateInscription { get; set; }
        public int? UsersID { get; set; }
    }
}