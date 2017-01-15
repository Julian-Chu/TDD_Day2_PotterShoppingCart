using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PotterBookStore;

namespace PotterBookStoreTests
{
    [TestClass]
    public class PotterShoppingCartTests
    {
        [TestMethod]
        
        public void CalculateSalePriceTest_Scenario1_Potter1x1_Returns_100()
        {
            //Assign
            var books = GetBooks(1, 0, 0, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSalePriceTest_Scenario2_Potter1x1_Potter2x1_Returns_190()
        {
            //Assign
            var books = GetBooks(1, 1, 0, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 190;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSalePriceTest_Scenario3_Potter1x1_Potter2x1_Potter3x1_Returns_270()
        {
            //Assign
            var books = GetBooks(1, 1, 1, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 270;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSalePriceTest_Scenario4_Potter1x1_Potter2x1_Potter3x1_Potter4x1_Returns_320()
        {
            //Assign
            var books = GetBooks(1, 1, 1, 1, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 320;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSalePriceTest_Scenario5_Potter1x1_Potter2x1_Potter3x1_Potter4x1_Potter5x1_Returns_375()
        {
            //Assign
            var books = GetBooks(1, 1, 1, 1, 1);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 375;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSalePriceTest_Scenario6_Potter1x1_Potter2x1_Potter3x2_Returns_370()
        {
            //Assign
            var books = GetBooks(1, 1, 2, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 370;
            Assert.AreEqual(expected, actual);
        }
        private IEnumerable<Book> GetBooks(int countOfPotter1, int countOfPotter2, int countOfPotter3, int countOfPotter4, int countOfPotter5)
        {
            return new List<Book> {
                new Book { count=countOfPotter1 },
                new Book { count=countOfPotter2 },
                new Book { count=countOfPotter3 },
                new Book { count=countOfPotter4 },
                new Book { count=countOfPotter5 }
            };
        }
    }
}