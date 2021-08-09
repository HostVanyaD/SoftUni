using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item testItem;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            testItem = new Item("Owner", "007");
        }

        [Test]
        public void Ctor_CreatesCollectionOfItems()
        {
            Assert.IsNotNull(bankVault.VaultCells);
        }

        [Test]
        public void Ctor_CreatesCollectionWithCountTwelve()
        {
            int expectedCount = 12;

            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddItem_ThrowsArgumentEx_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A0", testItem));
        }

        [Test]
        public void AddItem_ThrowsArgumentEx_WhenCellsValueIsNotEmpty()
        {
            bankVault.AddItem("A1", testItem);

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("Test", "1")));
        }

        [Test]
        public void AddItem_ThrowsInvalidOperationEx_WhenItemAlreadyExists()
        {
            bankVault.AddItem("A1", testItem);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", testItem));
        }

        [Test]
        public void AddItem_AddsItemToCollection()
        {
            bankVault.AddItem("A1", testItem);

            Item actualResult = bankVault.VaultCells["A1"];

            Assert.That(actualResult, Is.EqualTo(testItem));
        }

        [Test]
        public void AddItem_ReturnsCorrectResult()
        {           
            string expected = $"Item:{testItem.ItemId} saved successfully!";

            Assert.AreEqual(expected, bankVault.AddItem("A1", testItem));
        }

        [Test]
        public void RemoveItem_ThrowsArgumentEx_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A0", testItem));
        }

        [Test]
        public void RemoveItem_ThrowsArgumentEx_WhenCellIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", testItem));
        }

        [Test]
        public void RemoveItem_RemovesTheGivenItemFromTheCollection()
        {
            bankVault.AddItem("A1", testItem);
            bankVault.RemoveItem("A1", testItem);

            Assert.AreEqual(null, bankVault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItem_ReturnsCorrectResult()
        {
            bankVault.AddItem("A1", testItem);
            string expected = $"Remove item:{testItem.ItemId} successfully!";

            Assert.AreEqual(expected, bankVault.RemoveItem("A1", testItem));
        }
    }
}