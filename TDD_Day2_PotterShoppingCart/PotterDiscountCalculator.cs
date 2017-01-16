using System.Collections.Generic;
using System.Linq;

namespace PotterBookStore
{
    public class PotterDiscountCalculator
    {
        internal decimal CalculateTotalDiscount(IEnumerable<Book> books)
        {
            var counts_EachBookToCalculateDiscount = books.Select(book => book.Count);
            decimal discount = 0;

            var discount_25off = CalculateEachDiscountBy(CreatePotterDiscount(DiscountOption.TwentyFive_PercentOff), ref counts_EachBookToCalculateDiscount);
            var discount_20off = CalculateEachDiscountBy(CreatePotterDiscount(DiscountOption.Twenty_PercentOff), ref counts_EachBookToCalculateDiscount);
            var discount_10off = CalculateEachDiscountBy(CreatePotterDiscount(DiscountOption.Ten_PercentOff), ref counts_EachBookToCalculateDiscount);
            var discount_5off = CalculateEachDiscountBy(CreatePotterDiscount(DiscountOption.Five_PercentOff), ref counts_EachBookToCalculateDiscount);

            discount = discount_25off + discount_20off + discount_10off + discount_5off;
            return discount;
        }

        /// <summary>
        /// Example:
        /// if books={2,3,4,5,6}  ,
        /// CalculateEachDiscountBy(DiscountOption.TwentyFive_PercentOff) will take 2 sets of {1,1,1,1,1} from books,
        /// new books={0,1,2,3,4},
        /// discount= 2(sets of {1,1,1,1,1}) * 5(book different) * 100(original price) *0.25 (discount) =250
        ///
        /// </summary>
        /// <param name="discountOption"></param>
        /// <param name="counts_EachBookToCalculateDiscount"></param>
        /// <returns></returns>
        private decimal CalculateEachDiscountBy(PotterDiscount potterDiscount, ref IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            if (IsAnySet_of(potterDiscount, counts_EachBookToCalculateDiscount))
            {
                int sets_InDiscountCondition = CalculateSetsInDiscountCondition(ref counts_EachBookToCalculateDiscount);
                return (sets_InDiscountCondition) * potterDiscount.DiscountPerSet;
            }
            return 0;
        }

        private static int CalculateSetsInDiscountCondition(ref IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            var calculatedSets = counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook != 0).Select(p => p).Min();
            counts_EachBookToCalculateDiscount = counts_EachBookToCalculateDiscount.Select(p => (p == 0) ? p : p - calculatedSets);
            return calculatedSets;
        }

        private static bool IsAnySet_of(PotterDiscount potterDiscount, IEnumerable<int> counts_EachBookToCalculateDiscount)
        {
            return counts_EachBookToCalculateDiscount.Where(countOfBook => countOfBook == 0).Select(p => p).Count() ==
                potterDiscount.HowManyBookCount_Equals_Zero;
        }

        private enum DiscountOption
        {
            Five_PercentOff,
            Ten_PercentOff,
            Twenty_PercentOff,
            TwentyFive_PercentOff,
        }

        private PotterDiscount CreatePotterDiscount(DiscountOption discountOption)
        {
            switch (discountOption)
            {
                case DiscountOption.Five_PercentOff:
                    return new PotterDiscount { DiscountPerSet = 5 * 2, HowManyBookCount_Equals_Zero = 3 };

                case DiscountOption.Ten_PercentOff:
                    return new PotterDiscount { DiscountPerSet = 10 * 3, HowManyBookCount_Equals_Zero = 2 };

                case DiscountOption.Twenty_PercentOff:
                    return new PotterDiscount { DiscountPerSet = 20 * 4, HowManyBookCount_Equals_Zero = 1 };

                case DiscountOption.TwentyFive_PercentOff:
                    return new PotterDiscount { DiscountPerSet = 25 * 5, HowManyBookCount_Equals_Zero = 0 };

                default:
                    return new PotterDiscount { DiscountPerSet = 0, HowManyBookCount_Equals_Zero = 5 };
            }
        }
    }
}