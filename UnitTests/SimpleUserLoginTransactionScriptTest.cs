using Bank.Data.DTO;
using Bank.Data.TDGW;
using Bank.Domain.TransactionScripts;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace UnitTests
{
    public class SimpleUserLoginTransactionScriptTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Execute_UserNotFound_Throws()
        {
            var gtw = NSubstitute.Substitute.For<IUserGateway>();
            gtw.GetUser("jakub.plesnik@vsb.cz").ReturnsNull();

            var ts = new SimpleUserLoginTransactionScript(gtw);
            Assert.Throws<Exception>(() => ts.Execute("jakub.plesnik@vsb.cz", "test123"));
        }

        [Test]
        public void Execute_ValidUserWrongPassword_ReturnsFalse()
        {
            var gtw = Substitute.For<IUserGateway>();
            gtw.GetUser("jakub.plesnik@vsb.cz").Returns( new UserDTO
            {
                Email = "jakub.plesnik@vsb.cz",
                PaswordHash = "testhash"
            });

            var ts = new SimpleUserLoginTransactionScript(gtw);
            var result = ts.Execute("jakub.plesnik@vsb.cz", "test123");

            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_ValidUserRightPassword_ReturnsTrue()
        {
            var gtw = Substitute.For<IUserGateway>();
            gtw.GetUser("jakub.plesnik@vsb.cz").Returns(new UserDTO
            {
                Email = "jakub.plesnik@vsb.cz",
                PaswordHash = "zAPnR6avu8v4vnZorP6+5Q=="
            });

            var ts = new SimpleUserLoginTransactionScript(gtw);
            var result = ts.Execute("jakub.plesnik@vsb.cz", "test123");

            Assert.IsTrue(result);
        }
    }
}