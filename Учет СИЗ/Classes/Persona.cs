using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Учет_СИЗ
{
    [Serializable]
    public class Person 
    {
        //Поля
        private string Personnel_Number;//Табельный номер
        private string First_Name;      //Имя
        private string Last_Name;       //Фамилия
        private string Middle_name;     //Отчество эта фтгня достала
        private string ppz;
        private string Age;                //Возраст
        private string Gender;          //Пол
        private string Height;             //Рост
        private string Clothing_size;   //Размер одежды
        private string Position;        //Должность
        private string FIO_Chief;       //Руководитель
        private string Facility;        //Объект
        private string Facility_Address;//Адресс объекта



        //Свойства
        public string Change_Personnel_Number
        {
            get { return Personnel_Number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("\"Имя\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                if (string.IsNullOrEmpty(value) && value.Contains(' '))
                {
                    MessageBox.Show("\"Имя\" указано неверно!" +"\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                if (string.IsNullOrEmpty(value) && value.Contains(' '))
                {
                    MessageBox.Show("\"Фамилия\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
                    Last_Name = "Н/Д";
                }
                else Last_Name = value;
            }
        }
        public string Change_Middle_name
        {
            get { return Middle_name; }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Contains(' '))
                {
                    MessageBox.Show("\"Отчество\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
                    Middle_name = "Н/Д";
                }
                else Middle_name = value;
            }
        }
        public string Change_Age
        {
            get { return Age; }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Contains(' '))
                {
                    MessageBox.Show("\"Возраст\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
                    Age = "Н/Д";
                }
                else Age = value;
            }
        }
        public string Change_Gender
        {
            get { return Gender; }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Contains(' '))
                {
                    MessageBox.Show("\"Пол\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
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
                if (string.IsNullOrEmpty(value) && value.Contains(' '))
                {
                    MessageBox.Show("\"Рост\" указано неверно!" + "\n" + "Строка не должна быть пустой и не содержать пробелов. Установлено значение \"Н/Д\"");
                    Height = "Н/Д";
                }
                else Height = value;
            }
        }
        public string Change_Clothing_size
        {
            get { return Clothing_size; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("\"Размер одежды\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Clothing_size = "Н/Д";
                }
                else Clothing_size = value;
            }
        }
        public string Change_Position
        {
            get { return Position; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("\"Должность\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Position = "Н/Д";
                }
                else Position = value;
            }
        }
        public string Change_FIO_Chief
        {
            get { return FIO_Chief; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("\"Руководитель\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    FIO_Chief = "Н/Д";
                }
                else FIO_Chief = value;
            }
        }
        public string Change_Facility
        {
            get { return Facility; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("\"Объект\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Facility = "Н/Д";
                }
                else Facility = value;
            }
        }
        public string Change_Facility_Address
        {
            get { return Facility_Address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("\"Адрес объекта\" указано неверно!" + "\n" + "Строка не должна быть пустой. Установлено значение \"Н/Д\"");
                    Facility_Address = "Н/Д";
                }
                else Facility_Address = value;
            }
        }


        //Методы

        //Конструкторы
        public Person()
        {
            Personnel_Number = "Н/Д";
            First_Name = "Н/Д";
            Last_Name = "Н/Д";
            Middle_name = "Н/Д";
            Age = "Н/Д";
            Gender = "Н/Д";
            Height = "Н/Д";
            Clothing_size = "Н/Д";
            Position = "Н/Д";
            FIO_Chief = "Н/Д";
            Facility = "Н/Д";
            Facility_Address = "Н/Д";
        }
        public Person(string personnel_Number,  string first_Name, string last_Name, string middle_name, string age, string gender, string height, string clothing_size,   
        string position, string FIO_chief, string facility, string facility_Address)
        {
            Personnel_Number = personnel_Number;
            First_Name = first_Name;
            Last_Name = last_Name;
            Middle_name = middle_name;
            Age = age;
            Gender = gender;
            Height = height;
            Clothing_size = clothing_size;
            Position = position;
            FIO_Chief = FIO_chief;
            Facility = facility;
            Facility_Address = facility_Address;
        }
    }

}
