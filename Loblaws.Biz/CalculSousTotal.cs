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
        public decimal Calculer(decimal[] prixArticles)
        {
            // Variables.
            decimal somme = 0m;

            if (null != prixArticles)
            {
                foreach (decimal prix in prixArticles)
                {
                    if (prix > 0m)
                    {
                        somme += prix;
                    }
                }
            }

            return somme;
        }
    }
}
