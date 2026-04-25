using KH4;
using NUnit.Framework;

namespace KH4.UnitTests;

[TestFixture]
public class PasswordValidatorTests
{
    private PasswordValidator _validator = null!;

    [SetUp]
    public void SetUp()
    {
        _validator = new PasswordValidator();
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("short7")]
    [TestCase("nodigits")]
    [TestCase("12345678")]
    public void IsPasswordStrong_ShouldReturnFalse_ForInvalidPasswords(string? password)
    {
        var result = _validator.IsPasswordStrong(password!);

        Assert.That(result, Is.False);
    }

    [TestCase("Password1")]
    [TestCase("StrongPass123")]
    [TestCase("A1b2c3d4")]
    public void IsPasswordStrong_ShouldReturnTrue_ForValidPasswords(string password)
    {
        var result = _validator.IsPasswordStrong(password);

        Assert.That(result, Is.True);
    }
}
