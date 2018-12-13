using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace Laboratoire5._1
{
    public class AttaqueInfoVM: INotifyPropertyChanged
    {
        private Attaque attaqueModel;

        private Dictionary<string, string> errorList;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler DemandeFermeture;

        private RelayCommand sauvegarderCommand;
        private RelayCommand ajouterAttaqueCommand;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AttaqueInfoVM()
        {
            errorList = new Dictionary<string, string>();
            errorList["Adresse"] = "";

            attaqueModel = new Attaque();
        }

        public AttaqueInfoVM(Attaque a)
        {
            errorList = new Dictionary<string, string>();
            errorList["Adresse"] = "";

            attaqueModel = a;
        }

        public string Nom
        {
            get
            {
                return attaqueModel.Nom;
            }

            set
            {
                attaqueModel.Nom = value;
                if (value.Count() >= 50)
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

        public int Degats
        {
            get
            {
                return attaqueModel.Degats;
            }

            set
            {
                attaqueModel.Degats = value;
                if (value <= 5 || value >= 150)
                {
                    errorList["Dommage"] = "Le dommage ne doivent pas etre inferieur a 5 ou supperieur a 150";
                }
                else
                {
                    errorList["Dommage"] = "";
                }
                NotifyPropertyChanged();
            }
        }

        public int Mana
        {
            get
            {
                return attaqueModel.Mana;
            }

            set
            {
                attaqueModel.Mana = value;
                if (value <= 0 || value >= 50)
                {
                    errorList["Mana"] = "Le mana ne doivent pas etre inferieur a 0 ou supperieur a 50";
                }
                else
                {
                    errorList["Mana"] = "";
                }
                NotifyPropertyChanged();
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

            using (Labo5DbContext dbContext = new Labo5DbContext())
            {
                //si egal 0, nouvelle maison
                if (attaqueModel.AttaqueID == 0)
                {

                    dbContext.Entry(attaqueModel).State = EntityState.Added;
                }
                else //si different de 0, maison existante que je modifie
                {
                    dbContext.Entry(attaqueModel).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }

            DemandeFermeture?.Invoke(this, new EventArgs());
        }

        
    }
    
}
