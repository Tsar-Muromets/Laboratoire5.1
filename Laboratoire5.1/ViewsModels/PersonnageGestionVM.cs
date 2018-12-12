using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    public class PersonnageGestionVM
    {
        private List<Personnage> allPersonnages;

        private ObservableCollection<PersonnageInfoVM> personnageInfoList;

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
    }
}
