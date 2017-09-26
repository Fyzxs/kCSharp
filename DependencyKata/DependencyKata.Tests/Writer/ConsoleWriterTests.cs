using DependencyKata.Writer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyKata.Tests.Writer
{
    [TestClass]
    public class ConsoleWriterTests
    {
        [TestMethod]
        public void ShouldWriteLine()
        {
            //Arrange
            FakeWriterBookEnd fakeWriterBookEnd = new FakeWriterBookEnd();
            ConsoleWriter subject = new ConsoleWriter(fakeWriterBookEnd);

            //Act
            subject.WriteLine("Some Text");

            //Assert
            fakeWriterBookEnd.AssertWriteLineInvoked();
        }
        [TestMethod]
        public void ShouldWrite()
        {
            //Arrange
            FakeWriterBookEnd fakeWriterBookEnd = new FakeWriterBookEnd();
            ConsoleWriter subject = new ConsoleWriter(fakeWriterBookEnd);

            //Act
            subject.Write("Some Text");

            //Assert
            fakeWriterBookEnd.AssertWriteInvoked();
        }
    }

    public class FakeWriterBookEnd : IWriterBookEnd
    {
        private bool _invokedWriteLine;
        private bool _invokedWrite;

        public void WriteLine(string text) => _invokedWriteLine = true;

        public void Write(string text) => _invokedWrite = true;

        public void AssertWriteLineInvoked() => _invokedWriteLine.Should().BeTrue();
        public void AssertWriteInvoked() => _invokedWrite.Should().BeTrue();
    }
}
