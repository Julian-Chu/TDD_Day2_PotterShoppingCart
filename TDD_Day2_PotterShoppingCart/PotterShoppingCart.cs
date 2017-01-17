using System.Collections.Generic;
using System.Linq;

namespace PotterBookStore
{
    public class PotterShoppingCart
    {
        private Dictionary<int, double> _discountByCountOfBooks;

        public PotterShoppingCart()
        {
            _discountByCountOfBooks = new Dictionary<int, double>()
            {
                { 1,1 },
                { 2,0.95 },
                { 3,0.9 },
                { 4,0.8 },
                { 5,0.75 }
            };
        }

        public double CalculateSalePrice(IEnumerable<Book> books)
        {
            double pricePerBook = 100;
            int countOfBooks = books.Select(book => book.count).Sum();
            double discount = 1;
            discount = _discountByCountOfBooks[countOfBooks];

            double salePrice = countOfBooks * pricePerBook * discount;
            return salePrice;
        }

    }
}