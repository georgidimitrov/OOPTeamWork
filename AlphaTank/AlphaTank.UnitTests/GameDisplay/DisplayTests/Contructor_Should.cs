using AlphaTank.Program.GameDisplay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlphaTank.UnitTests.GameDisplay.DisplayTests
{
    [TestClass]
    public class Contructor_Should
    {
        [TestMethod]
        public void Throw_ArgumentNullException_When_Wrapper_IsNull()
        {
            //arrange & act
            Action creatingDisplay = () => new Display(null);

            //assert
            Assert.ThrowsException<ArgumentNullException>(creatingDisplay);
        }
    }
}
