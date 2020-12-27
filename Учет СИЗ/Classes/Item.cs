using System.Text.RegularExpressions;

namespace Учет_СИЗ.Classes
{
    public class Item
    {
        private string Title;
        private string Item_number;
        private string Quantity;
        private string Date_Of_Commissioning;
        private string Service_Life;
        private string Date_Of_Decommissioning;

        #region Свойства
        public string Title_GetSet
        {
            get { return Title; }
            set
            {
                Regex regex = new Regex(@"^[А-Я][а-я]+$");
                if (!regex.IsMatch(value))
                {
                    Title = "Н/Д";
                }
                else Title = value;
            }
        }
        public string Item_number_GetSet
        {
            get { return Item_number; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Item_number = "Н/Д";
                }
                else Item_number = value;
            }
        }
        public string Quantity_GetSet
        {
            get { return Quantity; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Quantity = "Н/Д";
                }
                else Quantity = value;
            }
        }
        public string Date_Of_Commissioning_GetSet
        {
            get { return Date_Of_Commissioning; }
            set
            {
                Regex regex = new Regex(@"^\d\d[.]\d\d[.]\d\d$");
                if (!regex.IsMatch(value))
                {
                    Date_Of_Commissioning = "Н/Д";
                }
                else Date_Of_Commissioning = value;
            }
        }
        public string Service_Life_GetSet
        {
            get { return Service_Life; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Service_Life = "Н/Д";
                }
                else Service_Life = value;
            }
        }
        public string Date_Of_Decommissioning_GetSet
        {

            get { return Date_Of_Decommissioning; }
            set
            {
                Regex regex = new Regex(@"^\d\d[.]\d\d[.]\d\d$");
                if (!regex.IsMatch(value))
                {
                    Date_Of_Decommissioning = "Н/Д";
                }
                else Date_Of_Decommissioning = value;
            }
        }
        #endregion

        #region Конструкторы
        public Item()
        {
            Title = "Н/Д";
            Item_number = "Н/Д";
            Quantity = "Н/Д";
            Date_Of_Commissioning = "Н/Д";
            Service_Life = "Н/Д";
            Date_Of_Decommissioning = "Н/Д";
        }
        public Item(string title,string item_number,string quantity,string date_Of_Commissioning,string service_Life,string date_Of_Decommissioning)
        {
            Title_GetSet = title;
            Item_number_GetSet = item_number;
            Quantity_GetSet = quantity;
            Date_Of_Commissioning_GetSet = date_Of_Commissioning;
            Service_Life_GetSet = service_Life;
            Date_Of_Decommissioning_GetSet = date_Of_Decommissioning;
        }
        #endregion

    }
}
