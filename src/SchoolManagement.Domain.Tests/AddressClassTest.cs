using FluentAssertions;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.Tests.ClassData;

namespace SchoolManagement.Domain.Tests;

public class AddressClassTest
{
    [Fact]
    public void Constructor_OnValidDataWithId_ReturnsAddress()
    {
        var address = new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "12345-678"
        );

        address.Should().NotBeNull();
        address.Should().BeAssignableTo<Address>();
    }

    [Fact]
    public void Constructor_OnValidDataWithoutId_ReturnsAddress()
    {
        var address = new Address(
            "Rua Jequitibá",
            "123",
            "Centro",
            "12345-678",
            "São Paulo",
            "SP",
            "apto 101"
        );
        address.Should().NotBeNull();
        address.Should().BeAssignableTo<Address>();
    }

    [Theory]
    [MemberData(nameof(BrazilianStates))]
    public void Constructor_OnAnyBrazilianState_R(string state)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "12345-678",
            "São Paulo",
            state
        );

        act.Should().NotBeNull();
        act.Should().NotThrow<DomainException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_Not_Create_Address_With_Invalid_Id(int id)
    {
        var act = () => new Address(
            id,
            "Rua Jequitibá",
            "123",
            "Centro",
            "012345-678",
            "São Paulo",
            "SP",
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Address_With_Invalid_Street(string street)
    {
        var act = () => new Address(
            1,
            street,
            "123",
            "Centro",
            "012345-678",
            "São Paulo",
            "SP",
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [MemberData(nameof(InvalidAddressNumbers))]
    public void Should_Not_Create_Address_With_Invalid_Number(string number)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            number,
            "Centro",
            "012345-678",
            "São Paulo",
            "SP",
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Address_With_Invalid_District(string district)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            district,
            "012345-678",
            "São Paulo",
            "SP",
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Address_With_Invalid_City(string city)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "012345-678",
            city,
            "SP",
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Address_With_Invalid_State(string state)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "012345-678",
            "São Paulo",
            state,
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [InlineData("123456-789")]
    [InlineData("1234-567")]
    [InlineData("1234-5678")]
    [InlineData("123456789")]
    [InlineData("1234567")]
    [InlineData("12345678")]
    [InlineData("1234567a")]
    public void Should_Not_Create_Address_With_Invalid_ZipCode(string zipCode)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            zipCode,
            "São Paulo",
            "SP",
            "Apto 101"
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [MemberData(nameof(InvalidAddressComplements))]
    public void Should_Not_Create_Address_With_Invalid_Street2(string street2)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "012345-678",
            "São Paulo",
            "SP",
            street2
        );

        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Should_Be_Able_To_Update_Address_Data_With_Same_Id()
    {
        var address = new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "01234-567",
            "São Paulo",
            "SP",
            "Apto 101"
        );

        address.Update("Rua Beija-Flor",
            "456",
            "Jardins",
            "02345-678",
            "Belo Horizonte",
            "MG",
            "Apto 202");

        address.Id.Should().Be(1);
        address.Street.Should().Be("Rua Beija-Flor");
        address.Number.Should().Be("456");
        address.District.Should().Be("Jardins");
        address.City.Should().Be("Belo Horizonte");
        address.State.Should().Be("MG");
        address.ZipCode.Should().Be("02345-678");
        address.Street2.Should().Be("Apto 202");
    }

    private static IEnumerable<object[]> BrazilianStates()
    {
        return new[]
        {
            new object[] { "AC" }, new object[] { "AL" }, new object[] { "AP" }, new object[] { "AM" },
            new object[] { "BA" }, new object[] { "CE" }, new object[] { "DF" }, new object[] { "ES" },
            new object[] { "GO" }, new object[] { "MA" }, new object[] { "MT" }, new object[] { "MS" },
            new object[] { "MG" }, new object[] { "PA" }, new object[] { "PB" }, new object[] { "PR" },
            new object[] { "PE" }, new object[] { "PI" }, new object[] { "RJ" }, new object[] { "RN" },
            new object[] { "RS" }, new object[] { "RO" }, new object[] { "RR" }, new object[] { "SC" },
            new object[] { "SP" }, new object[] { "SE" }, new object[] { "TO" }
        };
    }

    private static IEnumerable<object[]> InvalidAddressNumbers()
    {
        return new[]
        {
            new object[] { "" }, new object[] { " " }, new object[] { null! },
            new object[] { new string('a', 10 + 1) }
        };
    }

    private static IEnumerable<object[]> InvalidAddressComplements()
    {
        return new[] { new object[] { new string('a', 50 + 1) } };
    }
}
