using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Infrastructure.Tests.ClassData;

namespace SchoolManagement.Infrastructure.Tests;

public class SyncRepositoryClassTest
{
    [Theory]
    [ClassData(typeof(EntitiesGenerator))]
    public void Add_OnEntityPassed_CallAddMethodOnDbSet(Entity entity)
    {
        // Arrange
        var entitiesList = new List<Entity> { entity };
        var dbSetMock = GenerateDbSetMock(entitiesList);
        var contextMock = new Mock<DbContext>();
        contextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        // Act
        var repository = new SyncRepository<Entity>(contextMock.Object);
        repository.Add(entity);

        // Assert
        contextMock.Verify(x => x.Set<Entity>());
        dbSetMock.Verify(x => x.Add(It.Is<Entity>(y => y == entity)), Times.Once);
    }

    [Theory]
    [ClassData(typeof(EntitiesGenerator))]
    public void Update_OnEntityPassed_CallUpdateMethodOnDbSet(Entity entity)
    {
        // Arrange
        var entitiesList = new List<Entity> { entity };
        var dbSetMock = GenerateDbSetMock(entitiesList);
        var contextMock = new Mock<DbContext>();
        contextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        // Act
        var repository = new SyncRepository<Entity>(contextMock.Object);
        repository.Update(entity);

        // Assert
        contextMock.Verify(x => x.Set<Entity>());
        dbSetMock.Verify(x => x.Update(It.Is<Entity>(y => y == entity)), Times.Once);
    }

    [Theory]
    [ClassData(typeof(EntitiesGenerator))]
    public void Delete_OnEntityPassed_CallDeleteMethodOnDbSet(Entity entity)
    {
        // Arrange
        var entitiesList = new List<Entity> { entity };
        var dbSetMock = GenerateDbSetMock(entitiesList);
        var contextMock = new Mock<DbContext>();
        contextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        // Act
        var repository = new SyncRepository<Entity>(contextMock.Object);
        repository.Remove(entity);

        // Assert
        contextMock.Verify(x => x.Set<Entity>());
        dbSetMock.Verify(x => x.Remove(It.Is<Entity>(y => y == entity)), Times.Once);
    }

    [Theory]
    [ClassData(typeof(EntitiesGenerator))]
    public void Get_OnEntityPassed_CallGetMethodOnDbSet(Entity entity)
    {
        // Arrange
        var entitiesList = new List<Entity> { entity };
        var dbSetMock = GenerateDbSetMock(entitiesList);
        var contextMock = new Mock<DbContext>();
        contextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        //dbSetMock.Setup(x => x.AsNoTracking()).Returns(dbSetMock.Object);
        //dbSetMock.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Entity, bool>>>(), default)).Returns(Task.FromResult<Entity>);

        // Act
        var repository = new SyncRepository<Entity>(contextMock.Object);
        var queryResult = repository.Get(1);

        // Assert
        contextMock.Verify(x => x.Set<Entity>());
        //dbSetMock.Verify(x => x.FirstOrDefault());
        queryResult.Should().BeEquivalentTo(entity);
    }

    [Theory]
    [ClassData(typeof(EntitiesGenerator))]
    public void GetAll_OnEntityPassed_CallToListMethodOnDbSet(Entity entity)
    {
        // Arrange
        var entitiesList = new List<Entity> { entity };
        var dbSetMock = GenerateDbSetMock(entitiesList);
        var contextMock = new Mock<DbContext>();
        contextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        // Act
        var repository = new SyncRepository<Entity>(contextMock.Object);
        var queryResult = repository.GetAll();

        // Assert
        contextMock.Verify(x => x.Set<Entity>());
        //dbSetMock.Verify(x => x.ToList());
        queryResult.Should().BeEquivalentTo(entitiesList);
    }

    [Theory]
    [ClassData(typeof(EntitiesGenerator))]
    public void Find_OnEntityPassed_CallToListMethodWithWhere(Entity entity)
    {
        // Arrange
        var entitiesList = new List<Entity> { entity };
        var dbSetMock = GenerateDbSetMock(entitiesList);
        var contextMock = new Mock<DbContext>();
        contextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        // Act
        var repository = new SyncRepository<Entity>(contextMock.Object);
        var queryResult = repository.Find(x => x.Id == entity.Id);

        // Assert
        contextMock.Verify(x => x.Set<Entity>());
        //dbSetMock.Verify(x => x.Where(It.Is<Expression<Func<Entity, bool>>>(y => y.Compile().Invoke(entity))));
        queryResult.Should().Equal(entity);
    }

    private static Mock<DbSet<T>> GenerateDbSetMock<T>(IEnumerable<T> collection) where T : Entity
    {
        var queryable = collection.AsQueryable();
        var dbSetMock = new Mock<DbSet<T>>();

        dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryable.Provider);
        dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryable.Expression);
        dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
        dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());
        //dbSetMock.As<IQueryable<T>>().Setup(x => x.ToList()).Returns(queryable.ToList());

        //dbSetMock.Setup(x => x.Add(It.IsAny<T>())).Callback<T>(collection.Add);
        return dbSetMock;
    }
}
