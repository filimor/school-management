using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using SchoolManagement.Domain.Exceptions;

namespace SchoolManagement.Domain.Models;

public sealed class Student : Entity
{
    public Student(int id, string name, Address address, DateTime birthday, Gender gender, SkinColor skinColor) :
        base(id)
    {
        Validate(name, address, birthday, gender, skinColor);
        Name = name;
        Address = address;
        Birthday = birthday;
        Gender = gender;
        SkinColor = skinColor;
    }

    [Required] public string Name { get; private set; }

    [Required] public Address Address { get; private set; }

    [Required] public DateTime Birthday { get; private set; }

    [Required] public Gender Gender { get; private set; }

    [Required] public SkinColor SkinColor { get; private set; }

    public void Update(string name, Address address, DateTime birthday, Gender gender,
        SkinColor skinColor)
    {
        Validate(name, address, birthday, gender, skinColor);
        Name = name;
        Address = address;
        Birthday = birthday;
        Gender = gender;
        SkinColor = skinColor;
        Update();
    }

    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
    private static void Validate(string name, Address address, DateTime birthday, Gender gender,
        SkinColor skinColor)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("O nome é obrigatório e deve ter um valor válido.");
        }

        if (name.Length is < 5 or > 100)
        {
            throw new DomainException("O nome deve ter entre 5 e 100 caracteres.");
        }

        if (address is null)
        {
            throw new DomainException("O endereço é obrigatório.");
        }

        if (birthday <= new DateTime(1900, 1, 1) || birthday.Date >= DateTime.Now.Date)
        {
            throw new DomainException("A data de nascimento deve ter um valor válido.");
        }

        if (!Enum.GetValues<Gender>().Contains(gender))
        {
            throw new DomainException("Deve ser selecionado um gênero válido.");
        }

        if (!Enum.GetValues<SkinColor>().Contains(skinColor))
        {
            throw new DomainException("Deve ser selecionada uma cor válida.");
        }
    }
}

public enum SkinColor
{
    Black,
    Brown,
    White,
    Yellow,
    Red,
    Others
}

public enum Gender
{
    CisWoman,
    TransWoman,
    CisMan,
    TransMan,
    NonBinary,
    Others
}