using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;

namespace Учет_СИЗ.Classes
{
    class MyButton_Person : Button
    {
        public List<Person> List;
        public Person PersonBtn;
        public PersonalCard AddWindow;
        public MyButton_Person(ref List<Person> List, Person Person1)
        {
            PersonBtn = Person1;
            this.List = List;
            AddWindow = new PersonalCard(ref List, ref PersonBtn, "Show");
            this.Click += MyButton_Click;
        }

        void MyButton_Click(object sender, EventArgs e)
        {
            AddWindow.Show();
        }
    }
}