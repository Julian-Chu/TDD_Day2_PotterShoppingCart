using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PotterBookStore;

namespace PotterBookStoreTests
{
    [TestClass]
    public class PotterShoppingCartTests
    {
        [TestMethod]
        
        public void CalculateTotalPriceTest_Scenario1_Potter1x1_Returns_100()
        {
            //Assign
            var books = GetBooks(1, 0, 0, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateTotalPrice(books);

            //Assert
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateTotalPriceTest_Scenario2_Potter1x1_Potter2x1_Returns_190()
        {
            //Assign
            var books = GetBooks(1, 1, 0, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateTotalPrice(books);

            //Assert
            var expected = 190;
            Assert.AreEqual(expected, actual);
        }

        private IEnumerable<Book> GetBooks(int v1, int v2, int v3, int v4, int v5)
        {
            return new List<Book> {
                new Book { count=v1 },
                new Book { count=v2 },
                new Book { count=v3 },
                new Book { count=v4 },
                new Book { count=v5 }
            };
        }
    }
}