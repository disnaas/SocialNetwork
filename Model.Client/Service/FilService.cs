using Model.Client.Entity;
using Model.Client.Mapper;
using Model.Global.Service;
using System.Collections.Generic;
using System.Linq;

namespace Model.Client.Service
{
    public class FilService
    {
        public IEnumerable<Fil> Get()
        {
            return ServiceGlobalLocator.Instance.Fil.Get().Select(c => c.ToClient());
        }

        public void Insert(Fil Entity)
        {
            ServiceGlobalLocator.Instance.Fil.Insert(Entity.ToGlobal());
        }
        public void Update(Fil Entity)
        {
            ServiceGlobalLocator.Instance.Fil.Update(Entity.ToGlobal());
        }
        public void Delete(Fil Entity)
        {
            ServiceGlobalLocator.Instance.Fil.Delete(Entity.ToGlobal());
        }
    }
}
