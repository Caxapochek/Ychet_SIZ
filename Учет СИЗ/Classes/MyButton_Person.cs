﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Учет_СИЗ.Classes
{
    class MyButton_Person : Button
    {
        public List<Person> List;
        public Person PersonBtn;
        public MyButton_Person(ref List<Person> List, Person Person1)
        {
            PersonBtn = Person1;
            this.List = List;
            Content = Person1.Change_Last_Name + " " + Person1.Change_First_Name + " " + Person1.Change_Middle_name;
            Click += MyButton_Click;
        }

        void MyButton_Click(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            PersonalCard AddWindow = new PersonalCard(ref List,ref PersonBtn,"Show");
        }        
    }
}