using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using SchoolManagement.Domain.Exceptions;

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
        Validate(street, number, district, city, state, zipCode, street2);
        Street = street;
        Number = number;
        Street2 = street2;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }


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
        Validate(street, number, district, city, state, zipCode, street2);
        Street = street;
        Number = number;
        Street2 = street2;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
    private static void Validate(string street, string number, string district, string city, string state,
        string zipCode, string street2)
    {
        foreach (var property in new[] { street, number, district, city })
        {
            if (string.IsNullOrWhiteSpace(nameof(property)))
            {
                throw new DomainException($"{property} é um campo obrigatório e deve ter um valor válido."
                    );
            }

            if (nameof(property).Length is < 5 or > 100)
            {
                throw new DomainException($"O campo {property} deve ter entre 5 e 100 caracteres." );
            }
        }

        if (!States.Contains(state))
        {
            throw new DomainException("O estado é obrigatório e deve ter um valor válido." );
        }

        ValidateZipCode(zipCode);

        if (street2.Length > 50)
        {
            throw new DomainException("O complemento deve possuir no máximo 50 caracteres.");
        }
    }

    private static void ValidateZipCode(string zipCode)
    {
        var regex = new Regex("[0-9]{5}-?[\\d]{3}");
        if (!regex.IsMatch(zipCode))
        {
            throw new DomainException("O CEP deve ser um número de 5 dígitos seguido de um traço e 3 dígitos."
                );
        }

        if (string.IsNullOrWhiteSpace(zipCode))
        {
            throw new DomainException("O CEP é obrigatório.");
        }

        zipCode = zipCode.Replace("-", "");
        if (zipCode.Length is not 8)
        {
            throw new DomainException("O CEP deve ter 8 dígitos, sem hífem.");
        }
    }
}