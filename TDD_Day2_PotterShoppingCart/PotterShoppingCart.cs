using System.Collections.Generic;
using System.Linq;

namespace PotterBookStore
{
    public class PotterShoppingCart
    {
        private Dictionary<int, double> _discountByHowManyBooksInASet;

        public PotterShoppingCart()
        {
            _discountByHowManyBooksInASet = new Dictionary<int, double>()
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
            int oneSet = 1;

            int countOfBooks = books.Sum(book => book.count);
            var countsOfEachBook = books.Select(book => book.count);

            int howManyBooksInASet = countsOfEachBook.Where(BookCountMoreThanZero()).Count();
            double salePriceOfASet = howManyBooksInASet * oneSet * pricePerBook * _discountByHowManyBooksInASet[howManyBooksInASet];

            int booksCountNoDiscount = countOfBooks - howManyBooksInASet;
            double salePriceofNoSet = booksCountNoDiscount * pricePerBook;

            double salePrice = salePriceOfASet + salePriceofNoSet;
            return salePrice;
        }

        private static System.Func<int, bool> BookCountMoreThanZero()
        {
            return bookCount => bookCount > 0;
        }


    }
}