using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterBookStore
{
    public class PotterShoppingCart
    {
        public PotterShoppingCart()
        {
        }

        public decimal CalculateSalePrice(IEnumerable<Book> books)
        {
            decimal pricePerBook = 100;
            int countOfBooks = books.Select(book => book.count).Sum();

            decimal salePrice= countOfBooks * pricePerBook;
            return salePrice;
        }
    }
}