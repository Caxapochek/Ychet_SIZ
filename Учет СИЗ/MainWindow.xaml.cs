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
using System.Collections;

namespace Учет_СИЗ
{
    #region компораторы для сортировки
    public class SortPosition :IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_Position, b.Change_Position);
        }
    }

    public class SortFIO_Chief : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_FIO_Chief, b.Change_FIO_Chief);
        }
    }

    public class SortFIO : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_Last_Name, b.Change_Last_Name);
        }
    }

    public class SortPersonal_Card_Number : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_Personal_Card_Number, b.Change_Personal_Card_Number);
        }
    }

    public class SortPersonal_Number : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            Person a = x as Person;
            Person b = y as Person;
            return string.Compare(a.Change_Personnel_Number, b.Change_Personnel_Number);
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
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) {Content = MakeGrid(per), HorizontalContentAlignment = HorizontalAlignment.Stretch };
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.SortBYPersonal_Card_Number();
            StackPanel_Persona.Children.Clear();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.SortByPersonal_Number();
            StackPanel_Persona.Children.Clear();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.SortByFIO();
            StackPanel_Persona.Children.Clear();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.SortByPosition();
            StackPanel_Persona.Children.Clear();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.SortByFIO_Chief();
            StackPanel_Persona.Children.Clear();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per) };
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
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
            Grid grid = new Grid { Height = 30};
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });

            Label LabelPersonalCardNumber = new Label { Content = person.Change_Personal_Card_Number, FontSize = 16 , BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
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
            Grid.SetColumn(LabelFIOChief, 4);;

            return grid;
        }
        private void Update(object sender, EventArgs e)
        {
            StackPanel_Persona.Children.Clear();
            DeserializingPersons();
            foreach (Person per in list_of_persons)
            {
                MyButton_Person BtnPerson = new MyButton_Person(ref list_of_persons, per) { Content = MakeGrid(per), HorizontalContentAlignment = HorizontalAlignment.Stretch};
                BtnPerson.AddWindow.BtnSavePerson.Click += Update;
                BtnPerson.AddWindow.BtnDeletePerson.Click += Update;
                StackPanel_Persona.Children.Add(BtnPerson);
            }
        }
        #endregion

        #region сортировка 
        public void SortByPosition()
        {
            //int N = list_of_persons.Count;
            //Person[] SL = new Person[N];
            //SL = list_of_persons.ToArray();
            //Array.Sort(SL, new SortPosition());
            //list_of_persons = new List<Person>(SL);
            list_of_persons.Sort(new SortPosition());
        }

        public void SortByFIO_Chief()
        {
            //int N = list_of_persons.Count;
            //Person[] SL = new Person[N];
            //SL = list_of_persons.ToArray();
            //Array.Sort(SL, new SortFIO_Chief());
            //list_of_persons = new List<Person>(SL);
            list_of_persons.Sort(new SortFIO_Chief());
        }

        public void SortByFIO()
        {
            //int N = list_of_persons.Count;
            //Person[] SL = new Person[N];
            //SL = list_of_persons.ToArray();
            //Array.Sort(SL, new SortFIO());
            //list_of_persons = new List<Person>(SL);
            list_of_persons.Sort(new SortFIO());
        }

        public void SortByPersonal_Number()
        {
            //int N = list_of_persons.Count;
            //Person[] SL = new Person[N];
            //SL = list_of_persons.ToArray();
            //Array.Sort(SL, new SortPersonal_Number());
            //list_of_persons = new List<Person>(SL);
            list_of_persons.Sort(new SortPersonal_Number());
        }

        public void SortBYPersonal_Card_Number()
        {
            //int N = list_of_persons.Count;
            //Person[] SL = new Person[N];
            //SL = list_of_persons.ToArray();
            //Array.Sort(SL, new SortPersonal_Card_Number());
            //list_of_persons = new List<Person>(SL);
            list_of_persons.Sort(new SortPersonal_Card_Number());
        }
        #endregion
    }
}
