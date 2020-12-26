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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> list_of_persons = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            DeserializingPersons();
            foreach (Person per in list_of_persons)
            {
                
                StackPanel_Persona.Children.Add(new MyButton(ref list_of_persons, per));
            }

        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonalCard AddWindow = new PersonalCard(list_of_persons, "Add");
            AddWindow.Show();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_Persona.Children.Clear();
            DeserializingPersons();
            foreach (Person per in list_of_persons)
            {

                StackPanel_Persona.Children.Add(new MyButton(ref list_of_persons, per));
            }
        }

        public void DeserializingPersons()
        {            
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));
            using (Stream fStream = File.OpenRead(@"ListPersons.xml"))
            {
                try
                {
                    list_of_persons = (List<Person>)xmlFormat.Deserialize(fStream);
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
