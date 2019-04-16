using Loblaws.Biz.Interfaces;
using Loblaws.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Loblaws.Wpf.ViewModels
{
    /// <summary>
    /// Classe qui régit l'intéraction entre l'interface graphique et le back-end.
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// Articles à scanner.
        /// </summary>
        private static Tuple<string, decimal>[] _articlesScan = new Tuple<string, decimal>[5]
        {
            new Tuple<string, decimal>("Kit Kat", 0.99m),
            new Tuple<string, decimal>("Ramens", 2.49m),
            new Tuple<string, decimal>("Hamberger Helper", 11.49m),
            new Tuple<string, decimal>("Macaroni", 11.99m),
            new Tuple<string, decimal>("Sauce tomate", 10m)
        };
        
        /// <summary>
        /// Facteur de hasard.
        /// </summary>
        private Random _facteurHasard = new Random();

        /// <summary>
        /// Calculateurs.
        /// </summary>
        private readonly ICalculSousTotal _calculSousTotal;
        private readonly ICalculTaxes _calculTaxes;
        private readonly ICalculTotal _calculTotal;

        /// <summary>
        /// Conteneurs.
        /// </summary>
        private decimal _sousTotal, _montantTaxes, _total;

        /// <summary>
        /// Items de la commande.
        /// </summary>
        public ObservableCollection<ItemCommande> Items { get; private set; } = new ObservableCollection<ItemCommande>();

        /// <summary>
        /// Obtient ou assigne le sous-total.
        /// </summary>
        public decimal SousTotal
        {
            get => _sousTotal;
            set => SetProperty(ref _sousTotal, value);
        }

        /// <summary>
        /// Obtient ou assigne le montant des taxes.
        /// </summary>
        public decimal MontantTaxes
        {
            get => _montantTaxes;
            set => SetProperty(ref _montantTaxes, value);
        }

        /// <summary>
        /// Obtient ou assigne le total.
        /// </summary>
        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        /// <summary>
        /// Commande d'ajout d'un item.
        /// </summary>
        public ICommand CommandeAjouterItem { get; private set; }

        /// <summary>
        /// Commande de scan d'un item.
        /// </summary>
        public ICommand CommandeScannerItem { get; private set; }

        /// <summary>
        /// Commande de suppression d'un item.
        /// </summary>
        public ICommand CommandeSupprimerItem { get; private set; }

        /// <summary>
        /// Commande du nettoyage.
        /// </summary>
        public ICommand CommandeNettoyerItems { get; private set; }

        /// <summary>
        /// Commande du calcul.
        /// </summary>
        public ICommand CommandeCalculer { get; private set; }

        /// <summary>
        /// Constructeur par injection.
        /// </summary>
        /// <param name="calculSousTotal">Calcul du sous-total.</param>
        /// <param name="calculTaxes">Calcul des taxes.</param>
        /// <param name="calculTotal">Calcul du total.</param>
        public MainWindowViewModel(ICalculSousTotal calculSousTotal, ICalculTaxes calculTaxes, ICalculTotal calculTotal)
        {
            _calculSousTotal = calculSousTotal;
            _calculTaxes = calculTaxes;
            _calculTotal = calculTotal;

            CommandeAjouterItem = new DelegateCommand(AjouterItem);
            CommandeScannerItem = new DelegateCommand(ScannerItem);
            CommandeSupprimerItem = new DelegateCommand<ItemCommande>(SupprimerItem);
            CommandeNettoyerItems = new DelegateCommand(Nettoyer);
            CommandeCalculer = new DelegateCommand(Calculer);

            // Ajout d'un élément, prêt pour l'édition.
            AjouterItem();
        }

        /// <summary>
        /// Effectue le nettoyage.
        /// </summary>
        private void Nettoyer()
        {
            Items.Clear();

            // Remettre à zéro.
            SousTotal = 0m;
            MontantTaxes = 0m;
            Total = 0m;

            // Un élément de base.
            AjouterItem();
        }

        /// <summary>
        /// Ajoute un item dans la liste à partir d'un scan.
        /// </summary>
        private void ScannerItem()
        {
            var nouvelItem = _articlesScan[_facteurHasard.Next(0, 5)];
            AjouterItem(nouvelItem.Item1, nouvelItem.Item2);

            // Recalculer le total.
            Calculer();
        }

        /// <summary>
        /// Ajoute un item dans la liste.
        /// </summary>
        private void AjouterItem()
        {
            AjouterItem(null, null);
        }

        /// <summary>
        /// Ajoute un item dans la liste.
        /// </summary>
        /// <param name="nom">Nom de l'article.</param>
        /// <param name="prix">Prix de l'article.</param>
        private void AjouterItem(string nom, decimal? prix)
        {
            Items.Add(new ItemCommande()
            {
                Nom = nom,
                Prix = prix
            });
        }

        /// <summary>
        /// Supprimer un item dans la liste.
        /// </summary>
        /// <param name="item">Item de la liste.</param>
        private void SupprimerItem(ItemCommande item)
        {
            // Retirer l'élément.
            Items.Remove(item);

            // Recalculer le total.
            Calculer();
        }

        /// <summary>
        /// Calcule le sous-total, taxes et le total.
        /// </summary>
        private void Calculer()
        {
            SousTotal = _calculSousTotal.Calculer(Items.Where(p => p.Prix.HasValue).Select(k => k.Prix.Value).ToArray());
            MontantTaxes = _calculTaxes.Calculer(SousTotal);
            Total = _calculTotal.Calculer(SousTotal, MontantTaxes);
        }
    }
}
