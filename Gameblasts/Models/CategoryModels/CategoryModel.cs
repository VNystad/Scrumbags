using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gameblasts.Models.CategoryModels
{
    public class CategoryModel
    {
        public CategoryModel(string name, CategoryModel parent, List<CategoryModel> children, List<Post> threads)
        {
            this.name = name;
            this.parent = parent;
            this.children = children;
            this.threads = threads;
        }

        public CategoryModel(){}
        
        [KeyAttribute]
        [Required]
        public int id { get; set;}

        [Required]
        public string name {get; set;}

        public CategoryModel parent {get; set;}
                
        public virtual List<CategoryModel> children {get; set;}

        public virtual List<Post> threads {get; set;}
    }
}