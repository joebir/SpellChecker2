using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Contracts;
using SpellChecker.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Web.Tests.Controllers.SpellbookControllerTests
{
    [TestClass]
    public abstract class SpellbokControllerTestsBase
    {
        protected SpellbookController Controller;

        protected FakeSpellbookService Service;

        // Arrange
        // Act
        // Assert

        [TestInitialize]
        public virtual void Arrange()
        {
            Service = new FakeSpellbookService();

            Controller = new SpellbookController(
                new Lazy<ISpellbook>(() => Service));
        }
    }
}
