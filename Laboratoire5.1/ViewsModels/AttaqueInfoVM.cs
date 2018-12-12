using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class AttaqueInfoVM: INotifyPropertyChanged
    {
        private Attaque attaqueModel;
        private string nom;
        private int dommage;
        private int mana;

        private Dictionary<string, string> errorList;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AttaqueInfoVM(string n, int d, int m)
        {
            Nom = n;
            Dommage = d;
            Mana = m; 
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
                if (string.IsNullOrEmpty(value))
                {
                    errorList["Nom"] = "Le nom ne doit pas etre vide";
                }
                else if (value.Count() <= 50)
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

        public int Dommage
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
    }
}
