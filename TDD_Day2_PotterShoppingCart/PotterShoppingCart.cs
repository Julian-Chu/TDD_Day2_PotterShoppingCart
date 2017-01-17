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

        public double CalculateSalePrice(IEnumerable<Book> books)
        {
            double pricePerBook = 100;
            int countOfBooks = books.Select(book => book.count).Sum();
            double discount = 0;
            discount = GetDiscountByCount(countOfBooks);

            double salePrice = countOfBooks * pricePerBook * discount;
            return salePrice;
        }

        private static double GetDiscountByCount(int countOfBooks)
        {
            double discount = 0;
            if (countOfBooks == 1)
                discount = 1;
            if (countOfBooks == 2)
                discount = 0.95;
            if (countOfBooks == 3)
                discount = 0.9;
            if (countOfBooks == 4)
                discount = 0.8;
            return discount;
        }
    }
}