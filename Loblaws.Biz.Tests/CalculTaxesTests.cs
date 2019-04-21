using Loblaws.Biz.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loblaws.Biz.Tests
{
    [TestClass]
    public class CalculTaxesTests
    {
        /// <summary>
        /// Service à tester.
        /// </summary>
        private static ICalculTaxes _calcul;

        /// <summary>
        /// Initialiser le service à tester.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _calcul = new CalculTaxes();
        }

        [TestCategory(@"Calcul des taxes")]
        [TestMethod]
        public void Zero_Succes()
        {
            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calcul.Calculer(0m);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul des taxes")]
        [TestMethod]
        public void UnMontantFictif_Succes()
        {
            // Attendu.
            var attendu = 15m;

            // Actuel.
            var actuel = _calcul.Calculer(100m);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul des taxes")]
        [TestMethod]
        public void MontantAvecDecimales_Succes()
        {
            // Variables de travail.
            var montants = new decimal[0];

            // Attendu.
            var attendu = 1.68m;

            // Actuel.
            var actuel = _calcul.Calculer(11.22m);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul des taxes")]
        [TestMethod]
        public void MontantNegatif_Succes()
        {
            // Variables de travail.
            var sousTotal = -5m;

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calcul.Calculer(sousTotal);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
