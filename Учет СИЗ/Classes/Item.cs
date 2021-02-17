using System.Text.RegularExpressions;

namespace Учет_СИЗ.Classes
{
    public class Item
    {
        private string Name;                        //Наименование СИЗ
        private string Certificate_Of_Conformity;   //Сертификат соответствия
        private string Issued_Date;                 //Выдано-дата
        private string Issued_Quantity;             //Выдано-количество
        private string Issued_Wear;                 //Выдано-износ
        private string Issued_Receipt;              //Выдано-расписка
        private string Returned_Date;               //Выдано-дата
        private string Returned_Quantity;           //Выдано-количество
        private string Returned_Wear;               //Выдано-износ
        private string Returned_Receipt;            //Выдано-расписка

        #region Свойства
        public string Name_GetSet
        {
            get { return Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Name = "Н/Д";
                }
                else Name = value;
            }
        }
        public string Certificate_Of_Conformity_GetSet
        {
            get { return Certificate_Of_Conformity; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Certificate_Of_Conformity = "Н/Д";
                }
                else Certificate_Of_Conformity = value;
            }
        }
        public string Issued_Date_GetSet
        {
            get { return Issued_Date; }
            set
            {
                Regex regex = new Regex(@"^\d\d[.]\d\d[.]\d\d$");
                if (!regex.IsMatch(value))
                {
                    Issued_Date = "Н/Д";
                }
                else Issued_Date = value;
            }
        }
        public string Issued_Quantity_GetSet
        {
            get { return Issued_Quantity; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Issued_Quantity = "Н/Д";
                }
                else Issued_Quantity = value;
            }
        }
        public string Issued_Wear_GetSet
        {
            get { return Issued_Wear; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Issued_Wear = "Н/Д";
                }
                else Issued_Wear = value;
            }
        }
        public string Issued_Receipt_GetSet
        {

            get { return Issued_Receipt; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Issued_Receipt = "Н/Д";
                }
                else Issued_Receipt = value;
            }
        }
        public string Returned_Date_GetSet
        {

            get { return Returned_Date; }
            set
            {
                Regex regex = new Regex(@"^\d\d[.]\d\d[.]\d\d$");
                if (!regex.IsMatch(value))
                {
                    Returned_Date = "Н/Д";
                }
                else Returned_Date = value;
            }
        }
        public string Returned_Quantity_GetSet
        {

            get { return Returned_Quantity; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Returned_Quantity = "Н/Д";
                }
                else Returned_Quantity = value;
            }
        }
        public string Returned_Wear_GetSet
        {

            get { return Returned_Wear; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Returned_Wear = "Н/Д";
                }
                else Returned_Wear = value;
            }
        }
        public string Returned_Receipt_GetSet
        {

            get { return Returned_Receipt; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Returned_Receipt = "Н/Д";
                }
                else Returned_Receipt = value;
            }
        }
        #endregion

        #region Конструкторы
        public Item()
        {
            Name = "Н/Д";                        //Наименование СИЗ
            Certificate_Of_Conformity = "Н/Д";   //Сертификат соответствия
            Issued_Date = "Н/Д";                 //Выдано-дата
            Issued_Quantity = "Н/Д";             //Выдано-количество
            Issued_Wear = "Н/Д";                 //Выдано-износ
            Issued_Receipt = "Н/Д";              //Выдано-расписка
            Returned_Date = "Н/Д";               //Выдано-дата
            Returned_Quantity = "Н/Д";           //Выдано-количество
            Returned_Wear = "Н/Д";               //Выдано-износ
            Returned_Receipt = "Н/Д";            //Выдано-расписка
    }
        public Item(string Name, string Certificate_Of_Conformity, string Issued_Date, string Issued_Quantity, string Issued_Wear,
            string Issued_Receipt, string Returned_Date, string Returned_Quantity, string Returned_Wear, string Returned_Receipt)
        {
            this.Name = Name;                                           //Наименование СИЗ
            this.Certificate_Of_Conformity = Certificate_Of_Conformity; //Сертификат соответствия
            this.Issued_Date = Issued_Date;                             //Выдано-дата
            this.Issued_Quantity = Issued_Quantity;                     //Выдано-количество
            this.Issued_Wear = Issued_Wear;                             //Выдано-износ
            this.Issued_Receipt = Issued_Receipt;                       //Выдано-расписка
            this.Returned_Date = Returned_Date;                         //Выдано-дата
            this.Returned_Quantity = Returned_Quantity;                 //Выдано-количество
            this.Returned_Wear = Returned_Wear;                         //Выдано-износ
            this.Returned_Receipt = Returned_Receipt;                   //Выдано-расписка
        }
        #endregion

    }
}
