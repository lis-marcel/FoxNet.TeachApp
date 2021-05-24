using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoxSky.TeachApp.Service
{
    class CategoryService
    {
        private DbStorageContext context;

        public CategoryService()
        {
        }

        public CategoryService(DbStorageContext context)
        {
            this.context = context;
        }

        private DbStorageContext GetContext()
        {
            if (context == null)
            {
                context = DbStorageFactory.GetInstance();
            }

            return context;
        }

        public int AddCategory(CategoryData categoryData)
        {
            var c = new Category() { CategoryName = categoryData.CategoryName };
            var db = GetContext();
            var res = db.Categories.Add(c);
            db.SaveChanges();

            return res.Entity.CategoryId;
        }

        public CategoryData GetCategory (int categoryId)
        {
            var db = GetContext();
            var category = db.Categories.SingleOrDefault(u => u.CategoryId== categoryId);

            return category != null ?
                new CategoryData() { CategoryId = category.CategoryId, CategoryName = category.CategoryName } :
                null;
        }

        public void EditCategory(CategoryData categoryData)
        {
            var db = GetContext();
            var category = db.Categories.SingleOrDefault(d => d.CategoryId == categoryData.CategoryId);

            if (category == null)
            {
                db.SaveChanges();
            }

            else
            {
                category.CategoryName = categoryData.CategoryName;
                db.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var db = GetContext();
            var res = db.Categories.Single(d => d.CategoryId == categoryId);
            db.Categories.Remove(res);

            db.SaveChanges();
        }
    }
}
