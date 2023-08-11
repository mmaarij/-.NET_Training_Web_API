namespace DOTNET_Training.Models
{
    public class Category
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Category()
        {
            this.id = 0;
            this.name = string.Empty;
        }

        // Additional properties and methods specific to categories
    }
}
