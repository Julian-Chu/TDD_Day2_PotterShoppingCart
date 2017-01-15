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
            int count=0;
            foreach(var book in books)
            {
                count += book.count;
            }
            decimal originalPrice = count * 100;
            decimal discount = this.CalculateDiscount(books);
            decimal salePrice = originalPrice - discount;

            return salePrice;
        }

        private decimal CalculateDiscount(IEnumerable<Book> books)
        {
            var countOfEachBook = books.Select(p=>p.count);
            decimal discount = 0;
            if( countOfEachBook.Where(p=>p==0).Select(p=>p).Count()==3)
            {
                var groupSize_5_Percent_discount = countOfEachBook.Where(countOfBook => countOfBook != 0).Select(p=>p).Min();
                discount += (groupSize_5_Percent_discount) * 2 * 5;
            }


            return discount;
        }

    }
}