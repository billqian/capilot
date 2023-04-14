using FluentAssertions;
using NUnit.Framework;
using System.Drawing;

namespace Syntop.Pilot.Domain.UnitTest.Entities;

public class SampleTest
{
    /// <summary>
    /// 一个简单的示例
    /// </summary>
    [Test]
    public void AlwaysPass()
    {
        Console.WriteLine(@"一个简单的示例");

        var result = 1 + 1;

        result.Should().Be(2);
    }
}
