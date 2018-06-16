using C = Model.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Global.Entity;

namespace Model.Client.Mapper
{
    public static class UtilisateursMapper
    {
        public static C.Utilisateurs ToClient(this Utilisateurs Entity)
        {
            return new C.Utilisateurs(Entity.UsersID,Entity.Nom, Entity.Prenom, Entity.AdresseMail, Entity.Password,Entity.DateNaissance,Entity.DateInscription);
        }
        public static Utilisateurs ToGlobal(this C.Utilisateurs Entity)
        {
            return new Utilisateurs()
            {
                UsersID = Entity.UsersID,
                AdresseMail = Entity.AdresseMail,
                Nom = Entity.Nom,
                Prenom = Entity.Prenom,
                Password = Entity.Password,
                DateInscription = Entity.DateInscription,
                DateNaissance = Entity.DateNaissance
            };
        }
    }
}
