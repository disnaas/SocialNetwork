using C = Model.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Global.Entity;

namespace Model.Client.Mapper
{
    public static class AmisMapper
    {
        public static C.Amis ToClient(this Amis Entity)
        {
            return new C.Amis(Entity.UsersID, Entity.AmisID, Entity.IsAmis,Entity.DemandeAmis);
        }
        public static Amis ToGlobal(this C.Amis Entity)
        {
            return new Amis()
            {
                AmisID = Entity.AmisID,
                UsersID = Entity.UsersID,
                IsAmis = Entity.IsAmis,
                DemandeAmis = Entity.DemandeAmis
            };
        }
    }
}
