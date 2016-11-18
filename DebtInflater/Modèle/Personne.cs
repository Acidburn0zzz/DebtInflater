using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DebtInflater.Modèle
{
    public class Personne : INotifyPropertyChanged
    {
        private string prénom;
        public string Prénom {
            get
            {
                return prénom;
            }
            set
            {
                prénom = value;
                NotifyPropertyChanged();
            }
        }
        private string nom;
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Créer une nouvelle personne 
        /// </summary>
        /// <param name="prénom">Le prénom de la personne</param>
        /// <param name="nom">Le nom de la personne</param>
        public Personne(string prénom, string nom)
        {
            Prénom = prénom;
            Nom = nom;
        }
        /// <summary>
        /// Créer une nouvelle personne vide
        /// </summary>
        public Personne()
        {
            Prénom = "";
            Nom = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
