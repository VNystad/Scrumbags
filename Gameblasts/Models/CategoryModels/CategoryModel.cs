using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.CategoryModels
{
    public class CategoryModel
    {
        public CategoryModel(string name, CategoryModel parent, string imageURL = null)
        {
            this.name = name;
            this.parent = parent;
            this.children = new List<CategoryModel>();
            this.threads = new List<Post>();
            this.imageURL = imageURL;
        }

        public CategoryModel(){}
        
        [KeyAttribute]
        [Required]
        public int id { get; set;}

        public string name {get; set;}

        public string imageURL {get; set;}

        public CategoryModel parent {get; set;}
                
        public List<CategoryModel> children {get; set;}

        public List<Post> threads {get; set;}
    }
}   