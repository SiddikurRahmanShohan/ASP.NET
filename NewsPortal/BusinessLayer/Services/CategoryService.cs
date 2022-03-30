using BusinessLayer.Entities;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Repo;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService
    {
        public static List<CategoryModel> Get()
        {
            var cats = FactoryDataAccess.CategoryDataAccess().Get();
            List<CategoryModel> data = new List<CategoryModel>();
            foreach (var c in cats)
            {
                data.Add(new CategoryModel() { CategoryId = c.CategoryId, CategoryName = c.CategoryName });

            }
            return data;

        }

        public static CategoryModel Get(int id)
        {
            var cat = FactoryDataAccess.CategoryDataAccess().Get(id);
            var c = new CategoryModel() { CategoryId = cat.CategoryId, CategoryName = cat.CategoryName };
            return c;

        }

        public static bool Edit(CategoryModel obj)
        {
            var UpdatedCat = new Category { CategoryId = obj.CategoryId, CategoryName = obj.CategoryName };
            var editc = FactoryDataAccess.CategoryDataAccess().Edit(UpdatedCat);
            return editc;

        }

        public static bool Delete(int id)
        {
            var msg = FactoryDataAccess.CategoryDataAccess().Delete(id);
            return msg;

        }
    }
}
