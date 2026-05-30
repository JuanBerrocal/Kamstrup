

using Moq;
using Ejercicio2;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio2Test
{
    [TestClass]
    public class CheckEmailShould
    {
        [TestMethod]
        public void Check_WhenEmailIsNull_ReturnFalse()
        {
            // Arrange
            string? email = null;
             var validator = new EmailValidator(new EmailStore());
            
            // Act
            var result = validator.Check(email);

            // Assert
            Assert.IsFalse(result);
        }

        public void Check_WhenEmailIsEmpty_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator(new EmailStore());
            string email = "";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }
        public void Check_HasNoAtSign_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator(new EmailStore());
            string email = "example";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void Check_HasntTwoParts_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator(new EmailStore());
            string email = "example";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void Check_EndPartWithoutDot_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator(new EmailStore());
            string email = "example@domain";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }

        public void Check_StartsOrEndWithAtSign_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator(new EmailStore());
            string email = "@domain";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }
        public void Check_StartsOrEndWithDot_ReturnFalse()
        {
            //Arrange
            var validator = new EmailValidator(new EmailStore());
            string email = ".domain";

            //Act
            var result = validator.Check(email);

            //Assert
            Assert.IsFalse(result);
        }
       
    }
}