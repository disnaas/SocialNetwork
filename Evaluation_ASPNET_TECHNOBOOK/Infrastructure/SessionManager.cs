using Model.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evaluation_ASPNET_TECHNOBOOK.Infrastructure
{
    public static class SessionManager
    {
        public static Utilisateurs Users
        {
            get { return (Utilisateurs)HttpContext.Current.Session["UtilisateursForm"]; }
            set { HttpContext.Current.Session["UtilisateursForm"] = value; }
        }
    }
}