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
        private string Height;                      //Рост
        private string Clothing_Size;               //Размер одежды
        private string Shoe_Size;                   //Размер обуви
        private string Headdress_Size;              //Размер головного убора
        private string Gas_Mask_Size;               //Размер противогаза
        private string Raspirator_Size;             //Размер распиратора
        private string Mittens_Size;                //Размер руковиц
        private string Gloves_Size;                 //Размер перчаток
        private string FIO_Chief;                   //Руководитель
        public List<Item> Items;                    //Вещи

        #region Свойства
        public string Change_Personal_Card_Number
        {
            get { return Personal_Card_Number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Номер личной карточки\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Имя\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Имя\" указано неверно!" +"\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Фамилия\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Отчество\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Структурное подразделение\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Должность\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Дата приема на работу\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Дата изменения профессии\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                    //MessageBox.Show("\"Пол\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
                    Gender = "Н/Д";
                }
                else Gender = value;
            }
        }
        public string Change_Height
        {
            get { return Height; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Рост\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
                    Height = "Н/Д";
                }
                else Height = value;
            }
        }

        public string Change_Clothing_size
        {
            get { return Clothing_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер одежды\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Clothing_Size = "Н/Д";
                }
                else Clothing_Size = value;
            }
        }
        public string Change_Shoe_Size
        {
            get { return Shoe_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер обуви\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Shoe_Size = "Н/Д";
                }
                else Shoe_Size = value;
            }
        }
        public string Change_Headdress_Size
        {
            get { return Headdress_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер головного убора\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Headdress_Size = "Н/Д";
                }
                else Headdress_Size = value;
            }
        }
        public string Change_Gas_Mask_Size
        {
            get { return Gas_Mask_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер противогаза\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Gas_Mask_Size = "Н/Д";
                }
                else Gas_Mask_Size = value;
            }
        }
        public string Change_Raspirator_Size
        {
            get { return Raspirator_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер распиратора\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Raspirator_Size = "Н/Д";
                }
                else Raspirator_Size = value;
            }
        }
        public string Change_Mittens_Size
        {
            get { return Mittens_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер руковиц\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Mittens_Size = "Н/Д";
                }
                else Mittens_Size = value;
            }
        }
        public string Change_Gloves_Size
        {
            get { return Gloves_Size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Размер перчаток\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Gloves_Size = "Н/Д";
                }
                else Gloves_Size = value;
            }
        }
        public string Change_FIO_Chief
        {
            get { return FIO_Chief; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    //MessageBox.Show("\"Руководитель\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
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
            Height = "Н/Д";                      //Рост
            Clothing_Size = "Н/Д";               //Размер одежды
            Shoe_Size = "Н/Д";                   //Размер обуви
            Headdress_Size = "Н/Д";              //Размер головного убора
            Gas_Mask_Size = "Н/Д";               //Размер противогаза
            Raspirator_Size = "Н/Д";             //Размер распиратора
            Mittens_Size = "Н/Д";                //Размер руковиц
            Gloves_Size = "Н/Д";                 //Размер перчаток
            FIO_Chief = "Н/Д";                   //Руководитель
    }
        
        public Person(string Personal_Card_Number, string Personnel_Number, string First_Name, string Last_Name, string Middle_Name,
            string Structural_Division, string Position, string Date_Of_Employment, string Date_Of_Change_Of_Profession, string Gender,
            string Height, string Clothing_Size, string Shoe_Size, string Headdress_Size, string Gas_Mask_Size, string Raspirator_Size,
            string Mittens_Size, string Gloves_Size, string FIO_Chief, List<Item> Items)
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
            this.Height = Height;                      //Рост
            this.Clothing_Size = Clothing_Size;               //Размер одежды
            this.Shoe_Size = Shoe_Size;                   //Размер обуви
            this.Headdress_Size = Headdress_Size;              //Размер головного убора
            this.Gas_Mask_Size = Gas_Mask_Size;               //Размер противогаза
            this.Raspirator_Size = Raspirator_Size;             //Размер распиратора
            this.Mittens_Size = Mittens_Size;                //Размер руковиц
            this.Gloves_Size = Gloves_Size;                 //Размер перчаток
            this.FIO_Chief = FIO_Chief;                   //Руководитель
            this.Items = Items;
        }
        #endregion

        int IComparer<Person>.Compare(Person x, Person y)
        {
            throw new NotImplementedException();
        }

    }
}
