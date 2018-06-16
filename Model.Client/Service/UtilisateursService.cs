using C = Model.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Global.Service;
using Model.Client.Mapper;

namespace Model.Client.Service
{
    public class UtilisateursService
    {
        public IEnumerable<C.Utilisateurs> Get()
        {
            return ServiceGlobalLocator.Instance.Utilisateurs.Get().Select(a => a.ToClient());
        }
        public C.Utilisateurs Get(string password,string mail)
        {
            return ServiceGlobalLocator.Instance.Utilisateurs.Get(password,mail)?.ToClient();
        }
        public C.Utilisateurs Get(int? Userid)
        {
            return ServiceGlobalLocator.Instance.Utilisateurs.Get(Userid)?.ToClient();
        }
        public void Insert(C.Utilisateurs Entity)
        {
            ServiceGlobalLocator.Instance.Utilisateurs.Insert(Entity.ToGlobal());
        }
        public void Update(C.Utilisateurs Entity)
        {
            ServiceGlobalLocator.Instance.Utilisateurs.Update(Entity.ToGlobal());
        }
        public void Delete(C.Utilisateurs Entity)
        {
            ServiceClientLocator.Instance.Utilisateurs.Delete(Entity);
        }
    }
}
