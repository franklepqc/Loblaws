using Loblaws.Biz.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation de l'interface.
    /// </summary>
    public class CalculSousTotal : ICalculSousTotal
    {
        /// <summary>
        /// Calcule le sous-total.
        /// </summary>
        /// <param name="articles">Articles.</param>
        /// <returns>Sous-total.</returns>
        public decimal Calculer(IEnumerable<IArticle> articles) =>
            (articles ?? Enumerable.Empty<IArticle>())  // Vérification du null.
                .Select(article => article.Prix)        // Sélection du prix.
                .Where(prix => prix > 0m)               // Filtrer les prix en-deça de zéro.
                .Sum();                                 // Opération feuille : sommation.
    }
}
