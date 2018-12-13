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
    /// Interaction logic for GestionAttaquesView.xaml
    /// </summary>
    public partial class GestionAttaquesView : Window
    {
        public GestionAttaquesView()
        {
            InitializeComponent();
            AttaqueGestionVM attaqueGestionVM = new AttaqueGestionVM();
            this.DataContext = attaqueGestionVM;
        }

        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            DetailsAttaqueView detailsAttaqueView = new DetailsAttaqueView();
            detailsAttaqueView.ShowDialog();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            DetailsAttaqueView detailsAttaqueView = new DetailsAttaqueView();
            detailsAttaqueView.ShowDialog();
        }

        private void AttaqueStats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAttaqueStats.SelectedItems == null)
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
            else
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
        }
    }
}
