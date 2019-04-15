using Loblaws.Biz.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loblaws.Biz.Tests
{
    [TestClass]
    public class CalculTotalTests
    {
        /// <summary>
        /// Service à tester.
        /// </summary>
        private static ICalculTotal _calcul;

        /// <summary>
        /// Initialiser le service à tester.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _calcul = new CalculTotal();
        }

        [TestCategory(@"Calcul du total")]
        [TestMethod]
        public void Calcul_Succes()
        {
            // Variables de travail.
            var sousTotal = 1m;
            var montantTaxes = 0.15m;

            // Attendu.
            var attendu = 1.15m;

            // Actuel.
            var actuel = _calcul.Calculer(sousTotal, montantTaxes);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du total")]
        [TestMethod]
        public void Calcul_EchecSousTotalNegatif()
        {
            // Variables de travail.
            var sousTotal = -1m;
            var montantTaxes = 0.15m;

            // Attendu.
            var attendu = 0.15m;

            // Actuel.
            var actuel = _calcul.Calculer(sousTotal, montantTaxes);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du total")]
        [TestMethod]
        public void Calcul_EchecMontantTaxesNegatif()
        {
            // Variables de travail.
            var sousTotal = 1m;
            var montantTaxes = -0.15m;

            // Attendu.
            var attendu = 1m;

            // Actuel.
            var actuel = _calcul.Calculer(sousTotal, montantTaxes);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du total")]
        [TestMethod]
        public void Calcul_DeuxNegatif()
        {
            // Variables de travail.
            var sousTotal = -1m;
            var montantTaxes = -0.15m;

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calcul.Calculer(sousTotal, montantTaxes);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
