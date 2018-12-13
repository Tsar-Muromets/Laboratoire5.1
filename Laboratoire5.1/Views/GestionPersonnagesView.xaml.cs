using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laboratoire5._1
{
    /// <summary>
    /// Interaction logic for GestionPersonnagesView.xaml
    /// </summary>
    public partial class GestionPersonnagesView : Window
    {
        public GestionPersonnagesView()
        {
            InitializeComponent();

            PersonnageGestionVM personnageGestionVM = new PersonnageGestionVM();
            this.DataContext = personnageGestionVM;
            //personnageInfoVM.Dema
        }

        public GestionPersonnagesView(PersonnageGestionVM pIVM)
        {
            InitializeComponent();

            PersonnageGestionVM personnageGestionVM = pIVM;
            this.DataContext = personnageGestionVM;
            //personnageInfoVM.Dema
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            DetailsPersonnageView detailsPersonnageView = new DetailsPersonnageView();
            detailsPersonnageView.ShowDialog();
        }

        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            DetailsPersonnageView detailsPersonnageView = new DetailsPersonnageView();
            detailsPersonnageView.ShowDialog();
        }

        private void Fermeture(object o, EventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void PersoStats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgPersoStats.SelectedItems == null)
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }else
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
        }
    }
}
