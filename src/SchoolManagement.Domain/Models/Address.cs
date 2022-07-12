using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SchoolManagement.Domain.Models;

public sealed class Address
{
    private static readonly string[] States =
    {
        "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG",
        "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
    };

    public Address(int id, string street, string number, string district, string city = "São Paulo",
        string state = "SP", string zipCode = "", string street2 = "")
    {
        Validate(id, street, number, district, city, state, zipCode, street2);
        Id = id;
        Street = street;
        Number = number;
        Street2 = street2;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    [Key] public int Id { get; }

    [Required] public string Street { get; private set; }

    [Required] public string Number { get; private set; }

    public string Street2 { get; private set; }

    [Required] public string District { get; private set; }

    [Required] public string City { get; private set; }

    [Required] public string State { get; private set; }

    [Required] public string ZipCode { get; private set; }

    public void Update(string street, string number, string district, string city, string state, string zipCode,
        string street2)
    {
        Validate(Id, street, number, district, city, state, zipCode, street2);
        Street = street;
        Number = number;
        Street2 = street2;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
    private static void Validate(int id, string street, string number, string district, string city, string state,
        string zipCode, string street2)
    {
        if (id <= 0)
            throw new ArgumentException("O id deve ser um número inteiro maior do que 1.", nameof(id));
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("O logradouro é obrigatório e deve ter um valor válido.", nameof(street));
        if (street.Length is < 5 or > 100)
            throw new ArgumentException("O logradouro deve ter entre 5 e 100 caracteres.", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("O número é obrigatório e deve ter um valor válido.", nameof(number));
        if (number.Length > 10)
            throw new ArgumentException("O número deve conter entre 1 e 10 caracteres.", nameof(number));
        if (string.IsNullOrWhiteSpace(district))
            throw new ArgumentException("O bairro é obrigatório e deve ter um valor válido.", nameof(district));
        if (district.Length is < 5 or > 100)
            throw new ArgumentException("O bairro deve ter entre 5 e 100 caracteres.", nameof(district));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("A cidade é obrigatória e deve ter um valor válido.", nameof(city));
        if (city.Length is < 5 or > 100)
            throw new ArgumentException("A cidade deve ter entre 5 e 100 caracteres.", nameof(city));
        if (!States.Contains(state))
            throw new ArgumentException("O estado é obrigatório e deve ter um valor válido.", nameof(state));
        var regex = new Regex("[0-9]{5}-?[\\d]{3}");
        if (!regex.IsMatch(zipCode))
        {
            throw new ArgumentException("O CEP deve ser um número de 5 dígitos seguido de um traço e 3 dígitos.",
                nameof(zipCode));
        }

        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("O CEP é obrigatório.", nameof(zipCode));
        zipCode = zipCode.Replace("-", "");
        if (zipCode.Length is not 8)
            throw new ArgumentException("O CEP deve ter 8 dígitos, sem hífem.", nameof(zipCode));
        if (street2.Length > 50)
            throw new ArgumentException("O complemento deve possuir no máximo 50 caracteres.", nameof(street2));
    }
}