using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EGNValidator.Service.Validators;

namespace EGNValidator.Tests
{
    [TestClass]
    public class EGNUnitTests
    {
        [TestMethod]
        public void EGN_Test1_Correct()
        {
            var validator = new ENGValidator();

            Assert.IsTrue(validator.Validate("6101057509"), "EGN is not correct");
        }

        [TestMethod]
        public void EGN_Test1_InCorrect()
        {
            var validator = new ENGValidator();

            Assert.IsFalse(validator.Validate("6101057509s"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate(""), "Empty EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate((string)null), "Empty EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate(null), "Empty EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("789"), "Short EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("771211824988"), "Long EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("77121182OO"), "EGN with letters is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("AKJHJKS"), "EGN is not correct");
        }

        [TestMethod]
        public void EGN_ControlDigit_Correct()
        {
            var validator = new ENGValidator();

            Assert.IsTrue(validator.Validate("0545291009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291000"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291001"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291002"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291003"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291004"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291005"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291006"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291007"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291008"), "EGN is not correct");
        }

        [TestMethod]
        public void EGN_ControlDigit_InCorrect()
        {
            var validator = new ENGValidator();

            Assert.IsFalse(validator.Validate("0595291009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0505291009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0515291009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0525291009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("1545291009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("1545311009"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291109"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291029"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291309"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("0545291079"), "EGN is not correct");
        }

        [TestMethod]
        public void EGN_RandomEGN_Correct()
        {
            var validator = new ENGValidator();
            Assert.IsFalse(validator.Validate("7730405060"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsFalse(validator.Validate("7730305060"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7711121018"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7711121208"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7711123350"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7711127103"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7711129298"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7730301004"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7730301025"), "EGN is not correct");

            validator.ClearValidation();
            Assert.IsTrue(validator.Validate("7730301215"), "EGN is not correct");
        }
    }
}