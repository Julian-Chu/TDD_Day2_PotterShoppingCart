﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void CalculateSalePriceTest_Scenario4_Potter1x1_Potter2x1_Potter3x1_Returns_Potter4x1_320()
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

        [TestMethod]
        public void CalculateSalePriceTest_Scenario7_Potter1x1_Potter2x2_Potter3x2_Returns_460()
        {
            //Assign
            var books = GetBooks(1, 2, 2, 0, 0);
            var shoppingCart = new PotterShoppingCart();

            //Act
            var actual = shoppingCart.CalculateSalePrice(books);

            //Assert
            var expected = 460;
            Assert.AreEqual(expected, actual);

        }

        private IEnumerable<Book> GetBooks(int Potter1, int Potter2, int Potter3, int Potter4, int Potter5)
        {
            return new List<Book> {
                new Book("Potter1") { count=Potter1 },
                new Book("Potter2") { count=Potter2 },
                new Book("Potter3") { count=Potter3 },
                new Book("Potter4") { count=Potter4 },
                new Book("Potter5") { count=Potter5 }
            };
        }
    }
}