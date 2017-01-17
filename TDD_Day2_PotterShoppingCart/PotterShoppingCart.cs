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
            double salePrice = 0;


            var countsOfEachBook = books.Select(book => book.count);
            while (countsOfEachBook.Sum() > 0)
            {
                int aSet = 1;
                int howManyBookInASet = countsOfEachBook.Where(countOfBookMoreThanZero()).Count();
                salePrice += howManyBookInASet * aSet * pricePerBook * _discountByHowManyBooksInASet[howManyBookInASet];
                countsOfEachBook = RemoveCalculatedCounts(countsOfEachBook);
            }

            return salePrice;
        }

        #region --Comments are described by methods--
        private static System.Func<int, bool> countOfBookMoreThanZero()
        {
            return countOfBook => countOfBook > 0;
        }

        private IEnumerable<int> RemoveCalculatedCounts(IEnumerable<int> countsOfEachBook)
        {
            return countsOfEachBook.Select(count => count > 0 ? count - 1 : count);
        }
        #endregion
    }
}