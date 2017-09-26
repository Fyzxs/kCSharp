using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyKata.Tests
{
    [TestClass]
    public class DoItAllTests
    {
        [TestMethod, TestCategory("Integration")]
        public void DoItAll_Does_ItAll()
        {
            DoItAll doItAll = new DoItAll();
            doItAll.Do();
        }
    }
}
