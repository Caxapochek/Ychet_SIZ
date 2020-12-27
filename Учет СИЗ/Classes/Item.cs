using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учет_СИЗ.Classes
{
    public class Item
    {
        string Title;
        string Item_number;
        string Quantity;
        string Date_Of_Commissioning;
        string Service_Life;
        string Date_Of_Decommissioning;

        //Свойства
        public string Title_GetSet
        {
            get { return Title; }
            set
            {
                if (string.IsNullOrEmpty(value))
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
                if (string.IsNullOrEmpty(value))
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
                if (string.IsNullOrEmpty(value))
                {
                    Date_Of_Decommissioning = "Н/Д";
                }
                else Date_Of_Decommissioning = value;
            }
        }



        //Конструкторы
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
            Title = title;
            Item_number = item_number;
            Quantity = quantity;
            Date_Of_Commissioning = date_Of_Commissioning;
            Service_Life = service_Life;
            Date_Of_Decommissioning = date_Of_Decommissioning;
        }
    }
}
