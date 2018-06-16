using Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Mapper
{
    public static class UtilisateursMapper
    {
        public static Utilisateurs ToUtilisateurs(this IDataRecord Data)
        {
            if (Data == null) throw new ArgumentNullException();

            return new Utilisateurs()
            {
                UsersID = (int)Data["UsersID"],
                Nom = (string)Data["Nom"],
                Prenom = (string)Data["Prenom"],
                AdresseMail = (string)Data["AdresseMail"],
                Password = null,
                DateInscription = (DateTime?)Data["DateInscription"],
                DateNaissance = (DateTime)Data["DateNaissance"]
            };
        }
    }
}
