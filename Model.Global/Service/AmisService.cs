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
    public class AmisService
    {
        public IEnumerable<Amis> Get()
        {
            Command cmd = new Command("SELECT * FROM Amis");
            return AccessLocator.Instance.Connect.ExecuteReader(cmd, c => c.ToAmis());
        }
        public void Insert(Amis Entity)
        {
            Command cmd = new Command("SP_AddAmis", true);
            cmd.AddParameter("UsersID", Entity.UsersID);
            cmd.AddParameter("AmisID", Entity.AmisID);
            cmd.AddParameter("IsAmis", Entity.IsAmis);
            cmd.AddParameter("Send", Entity.DemandeAmis);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public void Change(Amis Entity)
        {
            Command cmd = new Command("SP_ChangeStatus", true);
            cmd.AddParameter("UsersID", Entity.UsersID);
            cmd.AddParameter("AmisID", Entity.AmisID);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public void SuppFriend(Amis Entity)
        {
            Command cmd = new Command("SP_RemoveFriend", true);
            cmd.AddParameter("UsersID", Entity.UsersID);
            cmd.AddParameter("AmisID", Entity.AmisID);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public object Count(int? entity)
        {
            Command cmd = new Command("SELECT DemandeAmis FROM Amis WHERE UsersID = @Id GROUPE BY DemandeAmis");
            cmd.AddParameter("Id", entity);
            return (object)AccessLocator.Instance.Connect.ExecuteScalar(cmd);
        }
    }
}
