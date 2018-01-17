using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class CategoryDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
        public  List<Category> getCategoryList()
        {
            return context.Categories.ToList();
        }

        public void addCategory(string categoryId, string description)
        {
            Category category = new Category();

            category.categoryID = categoryId;
            category.description = description;

            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}