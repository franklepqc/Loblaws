namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation du calcul.
    /// </summary>
    public class CalculTaxes : Interfaces.ICalculTaxes
    {
        /// <summary>
        /// Calcule le montant des taxes.
        /// </summary>
        /// <param name="sousTotal">Sous-total.</param>
        /// <returns>Montant des taxes.</returns>
        public decimal Calculer(decimal sousTotal)
        {
            return 0m;
        }
    }
}
