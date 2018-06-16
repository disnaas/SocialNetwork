using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Models
{
    public class SearchForm
    {
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        public int? UsersID { get; set; }
    }
}