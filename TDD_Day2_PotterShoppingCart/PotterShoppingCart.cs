using System.Collections.Generic;
using System.Linq;

namespace PotterBookStore
{
    public class PotterShoppingCart
    {
        private PotterDiscountCalculator _discountCalculator = null;
        public PotterShoppingCart()
        {
        }

        public PotterShoppingCart(PotterDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public decimal CalculateSalePrice(IEnumerable<Book> books)
        {
            int count = books.Select(book => book.Count).Sum();
            decimal originalPrice = count * 100;
            decimal discount =  _discountCalculator==null? 0 : _discountCalculator.CalculateTotalDiscount(books);

            decimal salePrice = originalPrice - discount;

            return salePrice;
        }


    }
}