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
using System.Windows.Shapes;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{
    /// <summary>
    /// Логика взаимодействия для ItemCard.xaml
    /// </summary>
    public partial class ItemCard : Window
    {
        Person Person1;
        Item Item1;
        string Mode;

        //Конструкторы
        public ItemCard(Person person,string mode) //add
        {
            Person1 = person;
            Mode = mode;
            InitializeComponent();

            BtnDeletePerson.IsEnabled = false;
            BtnSavePerson.IsEnabled = true;
            BtnSavePerson.Content = "Добавить";


            this.Show();
        }
        public ItemCard(Person person, Item item, string mode) //show
        {
            Person1 = person;
            Item1 = item;
            Mode = mode;
            InitializeComponent();
            if (!Person1.Items.Contains(item))
            {
                MessageBox.Show("Данная вещь не найдена!" + "\n" + "Обновите страницу и попробуйте еще раз.");
                this.Close();
                SerializingPersons(List_of_persons);// EL PROBLEMO
            }
            else
            {

                BtnDeletePerson.IsEnabled = true;
                BtnSavePerson.IsEnabled = true;
                BtnSavePerson.Content = "Сохранить";
                Fill();
                this.Show();
            }
        }


        //Кнопки


        //Методы
        private void Fill()
        {
            TBTitle.Text = Item1.Title_GetSet;
            TBItem_number.Text = Item1.Item_number_GetSet;
            TBQuantity.Text = Item1.Quantity_GetSet;
            TBDate_Of_Commissioning.Text = Item1.Date_Of_Commissioning_GetSet;
            TBService_Life.Text = Item1.Service_Life_GetSet;
            TBDate_Of_Decommissioning.Text = Item1.Date_Of_Decommissioning_GetSet;
        }
    }
}
