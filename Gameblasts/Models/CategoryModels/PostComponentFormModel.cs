namespace Gameblasts.Models.CategoryModels
{
    public class PostComponentFormModel
    {
        public PostComponentFormModel(int count, int parentID)
        {
            this.count = count;
            this.parentID = parentID;
        }

        public PostComponentFormModel(){}
        
        public int parentID {get; set;}

        public int count {get; set;}
    }
}