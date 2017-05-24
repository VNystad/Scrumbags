using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.CategoryModels
{
    public class CategoryModel
    {
        public CategoryModel(string name, CategoryModel parent)
        {
            this.name = name;
            this.parent = parent;
            this.children = new List<CategoryModel>();
            this.threads = new List<Post>();
        }

        public CategoryModel(){}
        
        [KeyAttribute]
        [Required]
        public int id { get; set;}

        public string name {get; set;}

        public CategoryModel parent {get; set;}
                
        public List<CategoryModel> children {get; set;}

        public List<Post> threads {get; set;}
    }
}   