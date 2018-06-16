using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Entity
{
    public class Utilisateurs
    {
        public int UsersID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }
        public string Password { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime? DateInscription { get; set; }
    }
}
