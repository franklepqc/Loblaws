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
        #region Fields

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
        /// Calculateurs.
        /// </summary>
        private readonly ICalculSousTotal _calculSousTotal;
        private readonly ICalculTaxes _calculTaxes;
        private readonly ICalculTotal _calculTotal;

        /// <summary>
        /// Facteur de hasard.
        /// </summary>
        private Random _facteurHasard = new Random();

        /// <summary>
        /// Sélection.
        /// </summary>
        private ItemCommande _selection;

        /// <summary>
        /// Conteneurs.
        /// </summary>
        private decimal _sousTotal, _montantTaxes, _total;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructeur par injection.
        /// </summary>
        /// <param name="calculSousTotal">Calcul du sous-total.</param>
        /// <param name="calculTaxes">Calcul des taxes.</param>
        /// <param name="calculTotal">Calcul du total.</param>
        public MainWindowViewModel(ICalculSousTotal calculSousTotal, ICalculTaxes calculTaxes, ICalculTotal calculTotal)
        {
            // Initialisation des calculs par injection.
            _calculSousTotal = calculSousTotal;
            _calculTaxes = calculTaxes;
            _calculTotal = calculTotal;

            // Initialisation des commandes.
            CommandeScannerItem = new DelegateCommand(ScannerItem);
            CommandeSupprimerItem = new DelegateCommand(SupprimerItem, () => Selection != null);
            CommandeNettoyerItems = new DelegateCommand(Nettoyer);

            // Évènement de collection modifiée.
            Items.CollectionChanged += SurAjoutItemListe;
        }

        #endregion Constructors

        #region Destructors

        /// <summary>
        /// Destructeur.
        /// </summary>
        ~MainWindowViewModel()
        {
            // Évènement de collection modifiée.
            Items.CollectionChanged -= SurAjoutItemListe;
        }

        #endregion Destructors

        #region Properties

        /// <summary>
        /// Commande du nettoyage.
        /// </summary>
        public ICommand CommandeNettoyerItems { get; private set; }

        /// <summary>
        /// Commande de scan d'un item.
        /// </summary>
        public ICommand CommandeScannerItem { get; private set; }

        /// <summary>
        /// Commande de suppression d'un item.
        /// </summary>
        public DelegateCommandBase CommandeSupprimerItem { get; private set; }

        /// <summary>
        /// Items de la commande.
        /// </summary>
        public ObservableCollection<ItemCommande> Items { get; private set; } = new ObservableCollection<ItemCommande>();

        /// <summary>
        /// Obtient ou assigne le montant des taxes.
        /// </summary>
        public decimal MontantTaxes
        {
            get => _montantTaxes;
            set => SetProperty(ref _montantTaxes, value);
        }

        /// <summary>
        /// Sélection.
        /// </summary>
        public ItemCommande Selection
        {
            get => _selection;
            set
            {
                SetProperty(ref _selection, value);
                CommandeSupprimerItem.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Obtient ou assigne le sous-total.
        /// </summary>
        public decimal SousTotal
        {
            get => _sousTotal;
            set => SetProperty(ref _sousTotal, value);
        }

        /// <summary>
        /// Obtient ou assigne le total.
        /// </summary>
        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Calcule le sous-total, taxes et le total.
        /// </summary>
        private void Calculer()
        {
            SousTotal = _calculSousTotal.Calculer(Items.Where(p => p.Prix.HasValue).Select(k => k.Prix.Value).ToArray());
            MontantTaxes = _calculTaxes.Calculer(SousTotal);
            Total = _calculTotal.Calculer(SousTotal, MontantTaxes);
        }

        /// <summary>
        /// Effectue le nettoyage.
        /// </summary>
        private void Nettoyer()
        {
            // Vider la liste. Du coup, le calcul se fait à nouveau.
            Items.Clear();
        }

        /// <summary>
        /// Ajoute un item dans la liste à partir d'un scan.
        /// </summary>
        private void ScannerItem()
        {
            // Récupérer un nouvel article aléatoirement.
            var nouvelItem = _articlesScan[_facteurHasard.Next(0, 5)];

            // Ajout dans la liste.
            Items.Add(new ItemCommande()
            {
                Nom = nouvelItem.Item1,
                Prix = nouvelItem.Item2
            });
        }

        /// <summary>
        /// Supprimer un item dans la liste.
        /// </summary>
        /// <param name="item">Item de la liste.</param>
        private void SupprimerItem()
        {
            // Retirer l'élément.
            Items.Remove(Selection);
        }

        /// <summary>
        /// Sur ajout d'un item dans la liste.
        /// </summary>
        /// <param name="sender">Objet appelant la méthode.</param>
        /// <param name="e">Arguments d'ajouts.</param>
        private void SurAjoutItemListe(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Recalculer le total.
            Calculer();
        }

        #endregion Methods
    }
}