namespace BookCatalog.Logic.Models
{
    public class Genre
    {
        private int id;
        private string name;
        private string description;

        public Genre() { }

        public Genre(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public int GetId()
        {
            return id;
        }
        public void SetId(int value)
        {
            id = value;
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string value)
        {
            name = value;
        }

        public string GetDescription()
        {
            return description;
        }
        public void SetDescription(string value)
        {
            description = value;
        }
    }
}


