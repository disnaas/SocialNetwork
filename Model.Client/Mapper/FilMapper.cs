using C = Model.Client.Entity;
using Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Mapper
{
    public static class FilMapper
    {
        public static C.Fil ToClient (this Fil Entity)
        {
            return new C.Fil(Entity.UsersID, Entity.Text, Entity.FilID, Entity.DateLigne);
        }
        public static Fil ToGlobal(this C.Fil Entity)
        {
            return new Fil()
            {
                UsersID = Entity.UsersID,
                FilID = Entity.FilID,
                Text = Entity.Text,
                DateLigne = Entity.DateLigne
            };
        }
    }
}
