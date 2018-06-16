using System.Web.Mvc;

namespace Evaluation_ASPNET_TECHNOBOOK.Areas.Profil
{
    public class ProfilAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Profil";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Profil",
                url:"Profil/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
                //namespaces: new string[] { "Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Controllers"}
            );
        }
    }
}