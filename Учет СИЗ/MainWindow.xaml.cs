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
        public PersonalCard AddWindow = new PersonalCard();
        List_Persons<Person> list_of_persons = new List_Persons<Person>();
        public MainWindow()
        {
            InitializeComponent();
            DeserializingPersons();

            

            //Button Btn1 = new Button();
            //Btn1.Content = "11111111111";
            //Btn1.Height = 100;
            //Button Btn2 = new Button();
            //Btn2.Content = "2222222222";
            //Btn2.Height = 100;
            //Button Btn3 = new Button();
            //Btn3.Content = "3333333333";
            //Btn3.Height = 100;
            //Button Btn4 = new Button();
            //Btn4.Content = "444";
            //Btn4.Height = 100;
            //StackPanel_Persona.Children.Add(Btn1);
            //StackPanel_Persona.Children.Add(Btn2);
            //StackPanel_Persona.Children.Add(Btn3);
            //StackPanel_Persona.Children.Add(Btn4);
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddWindow.Show();
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
            foreach (Person per in list_of_persons.List_Of_Person)
            {
                StackPanel_Persona.Children.Add(new MyButton(per.Change_Last_Name + " " + per.Change_First_Name + " " + per.Change_Middle_name));
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
    }
}
