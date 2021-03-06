﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBoxNET.Pattern.Locator;

namespace Model.Global.Service
{
    public class ServiceGlobalLocator : LocatorBase
    {
        private static ServiceGlobalLocator _Instance;
        public static ServiceGlobalLocator Instance
        {
            get { return _Instance ?? (_Instance = new ServiceGlobalLocator()); }
        }

        public ServiceGlobalLocator()
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
