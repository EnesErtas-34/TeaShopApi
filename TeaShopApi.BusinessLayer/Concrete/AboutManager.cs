using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> TGetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void TInsert(About entity)
        {
           _aboutDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
