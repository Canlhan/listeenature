using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace testte
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        [Test]
        public void login_unit_test()
        {
            // arrange  MOQ IUserService


            var uservice = new UserForLogin()
            {
                email = "email",
                password = "sifre"
            };


            var mockIdataResult = new Mock<IDataResult<User>>();
            mockIdataResult.Setup(i => i.Success).Returns(true);




            var mockIUserService = new Mock<IUserService>();
            mockIUserService.Setup(i => i.getByEmail(uservice)).Returns(mockIdataResult.Object);
            var authscontroller = new AuthsController(mockIUserService.Object);


            // action
            IActionResult result = authscontroller.getcustomerlogin(uservice);

            var okResult = result as OkObjectResult;
            // assert
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
    }
}
