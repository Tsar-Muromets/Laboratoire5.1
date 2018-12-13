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
    /// Interaction logic for NouvellePartieView.xaml
    /// </summary>
    public partial class NouvellePartieView : Window
    {
        public NouvellePartieView()
        {
            InitializeComponent();

            PartieInfoVM partieInfoVM = new PartieInfoVM();
            this.DataContext = partieInfoVM;
            //partieInfoVM.DemandeFermeture += Fermeture;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
