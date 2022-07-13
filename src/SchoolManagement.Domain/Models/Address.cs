using System.Text.RegularExpressions;
using SchoolManagement.Domain.Validations;

namespace SchoolManagement.Domain.Models;

public sealed class Address : Entity
{
    private static readonly string[] States =
    {
        "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG",
        "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
    };

    public Address(int id, string street, string number, string district, string city = "São Paulo",
        string state = "SP", string zipCode = "", string street2 = "") : base(id)
    {
        Initialize(street, number, district, city, state, zipCode, street2);
    }


    public string Street { get; private set; } = null!;

    public string Number { get; private set; } = null!;

    public string Street2 { get; private set; } = null!;

    public string District { get; private set; } = null!;

    public string City { get; private set; } = null!;

    public string State { get; private set; } = null!;

    public string ZipCode { get; private set; } = null!;

    public void Update(string street, string number, string district, string city, string state, string zipCode,
        string street2)
    {
        Initialize(street, number, district, city, state, zipCode, street2);
        Update();
    }

    private void Initialize(string street, string number, string district, string city, string state, string zipCode,
        string street2)
    {
        Validate(street, number, district, city, state, zipCode, street2);
        Street = street;
        Number = number;
        Street2 = street2;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    private static void Validate(string street, string number, string district, string city, string state,
        string zipCode, string street2)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(street),
            "O Logradouro é obrigatório e não pode ter um valor vazio.");
        DomainValidation.When(street.Length is < 5 or > 100,
            "O Logradouro deve ter entre 5 e 100 caracteres.");

        DomainValidation.When(string.IsNullOrWhiteSpace(district),
            "O Bairro é obrigatório e não pode ter um valor vazio.");
        DomainValidation.When(district.Length is < 5 or > 100,
            "O Bairro deve ter entre 5 e 100 caracteres.");

        DomainValidation.When(string.IsNullOrWhiteSpace(city),
            "A cidade é obrigatória e não pode ter um valor vazio.");
        DomainValidation.When(city.Length is < 5 or > 100,
            "A cidade deve ter entre 5 e 100 caracteres.");

        DomainValidation.When(string.IsNullOrWhiteSpace(number),
            "O Número é obrigatório e não pode ter um valor vazio.");
        DomainValidation.When(number.Length is < 1 or > 10,
            "O Número é obrigatório e deve ter entre 1 e 10 caracteres.");

        DomainValidation.When(!States.Contains(state),
            "O Estado é obrigatório e deve ter um valor válido com 2 caracteres.");
        DomainValidation.When(street2.Length > 50, "O complemento deve possuir no máximo 50 caracteres.");

        var regex = new Regex(@"^([0-9]{5}-[\d]{3})$");
        DomainValidation.When(!regex.IsMatch(zipCode),
            "O CEP é obrigatório e deve possuir 5 dígitos, um traço e mais 3 dígitos.");
    }
}