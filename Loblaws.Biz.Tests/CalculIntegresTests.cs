using Loblaws.Biz.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loblaws.Biz.Tests
{
    [TestClass]
    public class CalculIntegresTests
    {
        /// <summary>
        /// Services à tester.
        /// </summary>
        private static ICalculSousTotal _calculSousTotal;
        private static ICalculTaxes _calculTaxes;
        private static ICalculTotal _calculTotal;

        /// <summary>
        /// Initialiser le service à tester.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _calculSousTotal = new CalculSousTotal();
            _calculTaxes = new CalculTaxes();
            _calculTotal = new CalculTotal();
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_Succes()
        {
            // Variables de travail.
            var montants = new[] { 10m };

            // Attendu.
            var attendu = 11.50m;

            // Actuel.
            var sousTotal = _calculSousTotal.Calculer(montants);
            var actuel = _calculTotal.Calculer(sousTotal, _calculTaxes.Calculer(sousTotal));

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesDeuxMontants()
        {
            // Variables de travail.
            var montants = new[] { 10m, 1.33m };

            // Attendu.
            var attendu = 13.03m;

            // Actuel.
            var sousTotal = _calculSousTotal.Calculer(montants);
            var actuel = _calculTotal.Calculer(sousTotal, _calculTaxes.Calculer(sousTotal));

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesDeuxMontantsUnNegatif()
        {
            // Variables de travail.
            var montants = new[] { 10m, 1.33m, -5m };

            // Attendu.
            var attendu = 13.03m;

            // Actuel.
            var sousTotal = _calculSousTotal.Calculer(montants);
            var actuel = _calculTotal.Calculer(sousTotal, _calculTaxes.Calculer(sousTotal));

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesAucunMontant()
        {
            // Variables de travail.
            var montants = new decimal[0];

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var sousTotal = _calculSousTotal.Calculer(montants);
            var actuel = _calculTotal.Calculer(sousTotal, _calculTaxes.Calculer(sousTotal));

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesNull()
        {
            // Variables de travail.
            var montants = null as decimal[];

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var sousTotal = _calculSousTotal.Calculer(montants);
            var actuel = _calculTotal.Calculer(sousTotal, _calculTaxes.Calculer(sousTotal));

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
