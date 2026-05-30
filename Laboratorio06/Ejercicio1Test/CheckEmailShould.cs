
using Ejercicio1;

namespace Ejercicio1Test
{
    [TestClass]
    public class CheckEmailShould
    {
        [TestMethod]
        public void TestEmail_WhenEmailIsNull_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string? email = null;
            
            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void TestEmail_WhenEmailIsEmpty_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string email = "";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }
        public void TestEmail_HasNoAtSign_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string email = "example";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void TestEmail_HasntTwoParts_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string email = "example";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void TestEmail_EndPartWithoutDot_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string email = "example@domain";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void TestEmail_StartsOrEndWithAtSign_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string email = "@domain";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }
        public void TestEmail_StartsOrEndWithDot_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator();
            string email = ".domain";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }
    }
}