using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IProductRepository :IRepository<Product>
    {
        void Remove(Product obj);
        void Update(Product obj);
        //   void Update(Models.CoverType obj);
    }
}
