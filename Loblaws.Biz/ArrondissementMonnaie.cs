using System;

namespace Loblaws.Biz
{
    /// <summary>
    /// Extensions pour l'arrondissement au centime.
    /// </summary>
    public static class ArrondissementMonnaie
    {
        /// <summary>
        /// Arrondir au centime près.
        /// </summary>
        /// <param name="montant">Montant.</param>
        /// <returns>Montant arrondi.</returns>
        public static decimal RoundCurrency(this decimal montant) =>
            decimal.Round(montant, 2, MidpointRounding.AwayFromZero);
    }
}
