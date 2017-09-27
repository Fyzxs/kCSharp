using DependencyKata.Texts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyKata.Tests.Texts
{
    [TestClass]
    public class EqualStringsTests
    {
        [TestMethod]
        public void ShouldBeEqual()
        {
            //Arrange
            EqualStrings equalStrings = new EqualStrings("a", "a");

            //Act
            bool value = equalStrings.Value();

            //Arrange
            value.Should().BeTrue();
        }
        [TestMethod]
        public void ShouldNotBeEqual()
        {
            //Arrange
            EqualStrings equalStrings = new EqualStrings("aa", "a");

            //Act
            bool value = equalStrings.Value();

            //Arrange
            value.Should().BeFalse();
        }
    }
}
