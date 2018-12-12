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
    public class AttaqueInfoVM : INotifyPropertyChanged
    {
        Attaque attaqueModel;

        private RelayCommand sauvegarderCommand;

        private Dictionary<string, string> errorList;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler DemandeFermeture;

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
                NotifyPropertyChanged();
            }
        }

        public int Dommage
        {
            get
            {
                return attaqueModel.Degats;
            }
            set
            {
                attaqueModel.Degats = value;
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

            using (Labo5DbContext db = new Labo5DbContext())
            {
                //si egal 0, nouvelle maison
                if (attaqueModel.AttaqueID == 0)
                {
                    db.Entry(attaqueModel).State = EntityState.Added;

                    //dbContext.Maisons.Add(maisonModel);
                }
                else //si different de 0, maison existante que je modifie
                {
                    db.Entry(attaqueModel).State = EntityState.Modified;
                }

                db.SaveChanges();
            }

            DemandeFermeture?.Invoke(this, new EventArgs());
        }
    }
}
