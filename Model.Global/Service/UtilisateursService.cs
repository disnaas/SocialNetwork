using Model.Global.Entity;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBoxNET.Connection.Database;

namespace Model.Global.Service
{
    public class UtilisateursService
    {
        public IEnumerable<Utilisateurs> Get()
        {
            Command cmd = new Command("SELECT * FROM Utilisateurs");
            return AccessLocator.Instance.Connect.ExecuteReader(cmd, c => c.ToUtilisateurs());
        }

        public Utilisateurs Get(string password, string mail)
        {
            Command cmd = new Command("SP_CheckUser", true);
            cmd.AddParameter("Email", mail);
            cmd.AddParameter("Password", password);
            return AccessLocator.Instance.Connect.ExecuteReader(cmd, c => c.ToUtilisateurs()).SingleOrDefault();
        }

        public Utilisateurs Get(int? userid)
        {
            Command cmd = new Command("SELECT * FROM Utilisateurs WHERE @User LIKE UsersID");
            cmd.AddParameter("User", userid);
            return AccessLocator.Instance.Connect.ExecuteReader(cmd, c => c.ToUtilisateurs()).SingleOrDefault();
        }

        public void Insert(Utilisateurs Entity)
        {
            Command cmd = new Command("SP_New_User", true);
            cmd.AddParameter("Nom", Entity.Nom);
            cmd.AddParameter("Prenom", Entity.Prenom);
            cmd.AddParameter("AdresseMail", Entity.AdresseMail);
            cmd.AddParameter("Password", Entity.Password);
            cmd.AddParameter("DateNaissance", Entity.DateNaissance);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public void Update(Utilisateurs Entity)
        {
            Command cmd = new Command("SP_UpdateUtilisateurs", true);
            cmd.AddParameter("Nom", Entity.Nom);
            cmd.AddParameter("Prenom", Entity.Prenom);
            cmd.AddParameter("AdresseMail", Entity.AdresseMail);
            cmd.AddParameter("UsersID", Entity.UsersID);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public void Delete(Utilisateurs Entity)
        {
            Command cmd = new Command("SP_DelUser", true);
            cmd.AddParameter("Id", Entity.UsersID);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
    }
}
