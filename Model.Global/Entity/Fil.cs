using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Entity
{
    public class Fil
    {
        public int? FilID { get; set; }
        public string Text { get; set; }
        public DateTime? DateLigne { get; set; }
        public int UsersID { get; set; }
    }
}
