using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryModels;
using Gameblasts.Data;
using Microsoft.AspNetCore.Mvc;

namespace ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public CategoryViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string topCatName)
        {
            
            //var topCat = db.topCategories.Where(s => s.name.Equals(topCatName));
            
            var topCat = await db.topCategories.FindAsync(topCatName);  

/*
            var topCat1 = new CategoryModels.TopCategoryModel(topCat.name, new List<CategoryModels.SubCategoryModel>());

            var SubCat1 = new CategoryModels.SubCategoryModel("SubCat1", topCat1, null);
            var SubCat2 = new CategoryModels.SubCategoryModel("SubCat1", topCat1, null);
            var SubCat3 = new CategoryModels.SubCategoryModel("SubCat1", topCat1, null);
            topCat1.children.Add(SubCat1);
            topCat1.children.Add(SubCat2);
            topCat1.children.Add(SubCat3);
  */          
            return View(topCat);
        }
    }
}