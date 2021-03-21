using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{   
    public partial class ItemCard : Window
    {
        private Person Person1;
        private Item Item1;
        private string Mode;

        #region Конструкторы
        public ItemCard(ref Person person,string mode) //add
        {
            Person1 = person;
            Mode = mode;
            InitializeComponent();
            BtnDeleteItem.IsEnabled = true;
            BtnDeleteItem.Content = "Отмена";
            BtnSaveItem.IsEnabled = true;
            BtnSaveItem.Content = "Добавить";
        }
        public ItemCard(ref Person person,ref Item item, string mode) //show
        {
            Person1 = person;
            Item1 = item;
            Mode = mode;
            InitializeComponent();
            if (!Person1.Items.Contains(item))
            {
                MessageBox.Show("Данная вещь не найдена!" + "\n" + "Обновите страницу и попробуйте еще раз.");
                this.Close();
                //SerializingPersons(List_of_persons);// EL PROBLEMO
            }
            else
            {
                BtnDeleteItem.IsEnabled = true;
                BtnSaveItem.IsEnabled = true;
                BtnSaveItem.Content = "Сохранить";
                Fill();
            }
        }
        #endregion

        #region Кнопки
        private void BtnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            var numbers = new Regex(@"^[0-9]+");
            var numbers1 = new Regex(@"^[0-9]*");
            if (!string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty(CertificateOfConformity.Text) && numbers.IsMatch(IssuedQuantity.Text) && (numbers.IsMatch(IssuedWear.Text)) && int.Parse(IssuedWear.Text) <= 100 
                && int.Parse(IssuedWear.Text) >= 0 && !string.IsNullOrEmpty(IssuedReceipt.Text) && numbers1.IsMatch(ReturnedQuantity.Text) && numbers1.IsMatch(ReturnedWear.Text) && !string.IsNullOrEmpty(IssuedDate.Text))
            {
                Person1.Items.Remove(Item1);
                Item1 = new Item(Name.Text, CertificateOfConformity.Text, IssuedDate.Text, IssuedQuantity.Text, IssuedWear.Text, IssuedReceipt.Text,
                    ReturnedDate.Text, ReturnedQuantity.Text, ReturnedWear.Text, ReturnedReceipt.Text);
                Person1.Items.Add(Item1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Некорректорные данные");
                CheckIsNullOrEmpty(Name);
                CheckIsNullOrEmpty(CertificateOfConformity);
                CheckRegex(IssuedQuantity, numbers);
                CheckIssueWear(IssuedWear, numbers);
                CheckIsNullOrEmpty(IssuedReceipt);
                CheckRegex(ReturnedQuantity, numbers1);
                CheckRegex(ReturnedWear, numbers1);
                CheckReturnWear(ReturnedWear, numbers);
                CheckDate(IssuedDate);
            }
        }
        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Person1.Items.Remove(Item1);
            this.Close();
        }
        private void BtnCancelItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region  Методы
        private void Fill()
        {
            Name.Text = Item1.Name_GetSet;
            CertificateOfConformity.Text = Item1.Certificate_Of_Conformity_GetSet;
            IssuedDate.Text = Item1.Issued_Date_GetSet;
            IssuedQuantity.Text = Item1.Issued_Quantity_GetSet;
            IssuedWear.Text = Item1.Issued_Wear_GetSet;
            IssuedReceipt.Text = Item1.Issued_Receipt_GetSet;
            ReturnedDate.Text = Item1.Returned_Date_GetSet;
            ReturnedQuantity.Text = Item1.Returned_Quantity_GetSet;
            ReturnedWear.Text = Item1.Returned_Wear_GetSet;
            ReturnedReceipt.Text = Item1.Returned_Receipt_GetSet;
        }

        private void CheckIsNullOrEmpty(TextBox textBox)
        {
            var error = Brushes.Red;
            var standart = Brushes.Black;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BorderBrush = error;
            }
            else
            {
                textBox.BorderBrush = standart;
            }
        }

        private void CheckRegex (TextBox textBox, Regex regex)
        {
            var error = Brushes.Red;
            var standart = Brushes.Black;
            if (!regex.IsMatch(textBox.Text))
            {
                textBox.BorderBrush = error;
            }
            else
            {
                textBox.BorderBrush = standart;
            }
        }

        private void CheckIssueWear (TextBox textBox, Regex regex)
        {
            var error = Brushes.Red;
            var standart = Brushes.Black;
            if (!regex.IsMatch(textBox.Text) || (int.Parse(textBox.Text) < 0) || (int.Parse(textBox.Text) > 100))
            {
                textBox.BorderBrush = error;
            }
            else
            {
                textBox.BorderBrush = standart;
            }
        }

        private void CheckReturnWear(TextBox textBox, Regex regex)
        {
            var error = Brushes.Red;
            var standart = Brushes.Black;
            if (string.IsNullOrEmpty(textBox.Text) || (regex.IsMatch(textBox.Text) && (int.Parse(textBox.Text) >= 0) && (int.Parse(textBox.Text) <= 100)))
            {
                textBox.BorderBrush = standart;
            }
            else 
            {
                textBox.BorderBrush = error;
            }
        }

        private void CheckDate (DatePicker datePicker)
        {
            var error = Brushes.Red;
            var standart = Brushes.Black;
            if (string.IsNullOrEmpty(datePicker.Text))
            {
                datePicker.BorderBrush = error;
            }
            else
            {
                datePicker.BorderBrush = standart;
            }
        }
        #endregion

    }
}
