using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Entity
{
    public class Fil
    {
        public int UsersID { get; set; }
        public string Text { get; set; }
        public int? FilID { get; set; }
        public DateTime? DateLigne { get; set; }

        internal Fil(int user,string text,int? filid, DateTime? dateligne)
        {
            UsersID = user;
            Text = text;
            FilID = filid;
            DateLigne = dateligne;
        }
        public Fil(int user,string text):this(user,text,null,null)
        {

        }
        public Fil(int user,string text,int fildid):this(user,text,fildid,null)
        {

        }
        public Fil(int user, int filid) : this(user, null, filid, null)
        {

        }
    }
}
