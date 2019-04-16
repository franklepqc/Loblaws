using System;

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
            return Math.Max(0m, sousTotal) + Math.Max(0m, taxes);
        }
    }
}
