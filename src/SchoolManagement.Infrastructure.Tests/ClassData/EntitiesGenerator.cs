using System.Collections;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Tests.ClassData;

internal class EntitiesGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Address(1, "aaaaa", "bbbbb", "ccccc", "11111-111") };
        yield return new object[] { new Student(1, "aaaaa", new DateTime(2000, 1, 1), Gender.CisMan, SkinColor.White) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
