using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category Add(string name, int parendId);
        IQueryable<Category> GetAll();
        void Remove(int id);
        Category GetById(int id);
        //Category Update(Category category);
        int SaveChange();

    }
}
