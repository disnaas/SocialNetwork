using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBoxNET.Pattern.Locator;

namespace Model.Client.Service
{
    public class ServiceClientLocator : LocatorBase
    {
        private static ServiceClientLocator _Instance;
        public static ServiceClientLocator Instance
        {
            get { return _Instance ?? (_Instance = new ServiceClientLocator()); }
        }

        public ServiceClientLocator()
        {
            Container.Register<UtilisateursService>();
            Container.Register<FilService>();
            Container.Register<AmisService>();
        }
        public UtilisateursService Utilisateurs
        {
            get { return Container.GetInstance<UtilisateursService>(); }
        }
        public FilService Fil
        {
            get { return Container.GetInstance<FilService>(); }
        }
        public AmisService Amis
        {
            get { return Container.GetInstance<AmisService>(); }
        }
    }
}
