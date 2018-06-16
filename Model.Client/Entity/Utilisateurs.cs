using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Entity
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

        internal Utilisateurs(int usersid,string nom,string prenom,string adressemail,string password,DateTime naissance,DateTime? inscription)
        {
            UsersID = usersid;
            Nom = nom;
            Prenom = prenom;
            AdresseMail = adressemail;
            Password = password;
            DateNaissance = naissance;
            DateInscription = inscription;
        }
        public Utilisateurs(string password,string adressemail)
        {
            AdresseMail = adressemail;
            Password = password;
        }
        public Utilisateurs(string nom, string prenom,string adressemail, string password,DateTime naissance) : this(0, nom, prenom,adressemail,password,naissance,null)
        {}
        public Utilisateurs(int userid,string nom, string prenom, string email)
        {
            UsersID = userid;
            Nom = nom;
            Prenom = prenom;
            AdresseMail = email;
        }
        public Utilisateurs(int id)
        {
            UsersID = id;
        }
    }
}
