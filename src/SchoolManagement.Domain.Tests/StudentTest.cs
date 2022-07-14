using FluentAssertions;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Models;
using SchoolManagement.Domain.Tests.ClassData;

namespace SchoolManagement.Domain.Tests;

public class StudentTest
{
    [Fact]
    public void Should_Create_New_Student_With_Required_Fields()
    {
        var student = new Student(
            1,
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );
        student.Should().NotBeNull();
    }

    [Fact]
    public void Should_Create_New_Student_Without_Id()
    {
        var student = new Student(
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );
        student.Should().NotBeNull();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_Not_Create_Student_With_Invalid_Id(int id)
    {
        var act = () => new Student(
            id,
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        act.Should().Throw<DomainException>();
    }

    [Theory]
    [ClassData(typeof(InvalidStringsClassData))]
    public void Should_Not_Create_Student_With_Invalid_Name(string name)
    {
        var act = () => new Student(
            1,
            name,
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        act.Should().Throw<DomainException>();
    }


    [Fact]
    public void Should_Not_Create_Student_With_Invalid_Birthday()
    {
        var act = () => new Student(
            1,
            "Maria Aparecida Alcântara de Souza Ramos",
            DateTime.Now,
            Gender.CisWoman,
            SkinColor.Black
        );

        act.Should().Throw<DomainException>();
    }

    [Fact]
    public void Should_Be_Able_To_Update_Student_Data_With_Same_Id()
    {
        var student = new Student(
            1,
            "Maria Aparecida Alcântara de Souza Ramos",
            new DateTime(2000, 1, 1),
            Gender.CisWoman,
            SkinColor.Black
        );

        student.Update("José Ricardo Eugênio Matoso de Barros",
            new DateTime(2001, 2, 2),
            Gender.TransMan,
            SkinColor.Yellow);

        student.Id.Should().Be(1);
        student.Name.Should().Be("José Ricardo Eugênio Matoso de Barros");
        student.Birthday.Should().Be(new DateTime(2001, 2, 2));
        student.Gender.Should().Be(Gender.TransMan);
        student.SkinColor.Should().Be(SkinColor.Yellow);
    }


}