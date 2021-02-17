using System.Windows;
using System.Windows.Input;
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
            BtnDeleteItem.IsEnabled = false;
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
        Person1.Items.Remove(Item1);
            Item1 = new Item(Name.Text, CertificateOfConformity.Text, IssuedDate.Text, IssuedQuantity.Text, IssuedWear.Text, IssuedReceipt.Text,
                ReturnedDate.Text, ReturnedQuantity.Text, ReturnedWear.Text, ReturnedReceipt.Text);
            Person1.Items.Add(Item1);
            this.Close();
        }
        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Person1.Items.Remove(Item1);
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
        #endregion

    }
}
