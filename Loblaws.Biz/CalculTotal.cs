namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation du total.
    /// </summary>
    public class CalculTotal : Interfaces.ICalculTotal
    {
        /// <summary>
        /// Calcule le total.
        /// </summary>
        /// <param name="sousTotal">Sous-total.</param>
        /// <param name="taxes">Taxes.</param>
        /// <returns>Montant total.</returns>
        public decimal Calculer(decimal sousTotal, decimal taxes)
        {
            return 0m;
        }
    }
}
