using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using Учет_СИЗ.Classes;
using System.Windows.Input;
using System.Windows.Controls;
using System.Security.Permissions;
using System.Windows.Media;

namespace Учет_СИЗ
{
    public partial class MainWindow : Window
    {
        List<Person> list_of_persons = new List<Person>();        

        #region конструктор
        public MainWindow()
        {
            InitializeComponent();
            DeserializingPersons();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) {Content = MakeGrid(per) };
                BtnPerson.AddWindow.Closed += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }
        #endregion

        #region Кнопки
        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonalCard AddWindow = new PersonalCard(ref list_of_persons, "Add");
            AddWindow.Closed += Update;
            AddWindow.Show();
        }
        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            SerializingPersons(list_of_persons);
            Application.Current.Shutdown();
        }
        #endregion

        #region Методы
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
        private Grid MakeGrid(Person person)
        {
            Grid grid = new Grid();
            grid.Height = 30;
            grid.Width = 800;
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100)});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(300) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(150) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });

            Label LabelPersonnel_Number = new Label { Content = person.Change_Personnel_Number, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelFIO = new Label { Content = person.Change_Last_Name + " " +person.Change_First_Name + " " + person.Change_Middle_name, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelPosition = new Label { Content = person.Change_Position, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelFacility = new Label { Content = person.Change_Facility, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };

            grid.Children.Add(LabelPersonnel_Number);
            Grid.SetColumn(LabelPersonnel_Number, 0);
            grid.Children.Add(LabelFIO);
            Grid.SetColumn(LabelFIO, 1);
            grid.Children.Add(LabelPosition);
            Grid.SetColumn(LabelPosition, 2);
            grid.Children.Add(LabelFacility);
            Grid.SetColumn(LabelFacility, 3);

            return grid;
        }
        private void Update(object sender, EventArgs e)
        {
            StackPanel_Persona.Children.Clear();
            DeserializingPersons();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.Closed += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }
        #endregion


    }
}
