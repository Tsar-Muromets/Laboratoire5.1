using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    public class AttaqueGestionVM
    {
        private Attaque attaqueModel;

        private List<Attaque> allAttaques;

        private Dictionary<string, string> errorList;

        private ObservableCollection<AttaqueInfoVM> attaqueInfoList;

        public ObservableCollection<AttaqueInfoVM> AttaqueInfoList
        {
            get
            {
                return attaqueInfoList;
            }

            set
            {
                attaqueInfoList = value;
            }
        }

        public List<Attaque> AllAttaques
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

        public AttaqueGestionVM()
        {
            AttaqueInfoList = new ObservableCollection<AttaqueInfoVM>();
            using(Labo5DbContext db = new Labo5DbContext())
            {
                allAttaques = db.Attaques.ToList();
            }
            foreach(Attaque aStats in allAttaques)
            {
                AttaqueInfoVM aIVM = new AttaqueInfoVM(aStats);
                AttaqueInfoList.Add(aIVM);
            }
        }
    }
}
