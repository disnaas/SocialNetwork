using Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Mapper
{
    public static class AmisMapper
    {
        public static Amis ToAmis(this IDataRecord Data)
        {
            if (Data == null) throw new ArgumentNullException();

            return new Amis()
            {
                UsersID = (int?)Data["UsersID"],
                AmisID = (int?)Data["AmisID"],
                IsAmis = (bool)Data["EstAMIS"],
                DemandeAmis = (bool)Data["DemandeAmis"]
            };
        }
    }
}
