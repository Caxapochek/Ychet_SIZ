using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{
    /// <summary>
    /// Логика взаимодействия для PersonalCard.xaml
    /// </summary>
    public partial class PersonalCard : Window
    {        
        public PersonalCard()
        {
            InitializeComponent();
        }

        private void BtnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(PersonalNumber.Text.ToString(), FirstName.Text.ToString(), SecondName.Text.ToString(),
                MiddleName.Text.ToString(), Age.Text.ToString(), Gender.Text.ToString(), Height.Text.ToString(),
                ClothingSize.Text.ToString(), Position.Text.ToString(), FIOChef.Text.ToString(), Facility.Text.ToString(),
                FacilityAdress.Text.ToString());
            
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
