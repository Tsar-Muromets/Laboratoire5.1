using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Laboratoire5._1
{
    public class PersonnageGestionVM
    {
        private Personnage personnageModel;

        private ObservableCollection<Personnage> allPersonnages;
        private Personnage selectedPersonnage;

        private Dictionary<string, string> errorList;

        private RelayCommand creerPersonnageCommand;
        private RelayCommand supprimerPersonnageCommand;
        private RelayCommand modifierPersonnageCommand;

        public event EventHandler DemandeFermeture;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PersonnageGestionVM()
        {
            errorList = new Dictionary<string, string>();
            errorList["SelectedPersonnage"] = "";
            errorList["AllPersonnages"] = "";

            using (Labo5DbContext db = new Labo5DbContext())
            {
                allPersonnages = new ObservableCollection<Personnage>(db.Personnages.ToList());
            }
            //foreach (Personnage pStats in allPersonnages)
            //{
            //    PersonnageInfoVM pIVM = new PersonnageInfoVM(pStats);
            //    PersonnageInfoList.Add(pIVM);

            //}
        }

        public Personnage SelectedPersonnage
        {
            get
            {
                return selectedPersonnage;
            }
            set
            {
                selectedPersonnage = value;
                if(selectedPersonnage == null)
                {
                    errorList["SelectedPersonnage"] = "Aucun personnage de sélectionné";
                }
                else
                {
                    errorList["SelectedPersonnage"] = "";
                }
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Personnage> AllPersonnages
        {
            get
            {
                return allPersonnages;
            }
            set
            {
                allPersonnages = value;
                if(allPersonnages == null)
                {
                    errorList["AllPersonnages"] = "Vous devez avoir des personnages";
                }
                else
                {
                    errorList["AllPersonnages"] = "";
                }
                NotifyPropertyChanged();
            }
        }

        //public ICommand CreerPersonnage
        //{
        //    get
        //    {
        //        if (creerPersonnageCommand == null)
        //        {
        //            creerPersonnageCommand = new RelayCommand(Creer, CanCreer);
        //        }

        //        return creerPersonnageCommand;
        //    }
        //}

        //private bool CanCreer(object o)
        //{
        //    foreach (KeyValuePair<string, string> error in errorList)
        //    {
        //        if (error.Value != "")
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //private void Creer(object o)
        //{
        //    DetailsAttaqueView maisonView = new DetailsAttaqueView();

        //    if (maisonView.ShowDialog() == true)
        //    {
        //        MessageBox.Show("VRAI!!");
        //        PersonnageInfoVM viewModel = (PersonnageInfoVM)maisonView.DataContext;

        //    }
        //    else
        //    {
        //        MessageBox.Show("FAUX!!");
        //    }

        //    //using (Labo5DbContext dbContext = new Labo5DbContext())
        //    //{
        //    //    //si egal 0, nouvelle maison
        //    //    if (personnageModel.PersonnageID == 0)
        //    //    {
        //    //        dbContext.Entry(personnageModel).State = EntityState.Added;

        //    //    }
        //    //    else //si different de 0, maison existante que je modifie
        //    //    {
        //    //        dbContext.Entry(personnageModel).State = EntityState.Modified;
        //    //    }

        //    //    dbContext.SaveChanges();
        //    //}

        //    DemandeFermeture?.Invoke(this, new EventArgs());
        //}
        public ICommand SupprimerPersonnageCommand
        {
            get
            {
                if (supprimerPersonnageCommand == null)
                {
                    supprimerPersonnageCommand = new RelayCommand(SupprimerPersonnage, CanSupprimerPersonnage);
                }

                return supprimerPersonnageCommand;
            }
        }

        private bool CanSupprimerPersonnage(object o)
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

        private void SupprimerPersonnage(object o)
        {
            using(Labo5DbContext db = new Labo5DbContext()){
                db.Entry(selectedPersonnage).State = EntityState.Deleted;
                //AllPersonnages.Remove(selectedPersonnage);
                db.SaveChanges();
                
            }
            
            
            //NotifyPropertyChanged("Attaques");
        }

        public ICommand ModifierPersonnageCommand
        {
            get
            {
                if (modifierPersonnageCommand == null)
                {
                    modifierPersonnageCommand = new RelayCommand(ModifierPersonnage, CanModifierPersonnage);
                }

                return modifierPersonnageCommand;
            }
        }

        private bool CanModifierPersonnage(object o)
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

        private void ModifierPersonnage(object o)
        {

            PersonnageInfoVM personnageInfoVM;

            using(Labo5DbContext db = new Labo5DbContext())
            {
                Personnage personnageModel = db.Personnages.Include("Attaques").Where(p => p.PersonnageID == selectedPersonnage.PersonnageID).FirstOrDefault();

                personnageInfoVM = new PersonnageInfoVM(personnageModel);
            }

            DetailsPersonnageView detailsPersonnageView = new DetailsPersonnageView(personnageInfoVM);

            if (detailsPersonnageView.ShowDialog() == true)
            {
                MessageBox.Show("VRAI!!");
            }
            else
            {
                MessageBox.Show("FAUX!!");
            }
        }
    }
}
