using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Dummy deadDummy;
    private int health = 5;
    private int experience = 5;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
        deadDummy = new Dummy(0, experience);
    }

    [Test]
    public void ConstructorIsWorkingProperly()
    {
        Assert.That(health, Is.EqualTo(dummy.Health), "Health is not set correctly");
    }

    [Test]
    public void When_Attacked_ShouldLooseHealth()
    {
        int attackPoints = 3;
        dummy.TakeAttack(attackPoints);

        Assert.That(health - attackPoints, Is.EqualTo(dummy.Health), "Health doesn't decrease when dummy is attacked");
    }

    [Test]
    public void When_AttackedDead_ThrowsInvalidOperationException()
    {
        int attackPoints = 10;

        Assert.That(() =>
        { deadDummy.TakeAttack(attackPoints); },
        Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead.")
        );
    }

    [Test]
    public void When_HealthIsEqualToZero_ShouldBeDead()
    {
        Assert.That(deadDummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
    }

    [Test]
    public void AliveDummyCanNotGiveExperience()
    {
        Assert.That(() =>
        { dummy.GiveExperience(); },
        Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead.")
        );
    }
}
