using DependencyKata.Reader;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DependencyKata.Tests.Reader
{
    [TestClass]
    public class ConsoleReaderTests
    {
        [TestMethod]
        public void ShouldRead()
        {
            //Arrange
            FakeReaderBookEnd fakeReaderBookEnd = new FakeReaderBookEnd();
            ConsoleReader subject = new ConsoleReader(fakeReaderBookEnd);

            //Act
            subject.Line();

            //Assert
            fakeReaderBookEnd.AssertReadLineInvoked();
        }
        [TestMethod]
        public void ShouldReadKey()
        {
            //Arrange
            FakeReaderBookEnd fakeReaderBookEnd = new FakeReaderBookEnd();
            ConsoleReader subject = new ConsoleReader(fakeReaderBookEnd);

            //Act
            subject.WaitForKey();

            //Assert
            fakeReaderBookEnd.AssertReadKeyInvoked();
        }
    }

    public class FakeReaderBookEnd : IReaderBookEnd
    {
        private bool _invokedReadLine;
        private bool _invokedReadKey;

        public string ReadLine()
        {
            _invokedReadLine = true;
            return "We got invoked";
        }

        public ConsoleKeyInfo ReadKey()
        {
            _invokedReadKey = true;
            return new ConsoleKeyInfo();
        }

        public void AssertReadLineInvoked() => _invokedReadLine.Should().BeTrue();
        public void AssertReadKeyInvoked() => _invokedReadKey.Should().BeTrue();
    }
}
