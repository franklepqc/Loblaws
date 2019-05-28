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
            _calculTotal = new CalculTotal(_calculSousTotal, _calculTaxes);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_Succes()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m, SujetTaxes = true }
            };

            // Attendu.
            var attendu = 11.50m;

            // Actuel.
            var actuel = _calculTotal.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesDeuxMontants()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m, SujetTaxes = true },
                new Article() { Prix = 1.33m, SujetTaxes = true }
            };

            // Attendu.
            var attendu = 13.03m;

            // Actuel.
            var actuel = _calculTotal.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesTroisMontantsDeuxTaxables()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m, SujetTaxes = true },
                new Article() { Prix = 1.33m, SujetTaxes = true },
                new Article() { Prix = 6.22m, SujetTaxes = false }
            };

            // Attendu.
            var attendu = 17.55m + 1.70m;   // Sous-total + taxes.

            // Actuel.
            var actuel = _calculTotal.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesDeuxMontantsUnNegatif()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m, SujetTaxes = true },
                new Article() { Prix = 1.33m, SujetTaxes = true },
                new Article() { Prix = -5m, SujetTaxes = true }
            };

            // Attendu.
            var attendu = 13.03m;

            // Actuel.
            var actuel = _calculTotal.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesAucunMontant()
        {
            // Variables de travail.
            var montants = new IArticle[0];

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calculTotal.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calculs intégrés")]
        [TestMethod]
        public void Calcul_SuccesNull()
        {
            // Variables de travail.
            var montants = null as IArticle[];

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calculTotal.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
