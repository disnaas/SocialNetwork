using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Models
{
    public class FeedForm
    {
        public string Prenom { get; set; }
        [DisplayName("Modification de votre message : ")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public int? Id { get; set; }
        public int? UsersID { get; set; }
        public DateTime? DatePost { get; set; }
    }
}