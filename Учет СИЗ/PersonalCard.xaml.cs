using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{
    public partial class PersonalCard : Window
    {
        private List<Person> List_of_persons = new List<Person>();
        private Person Person1;
        private string Mode;//При значении "Add" отображать окно для добавления, а при "Show" показывать персональную карту

        #region Конструкторы
        public PersonalCard(ref List<Person> list_of_persons, ref Person person, string mode) //show
        {
            InitializeComponent();
            List_of_persons = list_of_persons;
            Person1 = person;
            Mode = mode;
            if (!List_of_persons.Contains(Person1))
            {
                MessageBox.Show("Данный человек не найден!" + "\n" + "Обновите страницу и попробуйте еще раз.");
                this.Close();
                SerializingPersons(List_of_persons);
            }
            else
            {
                BtnSavePerson.IsEnabled = true;
                BtnDeletePerson.IsEnabled = true;
                BtnSavePerson.Content = "Сохранить";
                Fill();
                this.Show();
            }
        }
        public PersonalCard(ref List<Person> list_of_persons, string mode) //add
        {
            InitializeComponent();
            List_of_persons = list_of_persons;
            Mode = mode;
            Person1 = new Person();
            BtnDeletePerson.IsEnabled = false;
            BtnSavePerson.IsEnabled = true;  
            BtnSavePerson.Content = "Добавить";
            this.Show();
        }
        #endregion

        #region Кнопки
        private void BtnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            List_of_persons.Remove(Person1);
            Person1 = new Person(PersonalNumber.Text.ToString(), FirstName.Text.ToString(), SecondName.Text.ToString(),
                MiddleName.Text.ToString(), Age.Text.ToString(), Gender.Text.ToString(), Height.Text.ToString(),
                ClothingSize.Text.ToString(), Position.Text.ToString(), FIOChef.Text.ToString(), Facility.Text.ToString(),
                FacilityAdress.Text.ToString(), Person1.Items);
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
        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            ItemCard AddWindow = new ItemCard(ref Person1, "Add");
        }
        private  void BtnUpdateItems_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_Inventory.Children.Clear();
            Fill();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Методы
        private void Fill()
        {
            PersonalNumber.Text = Person1.Change_Personnel_Number;
            FirstName.Text = Person1.Change_First_Name;
            SecondName.Text = Person1.Change_Last_Name;
            MiddleName.Text = Person1.Change_Middle_name;
            Age.Text = Person1.Change_Age;
            Gender.Text = Person1.Change_Gender;
            Height.Text = Person1.Change_Height;
            ClothingSize.Text = Person1.Change_Clothing_size;
            Position.Text = Person1.Change_Position;
            FIOChef.Text = Person1.Change_FIO_Chief;
            Facility.Text = Person1.Change_Facility;
            FacilityAdress.Text = Person1.Change_Facility_Address;
            foreach (Item it in Person1.Items)
            {
                MyButton_Item BtnItem = new MyButton_Item(ref Person1, it) { Content = MakeGrid(it) };
                StackPanel_Inventory.Children.Add(BtnItem);
            }
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
        private Grid MakeGrid(Item item)
        {
            Grid grid = new Grid();
            grid.Height = 30;
            grid.Width = 800;
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(150) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(125) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(125) });

            Label LabelTitle = new Label { Content = item.Title_GetSet, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelItem_number = new Label { Content = item.Item_number_GetSet, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelQuantity = new Label { Content = item.Quantity_GetSet, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelDate_Of_Commissioning = new Label { Content = item.Date_Of_Commissioning_GetSet, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelService_Life = new Label { Content = item.Service_Life_GetSet, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelDate_Of_Decommissioning = new Label { Content = item.Date_Of_Decommissioning_GetSet, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };

            grid.Children.Add(LabelTitle);
            Grid.SetColumn(LabelTitle, 0);
            grid.Children.Add(LabelItem_number);
            Grid.SetColumn(LabelItem_number, 1);
            grid.Children.Add(LabelQuantity);
            Grid.SetColumn(LabelQuantity, 2);
            grid.Children.Add(LabelDate_Of_Commissioning);
            Grid.SetColumn(LabelDate_Of_Commissioning, 3);
            grid.Children.Add(LabelService_Life);
            Grid.SetColumn(LabelService_Life, 4);
            grid.Children.Add(LabelDate_Of_Decommissioning);
            Grid.SetColumn(LabelDate_Of_Decommissioning, 5);

            return grid;
        }
        #endregion

    }
}
