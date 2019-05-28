using Loblaws.Biz.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Loblaws.Biz.Tests
{
    [TestClass]
    public class CalculSousTotalTests
    {
        /// <summary>
        /// Service à tester.
        /// </summary>
        private static ICalculSousTotal _calcul;

        /// <summary>
        /// Initialiser le service à tester.
        /// </summary>
        /// <param name="testContext">Contexte de test.</param>
        [ClassInitialize]
        public static void Initialiser(TestContext testContext)
        {
            _calcul = new CalculSousTotal();
        }

        [TestCategory(@"Calcul du sous-total")]
        [TestMethod]
        public void UnMontant_Succes()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m }
            };

            // Attendu.
            var attendu = 10m;

            // Actuel.
            var actuel = _calcul.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du sous-total")]
        [TestMethod]
        public void DeuxMontant_Succes()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m },
                new Article() { Prix = 21.49m }
            };

            // Attendu.
            var attendu = 31.49m;

            // Actuel.
            var actuel = _calcul.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du sous-total")]
        [TestMethod]
        public void TroisMontantAvecUnSousZero_Succes()
        {
            // Variables de travail.
            var montants = new[]
            {
                new Article() { Prix = 10m },
                new Article() { Prix = 21.49m },
                new Article() { Prix = -5m }
            };

            // Attendu.
            var attendu = 31.49m;

            // Actuel.
            var actuel = _calcul.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du sous-total")]
        [TestMethod]
        public void AucunMontant_Succes()
        {
            // Variables de travail.
            var montants = new IArticle[0];

            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calcul.Calculer(montants);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }

        [TestCategory(@"Calcul du sous-total")]
        [TestMethod]
        public void Null_Succes()
        {
            // Attendu.
            var attendu = 0m;

            // Actuel.
            var actuel = _calcul.Calculer(null);

            // Assertion.
            Assert.AreEqual(attendu, actuel);
        }
    }
}
