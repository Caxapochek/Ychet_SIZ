using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Учет_СИЗ.Classes
{
    class MyButton : Button
    {
        public Person PersonBtn;
        public MyButton(Person Person1)
        {
            PersonBtn = Person1;
            Content = Person1.Change_Last_Name + " " + Person1.Change_First_Name + " " + Person1.Change_Middle_name;
            Click += MyButton_Click;
        }

        void MyButton_Click(object sender, EventArgs e)
        {
            PersonalCard AddWindow = new PersonalCard(PersonBtn);
            AddWindow.Show();

        }        
    }
}