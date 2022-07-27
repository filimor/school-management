using Moq;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.UoW;

namespace SchoolManagement.Infrastructure.Tests;

public class SyncUnitOfWorkTest
{
    [Fact]
    public void Save_OnCall_CallsSaveOnRepository()
    {
        // Arrange
        var mockDbContext = new Mock<SchoolDbContext>();
        var unitOfWork = new SyncUnitOfWork(mockDbContext.Object);

        // Act
        unitOfWork.Save();

        // Assert
        mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Dispose_OnCall_CallsDisposeOnRepository()
    {
        // Arrange
        var mockDbContext = new Mock<SchoolDbContext>();
        var unitOfWork = new SyncUnitOfWork(mockDbContext.Object);

        // Act
        unitOfWork.Dispose();

        // Assert
        mockDbContext.Verify(x => x.Dispose(), Times.Once);
    }
}
