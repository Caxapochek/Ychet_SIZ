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
            this.Show();
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
                this.Show();
            }
        }
        #endregion

        #region Кнопки
        private void BtnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            Person1.Items.Remove(Item1);
            Item1 = new Item(TBTitle.Text.ToString(), TBItem_number.Text.ToString(), TBQuantity.Text.ToString(), 
                TBDate_Of_Commissioning.Text.ToString(), TBService_Life.Text.ToString(), 
                TBDate_Of_Decommissioning.Text.ToString());
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
            TBTitle.Text = Item1.Title_GetSet;
            TBItem_number.Text = Item1.Item_number_GetSet;
            TBQuantity.Text = Item1.Quantity_GetSet;
            TBDate_Of_Commissioning.Text = Item1.Date_Of_Commissioning_GetSet;
            TBService_Life.Text = Item1.Service_Life_GetSet;
            TBDate_Of_Decommissioning.Text = Item1.Date_Of_Decommissioning_GetSet;
        }
        #endregion

    }
}
