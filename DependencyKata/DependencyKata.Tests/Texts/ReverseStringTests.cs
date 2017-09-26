using DependencyKata.Texts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyKata.Tests.Texts
{
    [TestClass]
    public class ReverseStringTests
    {
        [TestMethod]
        public void ShouldReverse()
        {
            //Arrange
            ReverseString reverseString = new ReverseString("palindrome");
            //Act
            string asString = reverseString.AsString();
            //assert
            asString.Should().Be("emordnilap");
        }
    }
}
