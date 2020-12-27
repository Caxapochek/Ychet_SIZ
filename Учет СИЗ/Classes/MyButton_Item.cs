using System;
using System.Windows.Controls;

namespace Учет_СИЗ.Classes
{
    class MyButton_Item : Button
    {
        public Person person;
        public Item item;

        public MyButton_Item(ref Person person, Item item)
        {
            this.person = person;
            this.item = item;
            Content = item.Title_GetSet;
            Click += MyButton_Click;
        }

        void MyButton_Click(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            ItemCard AddWindow_Item = new ItemCard(ref person,ref item, "Show");
        }
    }
}
