using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CategoryModels{

    public class TopCategoryModel
    {
        public TopCategoryModel(string name, List<SubCategoryModel> children)
        {
            this.name = name;
            this.children = children;
        }


        [KeyAttribute]
        [Required]
        public string name { get; set;}
        
        public List<SubCategoryModel> children {get; set;}
    }
}