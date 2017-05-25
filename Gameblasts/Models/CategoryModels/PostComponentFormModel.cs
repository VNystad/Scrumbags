namespace Gameblasts.Models.CategoryModels
{
    public class PostComponentFormModel
    {
        public PostComponentFormModel(int count, int parentID, bool topCat = false)
        {
            this.count = count;
            this.parentID = parentID;
            this.topCat = topCat;
        }

        public PostComponentFormModel(){}
        
        public int parentID {get; set;}

        public int count {get; set;}

        public bool topCat {get; set;}
    }
}