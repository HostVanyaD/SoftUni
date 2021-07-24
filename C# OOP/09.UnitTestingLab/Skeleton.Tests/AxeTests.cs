using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Axe brokenAxe;
    private int attackPoints = 7;
    private int durabilityPoints = 10;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attackPoints, durabilityPoints);
        brokenAxe = new Axe(attackPoints, 0);
        dummy = new Dummy(5, 5);
    }

    [Test]
    public void When_AxeIsCreated_Properties_ShouldBeSetCorrectly()
    {
        Assert.That(attackPoints, Is.EqualTo(axe.AttackPoints), "AttackPoints not set correctly");
        Assert.That(durabilityPoints, Is.EqualTo(axe.DurabilityPoints), "DurabilityPoints not set correctly");
    }

    [Test]
    public void When_Attack_Should_DropDurabilityPoints()
    {
        axe.Attack(dummy);

        Assert.That(durabilityPoints - 1, Is.EqualTo(axe.DurabilityPoints), "AxeDurability doesn't change after attack");
    }

    [Test]
    public void When_Attack_WithDurabilityPointsEqualToZero_ShouldThrowInvalidOperationException()
    {      
        Assert.That(() =>
        { brokenAxe.Attack(dummy); },
        Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken.")
        );
    }
}