namespace PotterBookStore
{
    public class Book
    {
        private string _name;
        public int Count { get; set; }
        public string Name { get { return _name; } }

        public Book(string name, int count=0)
        {
            _name = name;
            Count = count;
        }
    }
}