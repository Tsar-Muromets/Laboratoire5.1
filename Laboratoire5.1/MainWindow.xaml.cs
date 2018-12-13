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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratoire5._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PersonnageMI_Click(object sender, RoutedEventArgs e)
        {
            //GestionPersonnagesView gestionPersonnageView = new GestionPersonnagesView();
            //gestionPersonnageView.ShowDialog();

            GestionPersonnagesView gestionPersonnageView = new GestionPersonnagesView();

            if (gestionPersonnageView.ShowDialog() == true)
            {
                MessageBox.Show("VRAI!!");
                //VM viewModel = (PartieInfoVM)gestionPersonnageView.DataContext;
            }
            else
            {
                MessageBox.Show("FAUX!!");
            }
        }

        private void AttaqueMI_Click(object sender, RoutedEventArgs e)
        {
            GestionAttaquesView gestionAttaquesView = new GestionAttaquesView();
            gestionAttaquesView.ShowDialog();
        }

        private void NouvellePartieMI_Click(object sender, RoutedEventArgs e)
        {
            NouvellePartieView nouvellePartieView = new NouvellePartieView();
            nouvellePartieView.ShowDialog();
        }

        private void NouvellePartie_Click(object sender, RoutedEventArgs e)
        {
            NouvellePartieView partieView = new NouvellePartieView();

            if(partieView.ShowDialog() == true)
            {
                MessageBox.Show("VRAI!!");
                PartieInfoVM viewModel = (PartieInfoVM)partieView.DataContext;
            }
            else
            {
                MessageBox.Show("FAUX!!");
            }
        }

        private void TestDetailsDmg_Click(object sender, RoutedEventArgs e)
        {
            DetailsAttaqueView detailsAttaqueView = new DetailsAttaqueView();
            
            if (detailsAttaqueView.ShowDialog() == true)
            {
                MessageBox.Show("VRAI!!");
                AttaqueInfoVM viewModel = (AttaqueInfoVM)detailsAttaqueView.DataContext;
            }
            else
            {
                MessageBox.Show("FAUX!!");
            }
        }
    }
}
