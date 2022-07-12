using FluentAssertions;
using SchoolManagement.Domain.Models;
using SchoolManagement.Tests.ClassData;

namespace SchoolManagement.Tests;

public class AddressTest
{
    [Fact]
    public void Should_Create_New_Address_With_Required_Fields()
    {
        var address = new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            zipCode: "12345-678"
        );
        address.Should().NotBeNull();
    }

    [Theory]
    [MemberData(nameof(BrazilianStates))]
    public void Should_Create_Address_With_All_Brazilian_States(string state)
    {
        var address = new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "São Paulo",
            state,
            "12345-678"
        );
        address.Should().NotBeNull();
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
            "São Paulo",
            "SP",
            "012345-678",
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
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
            "São Paulo",
            "SP",
            "012345-678",
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Address_With_Invalid_Number(string number)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            number,
            "Centro",
            "São Paulo",
            "SP",
            "012345-678",
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
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
            "São Paulo",
            "SP",
            "012345-678",
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
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
            city,
            "SP",
            "012345-678",
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
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
            "São Paulo",
            state,
            "012345-678",
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("111111-111")]
    [InlineData("1111-111")]
    [InlineData("111111111")]
    [InlineData("1111111")]
    [InlineData("1234567a")]
    public void Should_Not_Create_Address_With_Invalid_ZipCode(string zipCode)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "São Paulo",
            "SP",
            zipCode,
            "Apto 101"
        );

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Address_With_Invalid_Street2(string street2)
    {
        var act = () => new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "São Paulo",
            "SP",
            "012345-678",
            street2
        );

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_Be_Able_To_Update_Address_Data_With_Same_Id()
    {
        var address = new Address(
            1,
            "Rua Jequitibá",
            "123",
            "Centro",
            "São Paulo",
            "SP",
            "01234-567",
            "Apto 101"
        );

        address.Update("Rua Beija-Flor",
            "456",
            "Jardins",
            "Belo Horizonte",
            "MG",
            "02345-678",
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
            new object[] { "AC" },
            new object[] { "AL" },
            new object[] { "AP" },
            new object[] { "AM" },
            new object[] { "BA" },
            new object[] { "CE" },
            new object[] { "DF" },
            new object[] { "ES" },
            new object[] { "GO" },
            new object[] { "MA" },
            new object[] { "MT" },
            new object[] { "MS" },
            new object[] { "MG" },
            new object[] { "PA" },
            new object[] { "PB" },
            new object[] { "PR" },
            new object[] { "PE" },
            new object[] { "PI" },
            new object[] { "RJ" },
            new object[] { "RN" },
            new object[] { "RS" },
            new object[] { "RO" },
            new object[] { "RR" },
            new object[] { "SC" },
            new object[] { "SP" },
            new object[] { "SE" },
            new object[] { "TO" }
        };
    }
}