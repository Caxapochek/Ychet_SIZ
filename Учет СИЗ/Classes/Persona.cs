using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Учет_СИЗ.Classes;

namespace Учет_СИЗ
{
    [Serializable]
    public class Person : IComparer<Person>
    {
        private string Personal_Card_Number;        //Номер личной карточки+
        private string Personnel_Number;            //Табельный номер
        private string First_Name;                  //Имя
        private string Last_Name;                   //Фамилия
        private string Middle_Name;                 //Отчество 
        private string Structural_Division;         //Структурное подразделение+
        private string Position;                    //Должность
        private string Date_Of_Employment;          //Дата приема на работу+
        private string Date_Of_Change_Of_Profession;//Дата изменения профессии+
        private string Gender;                      //Пол
        private string FIO_Chief;                   //Руководитель
        public Sizes Sizess;                         //Размеры
        public List<Item> Items;                    //Вещи

        #region Свойства
        public string Change_Personal_Card_Number
        {
            get { return Personal_Card_Number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Personal_Card_Number = "Н/Д";
                }
                else Personal_Card_Number = value;
            }
        }
        public string Change_Personnel_Number
        {
            get { return Personnel_Number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Personnel_Number = "Н/Д";
                }
                else Personnel_Number = value;
            }
        }
        public string Change_First_Name
        {
            get { return First_Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    First_Name = "Н/Д";
                }
                else First_Name = value;
            }
        }
        public string Change_Last_Name
        {
            get { return Last_Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                   Last_Name = "Н/Д";
                }
                else Last_Name = value;
            }
        }
        public string Change_Middle_Name
        {
            get { return Middle_Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Middle_Name = "Н/Д";
                }
                else Middle_Name = value;
            }
        }
        public string Change_Structural_Division
        {
            get { return Structural_Division; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Structural_Division = "Н/Д";
                }
                else Structural_Division = value;
            }
        }
        public string Change_Position
        {
            get { return Position; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Position = "Н/Д";
                }
                else Position = value;
            }
        }
        public string Change_Date_Of_Employment
        {
            get { return Date_Of_Employment; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Date_Of_Employment = "Н/Д";
                }
                else Date_Of_Employment = value; 
            }
        }
        public string Change_Date_Of_Change_Of_Profession
        {
            get { return Date_Of_Change_Of_Profession; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                   Date_Of_Change_Of_Profession = "Н/Д";
                }
                else Date_Of_Change_Of_Profession = value;
            }
        }
        public string Change_Gender
        {
            get { return Gender; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Gender = "Н/Д";
                }
                else Gender = value;
            }
        }
        public string Change_FIO_Chief
        {
            get { return FIO_Chief; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    FIO_Chief = "Н/Д";
                }
                else FIO_Chief = value;
            }
        }        
        #endregion

        #region Конструкторы
        public Person()
        {
            Personal_Card_Number = "Н/Д";        //Номер личной карточки+
            Personnel_Number = "Н/Д";            //Табельный номер
            First_Name = "Н/Д";                  //Имя
            Last_Name = "Н/Д";                   //Фамилия
            Middle_Name = "Н/Д";                 //Отчество 
            Structural_Division = "Н/Д";         //Структурное подразделение+
            Position = "Н/Д";                    //Должность
            Date_Of_Employment = "Н/Д";          //Дата приема на работу+
            Date_Of_Change_Of_Profession = "Н/Д";//Дата изменения профессии+
            Gender = "Н/Д";                      //Пол
            FIO_Chief = "Н/Д";                   //Руководитель
        }
        
        public Person(string Personal_Card_Number, string Personnel_Number, string First_Name, string Last_Name, string Middle_Name,
            string Structural_Division, string Position, string Date_Of_Employment, string Date_Of_Change_Of_Profession, string Gender,
            string FIO_Chief, Sizes sizes, List<Item> Items)
        {
            this.Personal_Card_Number = Personal_Card_Number;        //Номер личной карточки+
            this.Personnel_Number = Personnel_Number;            //Табельный номер
            this.First_Name = First_Name;                  //Имя
            this.Last_Name = Last_Name;                   //Фамилия
            this.Middle_Name = Middle_Name;                 //Отчество 
            this.Structural_Division = Structural_Division;         //Структурное подразделение+
            this.Position = Position;                    //Должность
            this.Date_Of_Employment = Date_Of_Employment;          //Дата приема на работу+
            this.Date_Of_Change_Of_Profession = Date_Of_Change_Of_Profession;//Дата изменения профессии+
            this.Gender = Gender;                      //Пол
            this.FIO_Chief = FIO_Chief;                   //Руководитель
            this.Sizess = sizes;
            this.Items = Items;
        }
        #endregion

        int IComparer<Person>.Compare(Person x, Person y)
        {
            throw new NotImplementedException();
        }
    }
}
