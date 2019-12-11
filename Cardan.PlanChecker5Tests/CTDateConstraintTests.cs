using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cardan.PlanChecker5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.Constraints;

namespace Cardan.PlanChecker5.Tests
{
    [TestClass()]
    public class CTDateConstraintTests
    {
        [TestMethod()]
        public void CTDatePasses()
        {
            //ARRANGE
            var im = new Image();
            im.CreationDateTime = DateTime.Now.AddDays(-59);

            //ACT
            var constraint = new CTDateConstraint();
            var actual = constraint.Constrain(im).ResultType;

            //ASSERT
            var expected = ResultType.PASSED;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CTDateFails()
        {
            //ARRANGE
            var im = new Image();
            im.CreationDateTime = DateTime.Now.AddDays(-61);

            //ACT
            var constraint = new CTDateConstraint();
            var actual = constraint.Constrain(im).ResultType;

            //ASSERT
            var expected = ResultType.ACTION_LEVEL_3;
            Assert.AreEqual(expected, actual);
        }
    }
}