﻿using System.Collections.Generic;
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
            int count = books.Select(book => book.count).Sum();
            decimal originalPrice = count * 100;
            decimal discount = this.CalculateDiscount(books);
            decimal salePrice = originalPrice - discount;

            return salePrice;
        }

        private decimal CalculateDiscount(IEnumerable<Book> books)
        {
            var counts_EachBookToCalculateDiscount = books.Select(book => book.count);
            decimal discount = 0;

            if (IsAnySet_PercentDiscount(counts_EachBookToCalculateDiscount, Discount.Ten_PercentOff))
            {
                int sets_InDiscountCondition = CalculateSetsInDiscountCondition(counts_EachBookToCalculateDiscount);
                discount += (sets_InDiscountCondition) * GetDiscountPerSet(Discount.Ten_PercentOff);
            }

            if (IsAnySet_PercentDiscount(counts_EachBookToCalculateDiscount, Discount.Five_PercentOff))
            {
                var groupSize_5_Percent_discount = counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook != 0).Select(p => p).Min();
                discount += (groupSize_5_Percent_discount) * 2 * 5;
            }

            return discount;
        }

        private int GetDiscountPerSet(Discount discount)
        {
            switch (discount)
            {
                case Discount.Five_PercentOff:
                    return 5 * 2;

                case Discount.Ten_PercentOff:
                    return 10 * 3;

                default:
                    return 0;
            }
        }

        private static int CalculateSetsInDiscountCondition(IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            return counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook != 0).Select(p => p).Min();
        }

        private static bool IsAnySet_PercentDiscount(IEnumerable<int> counts_EachBookToCalculateDiscount, Discount discountOption)
        {
            int HowManyBookCount_Equals_Zero;

            switch (discountOption)
            {
                case Discount.Five_PercentOff:
                    HowManyBookCount_Equals_Zero = 3;
                    break;

                case Discount.Ten_PercentOff:
                    HowManyBookCount_Equals_Zero = 2;
                    break;

                default:
                    HowManyBookCount_Equals_Zero = 5;
                    break;
            }
            return counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook == 0).Select(p => p).Count() ==
                HowManyBookCount_Equals_Zero;
        }

        private enum Discount
        {
            Five_PercentOff,
            Ten_PercentOff,
        }
    }
}