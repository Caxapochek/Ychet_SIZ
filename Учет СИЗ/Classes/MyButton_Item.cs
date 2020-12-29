using System;
using System.Windows.Controls;

namespace Учет_СИЗ.Classes
{
    class MyButton_Item : Button
    {
        public Person person;
        public Item item;
        public ItemCard AddWindow_Item;

        public MyButton_Item(ref Person person, Item item)
        {
            this.person = person;
            this.item = item;
            Click += MyButton_Click;
            AddWindow_Item = new ItemCard(ref person, ref item, "Show");
        }

        void MyButton_Click(object sender, EventArgs e)
        {
            AddWindow_Item.Show();
        }
    }
}
