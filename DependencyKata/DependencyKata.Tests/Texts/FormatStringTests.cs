using DependencyKata.Texts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyKata.Tests.Texts
{
    [TestClass]
    public class FormatStringTests
    {
        [TestMethod]
        public void Formats()
        {
            //Arrange
            FormatString formatString = new FormatString("For{0} me{1}", "mat", "!");

            //Assert
            string asString = formatString.AsString();

            //Act
            asString.Should().Be("Format me!");
        }
    }
}
