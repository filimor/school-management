using System.Collections;

namespace SchoolManagement.Tests.ClassData;

public class InvalidStringsClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "" };
        yield return new object[] { " " };
        yield return new object[] { null! };
        yield return new object[] { new string('a', 5 - 1) };
        yield return new object[] { new string('a', 100 + 1) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}