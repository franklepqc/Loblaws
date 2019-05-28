using Loblaws.Biz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation du calcul.
    /// </summary>
    public class CalculTaxes : ICalculTaxes
    {
        /// <summary>
        /// Taxes.
        /// </summary>
        public const decimal TAXES = 0.15m;

        /// <summary>
        /// Calcule le montant des taxes.
        /// </summary>
        /// <param name="articles">Articles.</param>
        /// <returns>Montant des taxes.</returns>
        public decimal Calculer(IEnumerable<IArticle> articles) =>
            Math.Max(
                0m,
                decimal.Round(
                    TAXES *
                    (articles ?? Enumerable.Empty<IArticle>())  // Vérification du null.
                        .Where(article => article.SujetTaxes)   // Utiliser seulement les produits dont ils sont sujets aux taxes.
                        .Select(article => article.Prix)        // Sélection du prix.
                        .Where(prix => prix > 0m)               // Filtrer les prix en-deça de zéro.
                        .Sum(),                                 // Opération feuille : sommation.
                    2,                                          // Deux nombres après la décimale.
                    MidpointRounding.AwayFromZero));            // Arrondissement fiscal.
    }
}
