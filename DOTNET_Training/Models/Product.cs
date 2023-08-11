namespace DOTNET_Training.Models
{
    public class Product
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

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private int stockQuantity;
        public int StockQuantity
        {
            get { return stockQuantity; }
            set { stockQuantity = value; }
        }

        private Category category;
        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public Product()
        {
            this.id = 0;
            this.name = string.Empty;
            this.description = string.Empty;
            this.price = 0;
            this.stockQuantity = 0;
            this.category = null;
        }
    }
}
