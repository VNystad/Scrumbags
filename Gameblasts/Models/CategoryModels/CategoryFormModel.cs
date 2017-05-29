namespace Gameblasts.Models.CategoryModels
{
    public class CategoryFormModel
    {
        public CategoryFormModel(string name, int parentID, string imageURL = null)
        {
            this.name = name;
            this.parentID = parentID;
            this.imageURL = imageURL;
        }

        public CategoryFormModel(){}
        
        public int parentID {get; set;}

        public string name {get; set;}

        public string imageURL {get; set;}
    }
}