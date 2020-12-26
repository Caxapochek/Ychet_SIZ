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
        List<Person> List_of_persons = new List<Person>();
        Person Person1;
        string Mode;                                                    //При значении "Add" отображать окно для добавления, а при "Show" показывать персональную карту
        public PersonalCard(List<Person> list_of_persons, Person person, string mode)
        {
            InitializeComponent();
            List_of_persons = list_of_persons;
            Person1 = person;
            Mode = mode;
            List_of_persons.Remove(Person1);

            BtnSavePerson.IsEnabled = true;
            BtnDeletePerson.IsEnabled = true;
            BtnSavePerson.Content = "Сохранить";
        }
        public PersonalCard(List<Person> list_of_persons, string mode)
        {
            InitializeComponent();
            List_of_persons = list_of_persons;
            Mode = mode;

            BtnDeletePerson.IsEnabled = false;
            BtnSavePerson.IsEnabled = true;
            BtnSavePerson.Content = "Добавить";

        }
        


        private void BtnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            Person1 = new Person(PersonalNumber.Text.ToString(), FirstName.Text.ToString(), SecondName.Text.ToString(),
                MiddleName.Text.ToString(), Age.Text.ToString(), Gender.Text.ToString(), Height.Text.ToString(),
                ClothingSize.Text.ToString(), Position.Text.ToString(), FIOChef.Text.ToString(), Facility.Text.ToString(),
                FacilityAdress.Text.ToString());
            List_of_persons.Add(Person1);
            SerializingPersons(List_of_persons);

            this.Close();
        }


        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            List_of_persons.Remove(Person1);
            SerializingPersons(List_of_persons);
            this.Close();
        }
        public void DeserializingPersons()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));
            using (Stream fStream = File.OpenRead(@"ListPersons.xml"))
            {
                try
                {
                    List_of_persons = (List<Person>)xmlFormat.Deserialize(fStream);
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

        public void SerializingPersons(List<Person> List)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));

            using (Stream fStream = new FileStream(@"ListPersons.xml",
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, List);
            }
        }
    }
}
