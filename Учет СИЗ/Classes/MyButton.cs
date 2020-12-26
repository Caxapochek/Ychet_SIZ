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
        public List<Person> List;
        public Person PersonBtn;
        public MyButton(ref List<Person> List, Person Person1)
        {
            PersonBtn = Person1;
            Content = Person1.Change_Last_Name + " " + Person1.Change_First_Name + " " + Person1.Change_Middle_name;
            Click += MyButton_Click;
            this.List = List;
        }

        void MyButton_Click(object sender, EventArgs e)
        {
            PersonalCard AddWindow = new PersonalCard(List,PersonBtn,"Show");
            AddWindow.Show();

        }        
    }
}