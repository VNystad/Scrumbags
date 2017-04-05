using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gameblasts.Models;

namespace CategoryModels
{
    public class SubCategoryModel
    {
        public SubCategoryModel(string name, TopCategoryModel parent, List<Post> threads)
        {
            this.name = name;
            this.parent = parent;
            this.threads = threads;
        }

        public SubCategoryModel(){}
        
        [KeyAttribute]
        [Required]
        public string name {get; set;}

        [KeyAttribute]
        [Required]
        public TopCategoryModel parent {get; set;}
        
        
        public List<Post> threads {get; set;}
    }
}