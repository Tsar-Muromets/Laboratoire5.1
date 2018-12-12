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
        private string nom;

        public event PropertyChangedEventHandler PropertyChanged;

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


        }

        public PersonnageInfoVM(Personnage p)
        {
            errorList = new Dictionary<string, string>();
            errorList["Nom"] = "";
            errorList["PointsDeVie"] = "";
            errorList["PointsDeMana"] = "";
            errorList["Image"] = "";

            personnageModel = p;

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
    }
}
