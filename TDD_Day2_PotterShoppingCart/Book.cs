namespace PotterBookStore
{
    public class Book
    {
        private string _name;

        public int count { get; set; }
        public string Name { get { return _name; }  }

        public Book(string name)
        {
            _name = name;
        }
    }
}