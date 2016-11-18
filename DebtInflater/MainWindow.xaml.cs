using DebtInflater.IHM;
using DebtInflater.Modèle;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.ComponentModel;

namespace DebtInflater
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ObservableCollection<Personne> personnes = new ObservableCollection<Personne>();
        public MainWindow()
        {
            InitializeComponent();
            //Désérialisation
            XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<Personne>));
            try
            {
                TextReader lecteur = new StreamReader("Collection.xml");
                ObservableCollection<Personne> collection = x.Deserialize(lecteur) as ObservableCollection<Personne>;
                if (collection != null)
                    personnes = collection;
            }
            catch(FileNotFoundException e)
            {
                //Demander à l'utilisateur si cela est normale de ne pas trouver de fichier de sauvegarde
            }
            
            PersonneListView.ItemsSource = personnes;
        }
        private void AjouterPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            Personne personne = new Personne();
            PersonneDialogue dialogue = new PersonneDialogue(personne);
            dialogue.ShowDialog();
            if (dialogue.DialogResult == true)
                personnes.Add(personne);
        }

        private void ModifierPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonneListView.SelectedItem == null) return;
            Personne personne = PersonneListView.SelectedItem as Personne;
            PersonneDialogue dialogue = new PersonneDialogue(personne);
            dialogue.ShowDialog();
        }

        private void SupprimerPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonneListView.SelectedItem != null)
                personnes.Remove(PersonneListView.SelectedItem as Personne);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //Sérialisation
            XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<Personne>));
            TextWriter writer = new StreamWriter("Collection.xml");
            x.Serialize(writer, personnes);
        }
    }
}
