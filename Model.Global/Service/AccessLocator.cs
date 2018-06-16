using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBoxNET.Connection.Database;
using ToolBoxNET.Pattern.Locator;

namespace Model.Global.Service
{
    public class AccessLocator : LocatorBase
    {
        private static AccessLocator _Instance;
        public static AccessLocator Instance
        {
            get { return _Instance ?? (_Instance = new AccessLocator()); }
        }

        private const string Provider = @"system.data.sqlclient";
        private const string CONNEXION_STRING = @"Server=DESKTOP-IRE6555\SQLEXPRESS;Database=Technobook;Trusted_Connection=True;";

        public AccessLocator()
        {
            Container.Register<Connection>(Provider, CONNEXION_STRING);
        }

        public Connection Connect
        {
            get { return Container.GetInstance<Connection>(); }
        }

    }
}
