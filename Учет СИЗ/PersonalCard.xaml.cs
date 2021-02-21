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
            }
        }
        public PersonalCard(ref List<Person> list_of_persons, string mode) //add
        {
            InitializeComponent();
            List_of_persons = list_of_persons;
            Mode = mode;
            Person1 = new Person();
            BtnDeletePerson.IsEnabled = true;
            BtnDeletePerson.Content = "Отмена";
            BtnSavePerson.IsEnabled = true;  
            BtnSavePerson.Content = "Добавить";
            this.Show();
        }
        #endregion

        #region Кнопки
        public void BtnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            List_of_persons.Remove(Person1);
            Person1 = new Person(PersonalCardNumber.Text, PersonnelNumber.Text, FirstName.Text, SecondName.Text,  MiddleName.Text,
            StructuralDivision.Text, Position.Text, DateOfEmployment.Text, DateOfChangeOfProfession.Text, Gender.Text,
            Height.Text, ClothingSize.Text, ShoeSize.Text,  HeaddressSize.Text, GasMaskSize.Text, RaspiratorSize.Text,
            MittensSize.Text, GlovesSize.Text, FIOChief.Text, Person1.Items);
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
            AddWindow.BtnSaveItem.Click += Update;
            AddWindow.BtnDeleteItem.Click += Update;
            AddWindow.Show();
        }
        private  void Update(object sender, EventArgs e)
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
            PersonalCardNumber.Text = Person1.Change_Personal_Card_Number;
            PersonnelNumber.Text = Person1.Change_Personnel_Number;
            FirstName.Text = Person1.Change_First_Name;
            SecondName.Text = Person1.Change_Last_Name;
            MiddleName.Text = Person1.Change_Middle_Name;
            StructuralDivision.Text = Person1.Change_Structural_Division;
            Position.Text = Person1.Change_Position;
            DateOfEmployment.Text = Person1.Change_Date_Of_Employment;
            DateOfChangeOfProfession.Text = Person1.Change_Date_Of_Change_Of_Profession;
            Gender.Text = Person1.Change_Gender;
            Height.Text = Person1.Change_Height;
            ClothingSize.Text = Person1.Change_Clothing_size;
            ShoeSize.Text = Person1.Change_Shoe_Size;
            HeaddressSize.Text = Person1.Change_Headdress_Size;
            GasMaskSize.Text = Person1.Change_Gas_Mask_Size;
            RaspiratorSize.Text = Person1.Change_Raspirator_Size;
            MittensSize.Text = Person1.Change_Mittens_Size;
            GlovesSize.Text = Person1.Change_Gloves_Size;
            FIOChief.Text = Person1.Change_FIO_Chief;
            foreach (Item it in Person1.Items)
            {
                MyButton_Item BtnItem = new MyButton_Item(ref Person1, it) { Content = MakeGrid(it) };
                BtnItem.AddWindow_Item.BtnDeleteItem.Click += Update;
                BtnItem.AddWindow_Item.BtnSaveItem.Click += Update;
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
            grid.Width = 1000;
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100) });

            Label LabelName = new Label { Content = item.Name_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelCertificate_Of_Conformity = new Label { Content = item.Certificate_Of_Conformity_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelIssued_Date = new Label { Content = item.Issued_Date_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelIssued_Quantity = new Label { Content = item.Issued_Quantity_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelIssued_Wear = new Label { Content = item.Issued_Wear_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelIssued_Receipt = new Label { Content = item.Issued_Receipt_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelReturned_Date = new Label { Content = item.Returned_Date_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelReturned_Quantity = new Label { Content = item.Returned_Quantity_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelReturned_Wear = new Label { Content = item.Returned_Wear_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };
            Label LabelReturned_Receipt = new Label { Content = item.Returned_Receipt_GetSet, FontSize = 16, BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 0, 1, 0) };

            grid.Children.Add(LabelName);
            Grid.SetColumn(LabelName, 0);
            grid.Children.Add(LabelCertificate_Of_Conformity);
            Grid.SetColumn(LabelCertificate_Of_Conformity, 1);
            grid.Children.Add(LabelIssued_Date);
            Grid.SetColumn(LabelIssued_Date, 2);
            grid.Children.Add(LabelIssued_Quantity);
            Grid.SetColumn(LabelIssued_Quantity, 3);
            grid.Children.Add(LabelIssued_Wear);
            Grid.SetColumn(LabelIssued_Wear, 4);
            grid.Children.Add(LabelIssued_Receipt);
            Grid.SetColumn(LabelIssued_Receipt, 5);
            grid.Children.Add(LabelReturned_Date);
            Grid.SetColumn(LabelReturned_Date, 6);
            grid.Children.Add(LabelReturned_Quantity);
            Grid.SetColumn(LabelReturned_Quantity, 7);
            grid.Children.Add(LabelReturned_Wear);
            Grid.SetColumn(LabelReturned_Wear, 8);
            grid.Children.Add(LabelReturned_Receipt);
            Grid.SetColumn(LabelReturned_Receipt, 9);

            return grid;
        }
        #endregion

    }
}
