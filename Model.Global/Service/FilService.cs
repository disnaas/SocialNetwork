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
    public class FilService
    {
        public IEnumerable<Fil> Get()
        {
            Command cmd = new Command("SELECT * FROM Fil ORDER BY DateLigne DESC");
            return AccessLocator.Instance.Connect.ExecuteReader(cmd, c => c.ToFil());
        }
        public void Insert(Fil Entity)
        {
            Command cmd = new Command("SP_AddFil", true);
            cmd.AddParameter("UsersID", Entity.UsersID);
            cmd.AddParameter("Text", Entity.Text);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public void Update(Fil Entity)
        {
            Command cmd = new Command("SP_ModifFeed", true);
            cmd.AddParameter("Id", Entity.FilID);
            cmd.AddParameter("UsersID", Entity.UsersID);
            cmd.AddParameter("Text", Entity.Text);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
        public void Delete(Fil Entity)
        {
            Command cmd = new Command("SP_RemoveFeed", true);
            cmd.AddParameter("UsersID", Entity.UsersID);
            cmd.AddParameter("ID", Entity.FilID);
            AccessLocator.Instance.Connect.ExecuteNonQuery(cmd);
        }
    }
}
