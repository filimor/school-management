using FluentAssertions;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.Tests.ClassData;

namespace SchoolManagement.Domain.Tests;

public class StudentTest
{
    [Fact]
    public void Constructor_OnValidDataWithId_ReturnsStudent()
    {
        // Act
        var student = new Student(
            1,
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        // Assert
        student.Should().NotBeNull();
        student.Should().BeAssignableTo<Student>();
    }

    [Fact]
    public void Constructor_OnValidDataWithoutId_ReturnsStudent()
    {
        // Act
        var student = new Student(
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        // Assert
        student.Should().NotBeNull();
        student.Should().BeAssignableTo<Student>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_OnInvalidId_ThrowsDomainException(int id)
    {
        // Act
        var act = () => new Student(
            id,
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        // Assert
        act.Should().Throw<DomainException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Constructor_OnInvalidName_ThrowsDomainException(string name)
    {
        // Act
        var act = () => new Student(
            1,
            name,
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        // Assert
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Constructor_OnInvalidBirthday_ThrowsDomainException()
    {
        // Act
        var act = () => new Student(
            1,
            "Maria Aparecida Alcântara de Souza Ramos",
            DateTime.Now,
            Gender.CisWoman,
            SkinColor.Black
        );

        // Assert
        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Update_OnValidData_UpdatesObjectAttributes()
    {
        // Arrange
        var student = new Student(
            1,
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        // Act
        student.Update("José Ricardo Eugênio Matoso de Barros",
            new DateTime(2001, 2, 2),
            Gender.TransMan,
            SkinColor.Yellow);

        // Assert
        student.Id.Should().Be(1);
        student.Name.Should().Be("José Ricardo Eugênio Matoso de Barros");
        student.Birthday.Should().Be(new DateTime(2001, 2, 2));
        student.Gender.Should().Be(Gender.TransMan);
        student.SkinColor.Should().Be(SkinColor.Yellow);
    }
}
