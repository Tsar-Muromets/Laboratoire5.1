using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Labo5GameLib;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.Entity;


namespace Laboratoire5._1
{
    public class PersonnageInfoVM : INotifyPropertyChanged
    {
        private Personnage personnageModel;
        //private string nom;
        //private List<PersonnageType> allTypes;
        //private int pointsDeVie;
        //private int pointDeMana;
        //private BitmapImage image;
        //private ObservableCollection<GameAttaque> listAttaque;  

        private Dictionary<string, string> errorList;


        private ObservableCollection<Attaque> allAttaques;
        private Attaque selectedAttaque;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler DemandeFermeture;

        private RelayCommand sauvegarderCommand;
        private RelayCommand ajouterAttaqueCommand;
        private RelayCommand supprimerAttaqueCommand;


        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PersonnageInfoVM()
        {
            errorList = new Dictionary<string, string>();
            errorList["Nom"] = "";
            errorList["PointsDeVie"] = "";
            errorList["PointsDeMana"] = "";
            errorList["Image"] = "";

            personnageModel = new Personnage();
            

            using (Labo5DbContext db = new Labo5DbContext())
            {
                AllAttaques = new ObservableCollection<Attaque>(db.Attaques.ToList());
                SelectedAttaque = db.Attaques.FirstOrDefault();
            }

        }

        public PersonnageInfoVM(Personnage p)
        {
            errorList = new Dictionary<string, string>();
            errorList["Nom"] = "";
            errorList["PointsDeVie"] = "";
            errorList["PointsDeMana"] = "";
            errorList["Image"] = "";

            personnageModel = p;

        #region Variables
            using (Labo5DbContext db = new Labo5DbContext())
            {
                AllAttaques = new ObservableCollection<Attaque>(db.Attaques.ToList());
                SelectedAttaque = db.Attaques.FirstOrDefault(); SelectedAttaque = db.Attaques.FirstOrDefault();
            }
        }


        public string Nom
        {
            get
            {
                return personnageModel.Nom;
            }

            set
            {
                personnageModel.Nom = value;
                if (string.IsNullOrEmpty(value))
                {
                    errorList["Nom"] = "Le Nom ne doit pas etre vide";
                }

                else if (value.Count() >= 50)
                {
                    errorList["Nom"] = "Le nom doit etre plus court que 50 character";
                }
                else
                {
                    errorList["Nom"] = "";
                }

                NotifyPropertyChanged();
            }
        }

        public int Type
        {
            get
            {
                return personnageModel.Type;
            }

            set
            {
                personnageModel.Type = value;
                NotifyPropertyChanged();
            }
        }

        public PersonnageType SelectedType
        {
            get
            {
                return (PersonnageType)personnageModel.Type;
            }

            set
            {
                personnageModel.Type = (int)value;
                NotifyPropertyChanged();
            }
        }

        public int VieTotal
        {
            get
            {
                return personnageModel.VieTotal;
            }

            set
            {
                personnageModel.VieTotal = value;
                if (value <= 50 || value >= 500)
                {
                    errorList["PointsDeVie"] = "Les points de vie ne doivent pas etre inferieur a 50 ou supperieur a 500";
                }
                else
                {
                    errorList["PointsDeVie"] = "";
                }
                NotifyPropertyChanged();
            }
        }

        public int ManaTotal
        {
            get
            {
                return personnageModel.ManaTotal;
            }

            set
            {
                personnageModel.ManaTotal = value;
                if (value <= 0 || value >= 200)
                {
                    errorList["PointDeMana"] = "Les points de mana ne doivent pas etre inferieur a 0 ou supperieur a 200";
                }
                else
                {
                    errorList["PointDeMana"] = "";
                }
                NotifyPropertyChanged();
            }
        }

        public string ImagePath
        {
            get
            {
                return personnageModel.ImagePath;
            }

            set
            {
                personnageModel.ImagePath = value;
                if (value != null)
                {
                    errorList["Image"] = "Une image est obligatoire";
                }
                else
                {
                    errorList["Image"] = "";
                }
                NotifyPropertyChanged();
            }
        }
        #endregion


        public ObservableCollection<Attaque> Attaques
        {
            get
            {
                return personnageModel.Attaques;
            }
            set
            {
                personnageModel.Attaques = value;
            }
        }

        public ObservableCollection<Attaque> AllAttaques
        {
            get
            {
                return allAttaques;
            }
            set
            {
                allAttaques = value;
            }
        }

        public Attaque SelectedAttaque
        {
            get
            {
                return selectedAttaque;
            }
            set
            {
                selectedAttaque = value;
            }
        }

        public ICommand SauvegarderCommand
        {
            get
            {
                if (sauvegarderCommand == null)
                {
                    sauvegarderCommand = new RelayCommand(Sauvegarder, CanSauvegarder);
                }


                return sauvegarderCommand;
            }
        }
        private bool CanSauvegarder(object o)
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

        private void Sauvegarder(object o)
        {
            Console.WriteLine("Enregistrer dans la DB.");

            using (Labo5DbContext db = new Labo5DbContext())
            {
                //si egal 0, nouvelle maison
                if (personnageModel.PersonnageID == 0)
                {
                    db.Entry(personnageModel).State = EntityState.Added;
                }
                else //si different de 0, maison existante que je modifie
                {
                    db.Entry(personnageModel).State = EntityState.Modified;
                }

                db.SaveChanges();
            }

            DemandeFermeture?.Invoke(this, new EventArgs());
        }
        public ICommand AjouterAttaqueCommand
        {
            get
            {
                if (ajouterAttaqueCommand == null)
                {
                    ajouterAttaqueCommand = new RelayCommand(AjouterAttaque, CanAjouterAttaque);
                }

                return ajouterAttaqueCommand;
            }
        }

        private bool CanAjouterAttaque(object o)
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

        private void AjouterAttaque(object o)
        {

            Attaques.Add(selectedAttaque);
            //NotifyPropertyChanged("Attaques");
        }

        public ICommand SupprimerAttaqueCommand
        {
            get
            {
                if (supprimerAttaqueCommand == null)
                {
                    supprimerAttaqueCommand = new RelayCommand(SupprimerAttaque, CanSupprimerAttaque);
                }

                return supprimerAttaqueCommand;
            }
        }

        private bool CanSupprimerAttaque(object o)
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

        private void SupprimerAttaque(object o)
        {

            Attaques.Remove(selectedAttaque);
            //NotifyPropertyChanged("Attaques");
        }
    }
}
