using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Infrastructure.Tests;

public class RepositoryClassTest
{
    [Fact]
    public void Add_OnEntityPassed_CallAddMethodOnDbSet()
    {
        // Arrange
        var address = new Address(1, "aaaaa", "bbbbb", "ccccc", "11111-111");


        var addressesList = new List<Address> { new(1, "aaaaa", "bbbbb", "ccccc", "11111-111") };

        var queryable = addressesList.AsQueryable();
        var dbSetMock = new Mock<DbSet<Address>>();
        var contextMock = new Mock<DbContext>();

        dbSetMock.As<IQueryable<Address>>().Setup(x => x.Provider).Returns(queryable.Provider);
        dbSetMock.As<IQueryable<Address>>().Setup(x => x.Expression).Returns(queryable.Expression);
        dbSetMock.As<IQueryable<Address>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
        dbSetMock.As<IQueryable<Address>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());
        dbSetMock.Setup(x => x.Add(It.IsAny<Address>())).Callback<Address>(y => addressesList.Add(y));

        contextMock.Setup(x => x.Set<Address>()).Returns(dbSetMock.Object);

        // Act
        var repository = new Repository<Address>(contextMock.Object);
        repository.Add(address);

        // Assert
        contextMock.Verify(x => x.Set<Address>());
        dbSetMock.Verify(x => x.Add(It.Is<Address>(y => y == address)));
    }
}
