using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class PartieInfoVM : INotifyPropertyChanged
    {
        private Partie partieModel;

        private Dictionary<string, string> errorList;

        //private RelayCommand changerCommand;
        //private RelayCommand sauvegarderCommand;
        //private RelayCommand supprimerCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public PartieInfoVM()
        {
            errorList = new Dictionary<string, string>();
            errorList["Adresse"] = "";

            partieModel = new Partie();

            using (Labo5DbContext db = new Labo5DbContext())
            {
                partieModel.Personnages = db.Personnages.ToList();
            }
        }

        public PartieInfoVM(Partie p)
        {
            errorList = new Dictionary<string, string>();
            errorList["Adresse"] = "";

            partieModel = p;

            using(Labo5DbContext db = new Labo5DbContext())
            {
                partieModel.Personnages = db.Personnages.ToList();
            }
            
        }

        public ICollection<Personnage> Personnages
        {
            get
            {
                return partieModel.Personnages;
            }
            set
            {
                partieModel.Personnages = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Date
        {
            get
            {
                return partieModel.Date;
            }
            set
            {
                partieModel.Date = value;
                NotifyPropertyChanged();
            }
        }
    }
}
