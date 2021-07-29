using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        
        [Test]
        public void CountProp_ShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("ValidName", 20, 100);

            int expextedResult = 1;
            this.arena.Enroll(warrior);

            Assert.AreEqual(expextedResult, this.arena.Count);
        }

        [Test]
        public void Ctor_ShouldWorkCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void Enroll_ThrowsInvalidOperationEx_WhenWarriorAlreadyExists()
        {
            Warrior warrior = new Warrior("ValidName", 50, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [Test]
        public void Enroll_ShouldAddWarriorToCollection()
        {
            Warrior warrior = new Warrior("ValidName", 20, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void Fight_ThrowsInvalidOperationEx_WhenWarriorsAreNotFound()
        {
            Warrior attacker = new Warrior("ValidName", 20, 100);
            Warrior defender = new Warrior("AnotherValidName", 30, 100);

            this.arena.Enroll(attacker);
            
            Assert.Throws<InvalidOperationException>(() =>
            this.arena.Fight(attacker.Name, defender.Name));
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior attacker = new Warrior("ValidName", 20, 100);
            Warrior defender = new Warrior("AnotherValidName", 30, 100);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            int expecdetAttackerHp = 70;
            int expecdetDefenderHp = 80;

            Assert.AreEqual(expecdetAttackerHp, attacker.HP);
            Assert.AreEqual(expecdetDefenderHp, defender.HP);
        }
    }
}
