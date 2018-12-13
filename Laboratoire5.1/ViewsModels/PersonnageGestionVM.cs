using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Laboratoire5._1
{
    public class PersonnageGestionVM
    {
        private Personnage personnageModel;

        private List<Personnage> allPersonnages;

        private Dictionary<string, string> errorList;

        private ObservableCollection<PersonnageInfoVM> personnageInfoList;

        private RelayCommand creerPersonnageCommand;

        public event EventHandler DemandeFermeture;

        public ObservableCollection<PersonnageInfoVM> PersonnageInfoList
        {
            get
            {
                return personnageInfoList;
            }

            set
            {
                personnageInfoList = value;
            }
        }

        public List<Personnage> AllPersonnages
        {
            get
            {
                return allPersonnages;
            }

            set
            {
                allPersonnages = value;
            }
        }

        public PersonnageGestionVM()
        {
            PersonnageInfoList = new ObservableCollection<PersonnageInfoVM>();
            using (Labo5DbContext db = new Labo5DbContext())
            {
                allPersonnages = db.Personnages.ToList();
            }
            foreach (Personnage pStats in allPersonnages)
            {
                PersonnageInfoVM pIVM = new PersonnageInfoVM(pStats);
                PersonnageInfoList.Add(pIVM);

            }
        }

        public ICommand CreerPersonnage
        {
            get
            {
                if (creerPersonnageCommand == null)
                {
                    creerPersonnageCommand = new RelayCommand(Creer, CanCreer);
                }

                return creerPersonnageCommand;
            }
        }

        private bool CanCreer(object o)
        {
            foreach (KeyValuePair<string, string> error in errorList)
            {
                if (error.Value != "")
                {
                    return false;
                }
            }

            return true;
        }

        private void Creer(object o)
        {
            DetailsAttaqueView maisonView = new DetailsAttaqueView();

            if (maisonView.ShowDialog() == true)
            {
                MessageBox.Show("VRAI!!");
                PersonnageInfoVM viewModel = (PersonnageInfoVM)maisonView.DataContext;

            }
            else
            {
                MessageBox.Show("FAUX!!");
            }

            //using (Labo5DbContext dbContext = new Labo5DbContext())
            //{
            //    //si egal 0, nouvelle maison
            //    if (personnageModel.PersonnageID == 0)
            //    {
            //        dbContext.Entry(personnageModel).State = EntityState.Added;

            //    }
            //    else //si different de 0, maison existante que je modifie
            //    {
            //        dbContext.Entry(personnageModel).State = EntityState.Modified;
            //    }

            //    dbContext.SaveChanges();
            //}

            DemandeFermeture?.Invoke(this, new EventArgs());
        }
    }
}
