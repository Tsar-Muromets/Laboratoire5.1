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
    /// Interaction logic for DetailsAttaqueView.xaml
    /// </summary>
    public partial class DetailsAttaqueView : Window
    {
        public DetailsAttaqueView()
        {
            InitializeComponent();

            AttaqueInfoVM attaqueInfoVM = new AttaqueInfoVM();
            this.DataContext = attaqueInfoVM;
            attaqueInfoVM.DemandeFermeture += Fermeture;
        }

        public DetailsAttaqueView(AttaqueInfoVM aVM)
        {
            InitializeComponent();

            this.DataContext = aVM;
            aVM.DemandeFermeture += Fermeture;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void Fermeture(object o, EventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
