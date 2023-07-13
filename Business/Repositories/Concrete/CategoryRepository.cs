using Business.Repositories.InterfaceRepo;
using Data.Context;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context):base(context) 
        {
            _context = context;
        }
        public async Task<bool> AnyCategoryName(string name)
        {
            return await _context.Categories.Where(x => x.Status != Data.Entities.Abstract.Status.Passive).AnyAsync(z=>z.Name==name);
        }
    }
}
