using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpellChecker.Web.Tests.Controllers.SpellbookControllerTests
{
    [TestClass]
    public class CreatePost : SpellbokControllerTestsBase
    {
        private ActionResult Act()
        {
            return Controller.Create(new SpellChecker.Models.SpellbookCreateModel());
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            Act();

            Assert.AreEqual(1, Service.CreateSpellbookCallCount);
        }
    }
}
