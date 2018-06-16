using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Entity
{
    public class Amis
    {
        public int? UsersID { get; set; }
        public int? AmisID { get; set; }
        public bool IsAmis { get; set; }
        public bool DemandeAmis { get; set; }

        public Amis(int? userid,int? amisid,bool isamis,bool demande)
        {
            UsersID = userid;
            AmisID = amisid;
            IsAmis = isamis;
            DemandeAmis = demande;
        }
        public Amis(int? userid,int?amisid):this(userid,amisid,false,false)
        {

        }
    }
}
