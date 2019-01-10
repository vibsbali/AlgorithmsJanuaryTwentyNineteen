using Algorithms.StringSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.StringSearchTests
{
    [TestClass]
    public class BoyerMoreTests
    {
        [TestMethod]
        public void Search_TRUTH_in_This_Is_True_But_Truth_Is_hard_Asserts_True()
        {
            var truth = "Truth";
            var paragraph = "Turth in this is true but truth is hard";

            var hasFound = new BoyerMooreHorspool().IsPresent(paragraph, truth);
            Assert.IsTrue(hasFound, "Should be true but was false");
        }

        [TestMethod]
        public void Search_THRUTH_in_This_Is_ThuRth_But_Truth_Is_hard_Asserts_False()
        {
            var truth = "Thruth";
            var paragraph = "THURTH in this is true but trruth is hard";
                                                          
            var hasFound = new BoyerMooreHorspool().IsPresent(paragraph, truth);
            Assert.IsFalse(hasFound, "Should be true but was false");
        }

        [TestMethod]
        public void Search_()
        {
                         
            var truth = "GCAGAGAG";
                         /*
                          * G 0
                          * A 1
                          * C 6
                          *
                          */
            var paragraph = "GCATCGCAGAGAGTATACAGTACG";
                              
            var hasFound = new BoyerMooreHorspool().IsPresent(paragraph, truth);
            Assert.IsTrue(hasFound, "Should be true but was false");
        }
    }
}
