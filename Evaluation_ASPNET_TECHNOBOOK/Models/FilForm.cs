using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Models
{
    public class FilForm
    {
        [Required]
        [DisplayName("A quoi pensez-vous ? ")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}