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
            int count = books.Select(book => book.count).Sum();
            decimal originalPrice = count * 100;
            decimal discount = this.CalculateTotalDiscount(books);
            decimal salePrice = originalPrice - discount;

            return salePrice;
        }

        private decimal CalculateTotalDiscount(IEnumerable<Book> books)
        {
            var counts_EachBookToCalculateDiscount = books.Select(book => book.count);
            decimal discount = 0;

            discount =
              CalculateEachDiscountBy(DiscountOption.TwentyFive_PercentOff, counts_EachBookToCalculateDiscount)
            + CalculateEachDiscountBy(DiscountOption.Twenty_PercentOff, counts_EachBookToCalculateDiscount)
            + CalculateEachDiscountBy(DiscountOption.Ten_PercentOff, counts_EachBookToCalculateDiscount)
            + CalculateEachDiscountBy(DiscountOption.Five_PercentOff, counts_EachBookToCalculateDiscount);

            return discount;
        }

        private decimal CalculateEachDiscountBy(DiscountOption discountOption, IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            if (IsAnySet_of(discountOption, counts_EachBookToCalculateDiscount))
            {
                int sets_InDiscountCondition = CalculateSetsInDiscountCondition(counts_EachBookToCalculateDiscount);
                return (sets_InDiscountCondition) * GetDiscountPerSet(discountOption);
            }
            return 0;
        }

        private static int CalculateSetsInDiscountCondition(IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            return counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook != 0).Select(p => p).Min();
        }

        private int GetDiscountPerSet(DiscountOption discount)
        {
            switch (discount)
            {
                case DiscountOption.TwentyFive_PercentOff:
                    return 25 * 5;

                case DiscountOption.Twenty_PercentOff:
                    return 20 * 4;

                case DiscountOption.Five_PercentOff:
                    return 5 * 2;

                case DiscountOption.Ten_PercentOff:
                    return 10 * 3;

                default:
                    return 0;
            }
        }

        private static bool IsAnySet_of(DiscountOption discountOption, IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            int HowManyBookCount_Equals_Zero;

            switch (discountOption)
            {
                case DiscountOption.Five_PercentOff:
                    HowManyBookCount_Equals_Zero = 3;
                    break;

                case DiscountOption.Ten_PercentOff:
                    HowManyBookCount_Equals_Zero = 2;
                    break;

                case DiscountOption.Twenty_PercentOff:
                    HowManyBookCount_Equals_Zero = 1;
                    break;

                case DiscountOption.TwentyFive_PercentOff:
                    HowManyBookCount_Equals_Zero = 0;
                    break;

                default:
                    HowManyBookCount_Equals_Zero = 5;
                    break;
            }
            return counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook == 0).Select(p => p).Count() ==
                HowManyBookCount_Equals_Zero;
        }

        private enum DiscountOption
        {
            Five_PercentOff,
            Ten_PercentOff,
            Twenty_PercentOff,
            TwentyFive_PercentOff,
        }
    }
}