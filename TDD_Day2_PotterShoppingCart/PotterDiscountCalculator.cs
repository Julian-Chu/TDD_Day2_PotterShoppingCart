using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterBookStore
{
    public class PotterDiscountCalculator
    {
        internal decimal CalculateTotalDiscount(IEnumerable<Book> books)
        {
            var counts_ForEachBook = books.Select(book => book.Count);

            decimal[] discounts = new decimal[5] { 0, 0, 0, 0, 0 };

            // ex: counts_ForEach={1,1,1,1,1},   zerosIn_counts=0.
            // ex: counts_ForEach={1,0,1,0,0},   zerosIn_counts=3,
            for (int zerosIn_counts = 0; zerosIn_counts < discounts.Count(); zerosIn_counts++)
            {
                int SetsByDiscount = 0;
                decimal discountPerSet = 0;
                if (counts_ForEachBook.Where(countOfBook => countOfBook == 0).Count() == zerosIn_counts)
                {
                    SetsByDiscount = counts_ForEachBook.Where(countOfBook => countOfBook != 0).Select(count_NotZero => count_NotZero).Min();
                    counts_ForEachBook = counts_ForEachBook.Select(countOfBook => (countOfBook == 0) ? 0 : countOfBook - SetsByDiscount);
                }
                switch (zerosIn_counts)
                {
                    case (int)DiscountOption.TwentyFive_PercentOff:
                        discountPerSet = 5 * 25;
                        break;
                    case (int)DiscountOption.Twenty_PercentOff:
                        discountPerSet = 4 * 20;
                        break;
                    case (int)DiscountOption.Ten_PercentOff:
                        discountPerSet = 3 * 10;
                        break;
                    case (int)DiscountOption.Five_PercentOff:
                        discountPerSet = 2 * 5;
                        break;
                    default:
                        discountPerSet = 0;
                        break;
                }
                discounts[zerosIn_counts] = SetsByDiscount * discountPerSet;
            }
            return discounts.Sum();
        }

        private enum DiscountOption
        {
            TwentyFive_PercentOff,
            Twenty_PercentOff,
            Ten_PercentOff,
            Five_PercentOff,
        }


    }
}