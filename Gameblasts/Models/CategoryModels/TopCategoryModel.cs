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
        public TopCategoryModel(){}


        [KeyAttribute]
        [Required]
        public string name { get; set;}
        
        [Required]
        public List<SubCategoryModel> children {get; set;}
    }
}