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
using ISortList;
using System.Collections;

namespace Учет_СИЗ
{
    #region компораторы для сортировки
    public class SortPosition : System.Collections.IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_Position, b.Change_Position);
        }
    }

    public class SortFIO_Chief : System.Collections.IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_FIO_Chief, b.Change_FIO_Chief);
        }
    }

    public class SortFIO : System.Collections.IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_Last_Name, b.Change_Last_Name);
        }
    }
    #endregion

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
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }
        #endregion

        #region Кнопки
        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonalCard AddWindow = new PersonalCard(ref list_of_persons, "Add");
            AddWindow.BtnSavePerson.Click += Update;
            AddWindow.BtnDeletePerson.Click += Update;
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
        private Grid MakeGrid(Person person) //добовление кнопок на экран в ScrollViewer
        {
            Grid grid = new Grid{Height = 30,Width = 1000};
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100)});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(350) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(250) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });

            Label LabelPersonalCardNumber = new Label { Content = person.Change_Personal_Card_Number, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelPersonnelNumber = new Label { Content = person.Change_Personnel_Number, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelFIO = new Label { Content = person.Change_Last_Name+ " " + person.Change_First_Name + " " + person.Change_Middle_Name, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelPosition = new Label { Content = person.Change_Position, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelFIOChief = new Label { Content = person.Change_FIO_Chief, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };

            grid.Children.Add(LabelPersonalCardNumber);
            Grid.SetColumn(LabelPersonalCardNumber, 0);
            grid.Children.Add(LabelPersonnelNumber);
            Grid.SetColumn(LabelPersonnelNumber, 1);
            grid.Children.Add(LabelFIO);
            Grid.SetColumn(LabelFIO, 2);
            grid.Children.Add(LabelPosition);
            Grid.SetColumn(LabelPosition, 3);
            grid.Children.Add(LabelFIOChief);
            Grid.SetColumn(LabelFIOChief, 4);

            return grid;
        }
        private void Update(object sender, EventArgs e)
        {
            StackPanel_Persona.Children.Clear();
            DeserializingPersons();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }
        #endregion

        #region сортировка 
        public void SortByPosition()
        {
            int N = list_of_persons.Count;
            Person[] SL = new Person[N];
            SL = list_of_persons.ToArray();
            Array.Sort(SL, new SortPosition()) ;
            list_of_persons = new List<Person>(SL);
        }

        public void SortByFIO_Chief()
        {
            int N = list_of_persons.Count;
            Person[] SL = new Person[N];
            SL = list_of_persons.ToArray();
            Array.Sort(SL, new SortFIO_Chief());
            list_of_persons = new List<Person>(SL);
        }

        public void SortByFIO()
        {
            int N = list_of_persons.Count;
            Person[] SL = new Person[N];
            SL = list_of_persons.ToArray();
            Array.Sort(SL, new SortFIO());
            list_of_persons = new List<Person>(SL);
        }
        #endregion
    }
}
