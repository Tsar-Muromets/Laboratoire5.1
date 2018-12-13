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
    /// Interaction logic for DetailsPersonnageView.xaml
    /// </summary>
    public partial class DetailsPersonnageView : Window
    {
        public DetailsPersonnageView()
        {
            InitializeComponent();

            PersonnageInfoVM personnageInfoVM = new PersonnageInfoVM();
            this.DataContext = personnageInfoVM;
            personnageInfoVM.DemandeFermeture += Fermeture;
        }

        public DetailsPersonnageView(PersonnageInfoVM pVM)
        {
            InitializeComponent();

            this.DataContext = pVM;
            pVM.DemandeFermeture += Fermeture;
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
