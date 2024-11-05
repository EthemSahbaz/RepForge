using FluentAssertions;
using RepForge.Domain.Shared;

namespace RepForge.Domain.UnitTests.Shared;
public class NameTests
{
    [Fact]
    public void Name_With_NullValue_Should_Return_FailureResult()
    {
        var name = Name.Create(null);

        name.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Name_With_EmptyString_Should_Return_FailureResult()
    {
        var name = Name.Create(string.Empty);

        name.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void Name_With_WhiteSpace_Should_Return_FailureResult()
    {
        var name = Name.Create("   ");

        name.IsFailure.Should().BeTrue();
    }
}
