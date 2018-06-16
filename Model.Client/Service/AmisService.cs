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
    public class AmisService
    {
        public IEnumerable<C.Amis> Get()
        {
            return ServiceGlobalLocator.Instance.Amis.Get().Select(a => a.ToClient());
        }
        public void Insert(C.Amis Entity)
        {
           ServiceGlobalLocator.Instance.Amis.Insert(Entity.ToGlobal());
        }
        public void Change(C.Amis Entity)
        {
            ServiceGlobalLocator.Instance.Amis.Change(Entity.ToGlobal());
        }
        public void SuppFriend(C.Amis Entity)
        {
            ServiceGlobalLocator.Instance.Amis.SuppFriend(Entity.ToGlobal());
        }
        public object Count(int? entity)
        {
           return ServiceGlobalLocator.Instance.Amis.Count(entity);
        }
    }
}
