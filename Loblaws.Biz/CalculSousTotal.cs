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
            return 0m;
        }
    }
}
