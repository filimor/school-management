using SchoolManagement.Domain.Validations;

namespace SchoolManagement.Domain.Models;

public sealed class Student : Entity
{
    public Student(int id, string name, DateTime birthday, Gender gender, SkinColor skinColor) :
        base(id)
    {
        Initialize(name, birthday, gender, skinColor);
    }

    public Student(string name, DateTime birthday, Gender gender, SkinColor skinColor)
    {
        Initialize(name, birthday, gender, skinColor);
    }

    public string Name { get; private set; } = null!;

    public Address? Address { get; set; }
    public int AddressId { get; set; }

    public DateTime Birthday { get; private set; }

    public Gender Gender { get; private set; }

    public SkinColor SkinColor { get; private set; }

    public void Update(string name, DateTime birthday, Gender gender,
        SkinColor skinColor)
    {
        Initialize(name, birthday, gender, skinColor);
        Update();
    }

    private void Initialize(string name, DateTime birthday, Gender gender, SkinColor skinColor)
    {
        Validate(name, birthday, gender, skinColor);
        Name = name;
        Birthday = birthday;
        Gender = gender;
        SkinColor = skinColor;
    }

    private static void Validate(string name, DateTime birthday, Gender gender,
        SkinColor skinColor)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(name), "O nome é obrigatório e deve ter um valor válido.");
        DomainValidation.When(name.Length is < 5 or > 100, "O nome deve ter entre 5 e 100 caracteres.");
        DomainValidation.When(birthday <= new DateTime(1900, 1, 1) || birthday.Date >= DateTime.Now.Date,
            "A data de nascimento deve ter um valor válido.");
        DomainValidation.When(!Enum.GetValues<Gender>().Contains(gender), "Deve ser selecionado um gênero válido.");
        DomainValidation.When(!Enum.GetValues<SkinColor>().Contains(skinColor), "Deve ser selecionada uma cor válida.");
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