using System.Linq.Expressions;
using AutoMapper;
using FluentAssertions;
using Moq;
using SchoolManagement.Application.Data.AddressDtos;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Application.Tests;

public class AddressSyncServiceTest
{
    private readonly Address _address;
    private readonly CreateAddressDto _createAddressDto;
    private readonly GetAddressDto _getAddressDto;
    private readonly ModifyAddressDto _modifyAddressDto;

    public AddressSyncServiceTest()
    {
        _getAddressDto = new GetAddressDto
        {
            Id = 1,
            Street = "R. dos Eucaliptos",
            Number = "10A",
            District = "Centro",
            ZipCode = "11111-111",
            City = "São Paulo",
            State = "SP",
            Street2 = "Apto 101"
        };

        _createAddressDto = new CreateAddressDto
        {
            Street = "R. dos Eucaliptos",
            Number = "10A",
            District = "Centro",
            ZipCode = "11111-111",
            City = "São Paulo",
            State = "SP",
            Street2 = "Apto 101"
        };

        _modifyAddressDto = new ModifyAddressDto
        {
            Id = 1,
            Street = "R. das Palmeiras",
            Number = "20B",
            District = "Jardins",
            ZipCode = "22222-222",
            City = "Rio de Janeiro",
            State = "RJ",
            Street2 = "Apto 202"
        };

        _getAddressDto = new GetAddressDto
        {
            Id = 1,
            Street = "R. das Palmeiras",
            Number = "20B",
            District = "Jardins",
            ZipCode = "22222-222",
            City = "Rio de Janeiro",
            State = "RJ",
            Street2 = "Apto 202"
        };

        _address = new Address(
            1,
            "R. dos Eucaliptos",
            "10A",
            "Centro",
            "11111-111",
            "São Paulo",
            "SP",
            "Apto 101");
    }

    [Fact]
    public void Get_IdPassed_ReturnsAddressDto()
    {
        // Arrange
        var unitOfWorkMock = new Mock<ISyncUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        unitOfWorkMock.Setup(x => x.AddressRepository.Get(It.IsAny<int>())).Returns(_address);
        mapperMock.Setup(x => x.Map<GetAddressDto>(It.IsAny<Address>())).Returns(_getAddressDto);

        // Act
        var service = new AddressSyncService(unitOfWorkMock.Object, mapperMock.Object);
        var queryResult = service.Get(1);

        // Assert
        unitOfWorkMock.Verify(x => x.AddressRepository.Get(It.Is<int>(y => y == 1)), Times.Once);
        queryResult.Should().BeEquivalentTo(_getAddressDto);
    }

    [Fact]
    public void GetAll_Called_ReturnsIEnumerableOfAddressDto()
    {
        // Arrange
        var addressesDtoList = new List<GetAddressDto> { _getAddressDto };
        var addressesList = new List<Address> { _address };

        var unitOfWorkMock = new Mock<ISyncUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        unitOfWorkMock.Setup(x => x.AddressRepository.GetAll()).Returns(addressesList);
        mapperMock.Setup(x => x.Map<IEnumerable<GetAddressDto>>(It.IsAny<IEnumerable<Address>>()))
            .Returns(addressesDtoList);

        // Act
        var service = new AddressSyncService(unitOfWorkMock.Object, mapperMock.Object);
        var queryResult = service.GetAll();

        // Assert
        unitOfWorkMock.Verify(x => x.AddressRepository.GetAll(), Times.Once);
        queryResult.Should().BeEquivalentTo(addressesDtoList);
    }

    [Fact]
    public void Add_AddressDtoPassed_AddAndSaveInUnitOfWork()
    {
        // Arrange
        var unitOfWorkMock = new Mock<ISyncUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<Address>(It.IsAny<CreateAddressDto>())).Returns(_address);
        unitOfWorkMock.Setup(x => x.AddressRepository.Add(It.IsAny<Address>())).Verifiable();
        unitOfWorkMock.Setup(x => x.Save()).Verifiable();

        // Act
        var service = new AddressSyncService(unitOfWorkMock.Object, mapperMock.Object);
        service.Add(_createAddressDto);

        // Assert
        mapperMock.Verify(x => x.Map<Address>(It.Is<CreateAddressDto>(y => y == _createAddressDto)), Times.Once);
        unitOfWorkMock.Verify(x => x.AddressRepository.Add(_address), Times.Once);
        unitOfWorkMock.Verify(x => x.Save(), Times.Once);
    }

    [Fact]
    public void Update_AddressDtoPassed_AddAndSaveInUnitOfWork()
    {
        // Arrange
        var unitOfWorkMock = new Mock<ISyncUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<Address>(It.IsAny<ModifyAddressDto>())).Returns(_address);
        unitOfWorkMock.Setup(x => x.AddressRepository.Update(It.IsAny<Address>())).Verifiable();
        unitOfWorkMock.Setup(x => x.Save()).Verifiable();

        // Act
        var service = new AddressSyncService(unitOfWorkMock.Object, mapperMock.Object);
        service.Update(_modifyAddressDto);

        // Assert
        mapperMock.Verify(x => x.Map<Address>(It.Is<ModifyAddressDto>(y => y == _modifyAddressDto)), Times.Once);
        unitOfWorkMock.Verify(x => x.AddressRepository.Update(_address), Times.Once);
        unitOfWorkMock.Verify(x => x.Save(), Times.Once);
    }

    [Fact]
    public void Delete_AddressDtoPassed_AddAndSaveInUnitOfWork()
    {
        // Arrange
        var unitOfWorkMock = new Mock<ISyncUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(x => x.Map<Address>(It.IsAny<ModifyAddressDto>())).Returns(_address);
        unitOfWorkMock.Setup(x => x.AddressRepository.Delete(It.IsAny<Address>())).Verifiable();
        unitOfWorkMock.Setup(x => x.Save()).Verifiable();

        // Act
        var service = new AddressSyncService(unitOfWorkMock.Object, mapperMock.Object);
        service.Delete(_modifyAddressDto);

        // Assert
        mapperMock.Verify(x => x.Map<Address>(It.Is<ModifyAddressDto>(y => y == _modifyAddressDto)), Times.Once);
        unitOfWorkMock.Verify(x => x.AddressRepository.Delete(_address), Times.Once);
        unitOfWorkMock.Verify(x => x.Save(), Times.Once);
    }

    [Fact]
    public void Find_PredicatePassed_ReturnsIEnumerableOfAddressDto()
    {
        // Arrange
        var addressesDtoList = new List<GetAddressDto> { _getAddressDto };
        var addressesList = new List<Address> { _address };

        var unitOfWorkMock = new Mock<ISyncUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        unitOfWorkMock.Setup(x => x.AddressRepository.Find(It.IsAny<Expression<Func<Address, bool>>>())).Returns(addressesList);
        mapperMock.Setup(x => x.Map<IEnumerable<GetAddressDto>>(It.IsAny<IEnumerable<Address>>()))
            .Returns(addressesDtoList);

        // Act
        var service = new AddressSyncService(unitOfWorkMock.Object, mapperMock.Object);
        var queryResult = service.Find(x => x.Id == 1);

        // Assert
        unitOfWorkMock.Verify(x => x.AddressRepository.Find(It.Is<Expression<Func<Address, bool>>>(y => y.Compile().Invoke(_address))), Times.Once);
        queryResult.Should().BeEquivalentTo(addressesDtoList);
    }
}
