using Model.Global.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Mapper
{
    public static class FilMapper
    {
        public static Fil ToFil(this IDataRecord Data)
        {
            if (Data == null) throw new ArgumentNullException();

            return new Fil()
            {
                FilID = (int?)Data["FilID"],
                UsersID = (int)Data["UsersID"],
                Text = (string)Data["Text"],
                DateLigne = (DateTime?)Data["DateLigne"]
            };
        }
    }
}
