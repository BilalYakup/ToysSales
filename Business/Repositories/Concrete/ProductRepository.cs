using Business.Repositories.InterfaceRepo;
using Data.Context;
using Data.Entities.Abstract;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyProductName(string name)
        {
            return await _context.Products.Where(x => x.Status != Status.Passive).AnyAsync(z => z.Name == name);
        }
    }
}
