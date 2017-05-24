namespace Gameblasts.Models.CategoryModels
{
    public class CategoryFormModel
    {
        public CategoryFormModel(string name, int parentID)
        {
            this.name = name;
            this.parentID = parentID;
        }

        public CategoryFormModel(){}
        
        public int parentID {get; set;}

        public string name {get; set;}
    }
}