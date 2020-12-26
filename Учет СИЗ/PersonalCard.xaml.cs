using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Serialization;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{
    /// <summary>
    /// Логика взаимодействия для PersonalCard.xaml
    /// </summary>
    public partial class PersonalCard : Window
    {
        List_Persons<Person> list_of_persons = new List_Persons<Person>();
        public PersonalCard()
        {
            InitializeComponent();
            DeserializingPersons();
        }

        public void DeserializingPersons()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List_Persons<Person>));
            using (Stream fStream = File.OpenRead(@"ListPersons.xml"))
            {
                try
                {
                    list_of_persons = (List_Persons<Person>)xmlFormat.Deserialize(fStream);
                }
                catch (Exception e)
                {
                    Task.Run(() =>
                    {
                        MessageBox.Show("Не удалось получить доступ к списку Person.");
                    });
                }
            }
        }

        public void SerializingPersons(List_Persons<Person> List)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List_Persons<Person>));

            using (Stream fStream = new FileStream(@"ListPersons.xml",
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, List);
            }
        }

        private void BtnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(PersonalNumber.Text.ToString(), FirstName.Text.ToString(), SecondName.Text.ToString(),
                MiddleName.Text.ToString(), Age.Text.ToString(), Gender.Text.ToString(), Height.Text.ToString(),
                ClothingSize.Text.ToString(), Position.Text.ToString(), FIOChef.Text.ToString(), Facility.Text.ToString(),
                FacilityAdress.Text.ToString());
            list_of_persons.AddAfter(person);
            SerializingPersons(list_of_persons);
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
