using Loblaws.Biz.Interfaces;
using System.Collections.Generic;

namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation du total.
    /// </summary>
    public class CalculTotal : ICalculTotal
    {
        /// <summary>
        /// Membres injectés.
        /// </summary>
        private readonly ICalculSousTotal _calculSousTotal;
        private readonly ICalculTaxes _calculTaxes;

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="calculSousTotal">Service de calcul du sous-total.</param>
        /// <param name="calculTaxes">Service du calcul des taxes.</param>
        public CalculTotal(ICalculSousTotal calculSousTotal, ICalculTaxes calculTaxes)
        {
            _calculSousTotal = calculSousTotal;
            _calculTaxes = calculTaxes;
        }

        /// <summary>
        /// Calcule le total.
        /// </summary>
        /// <param name="articles">Articles.</param>
        /// <returns>Montant total.</returns>
        public decimal Calculer(IEnumerable<IArticle> articles) =>
            _calculSousTotal.Calculer(articles) +
            _calculTaxes.Calculer(articles);
    }
}
