using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Models;

public sealed class Address
{
    public Address(int id, string street, string number, string district, string city = "São Paulo",
        string state = "SP", string zipCode = "", string street2 = "")
    {
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

    public void Update(int id, string street, string number, string district, string zipCode, string city, string state,
        string street2)
    {
        Street = street;
        Number = number;
        Street2 = street2;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    private static void Validate(int id, string street, string number, string district, string city, string state,
        string zipCode, string street2)
    {
        if (id <= 0)
            throw new ArgumentException("O id deve ser um número inteiro maior do que 1.", nameof(id));
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("O nome é obrigatório e deve ter um valor válido.", nameof(street));
        if (street.Length < 5 || street.Length > 100)
            throw new ArgumentException("O nome deve ter entre 5 e 100 caracteres.", nameof(street));
        if (string.IsNullOrWhiteSpace(district))
            throw new ArgumentException("O nome é obrigatório e deve ter um valor válido.", nameof(district));
        if (district.Length < 5 || district.Length > 100)
            throw new ArgumentException("O nome deve ter entre 5 e 100 caracteres.", nameof(district));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("O nome é obrigatório e deve ter um valor válido.", nameof(city));
        if (city.Length < 5 || city.Length > 100)
            throw new ArgumentException("O nome deve ter entre 5 e 100 caracteres.", nameof(city));
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("O nome é obrigatório e deve ter um valor válido.", nameof(state));
        if (state.Length < 5 || state.Length > 100)
            throw new ArgumentException("O nome deve ter entre 5 e 100 caracteres.", nameof(state));
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("O CEP é obrigatório.", nameof(zipCode));
        zipCode = zipCode.Replace("-", "");
        if (zipCode.Length != 8)
            throw new ArgumentException("O CEP deve ter 8 dígitos, sem hífem.", nameof(zipCode));
    }
}