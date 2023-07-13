using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.InterfaceRepo
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        Task<bool> AnyProductName(string name);
    }
}
