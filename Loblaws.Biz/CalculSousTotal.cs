using System.Linq;

namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation de l'interface.
    /// </summary>
    public class CalculSousTotal : Interfaces.ICalculSousTotal
    {
        /// <summary>
        /// Calcule le sous-total.
        /// </summary>
        /// <param name="prixArticles">Prix des articles.</param>
        /// <returns>Sous-total.</returns>
        public decimal Calculer(decimal[] prixArticles) =>
            (prixArticles ?? new decimal[0])    // Vérification du null.
                .Where(prix => prix > 0m)       // Filtrer les prix en-deça de zéro.
                .Sum();                         // Opération feuille : sommation.
    }
}
