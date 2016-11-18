using DebtInflater.Modèle;
using System.Windows;

namespace DebtInflater.IHM
{
    /// <summary>
    /// Logique d'interaction pour PersonneDialogue.xaml
    /// </summary>
    public partial class PersonneDialogue : Window
    {
        private Personne personne;
        private Personne personneEdité;
        public PersonneDialogue(Personne personne)
        {
            InitializeComponent();
            personneEdité = new Personne(personne.Prénom, personne.Nom);
            DataContext = personneEdité;
            this.personne = personne;
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            if(PrénomTextBlock.Text != "" && NomTextBlock.Text != "")
            {
                personne.Prénom = personneEdité.Prénom;
                personne.Nom = personneEdité.Nom;
                DialogResult = true;
                Close();
            }
        }

        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
