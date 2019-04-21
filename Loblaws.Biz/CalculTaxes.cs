using System;

namespace Loblaws.Biz
{
    /// <summary>
    /// Implémentation du calcul.
    /// </summary>
    public class CalculTaxes : Interfaces.ICalculTaxes
    {
        /// <summary>
        /// Taxes.
        /// </summary>
        public const decimal TAXES = 0.15m;

        /// <summary>
        /// Calcule le montant des taxes.
        /// </summary>
        /// <param name="sousTotal">Sous-total.</param>
        /// <returns>Montant des taxes.</returns>
        public decimal Calculer(decimal sousTotal)
        {
            decimal calcul = Math.Max(0m, sousTotal) * TAXES;

            return calcul.RoundCurrency();
        }
    }
}
