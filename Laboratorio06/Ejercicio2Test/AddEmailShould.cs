using Ejercicio2;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2Test
{
    [TestClass]
    public class AddEmailShould
    {
        [TestMethod]
        public void Add_WhenEmailIsDuplicated_ThrowsException()
        {
            // Arrange
            string? email = "example@example.com";
            var emailStoreMock = new Mock<IEmailStore>();
            emailStoreMock.Setup(a => a.IsStored(email)).Returns(true);
            var validator = new EmailValidator(emailStoreMock.Object);

            // Act
            DuplicatedEmailException exception = Assert.ThrowsException<DuplicatedEmailException>(() => { validator.Add(email); });

            // Assert
            Assert.IsTrue(exception.getMessage().Contains("Ese email ya existe"));
        }
    }
}
