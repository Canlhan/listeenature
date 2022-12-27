
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var uservice = new UserForLogin();


            var mockIdataResult = new Mock<IDataResult<User>>();
            mockIdataResult.Setup(i => i.Success).Returns(true);


        }
    }
}
