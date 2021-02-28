using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учет_СИЗ.Classes
{
    public class Sizes
    {
        private string Height;                      //Рост
        private string Clothing_Size;               //Размер одежды
        private string Shoe_Size;                   //Размер обуви
        private string Headdress_Size;              //Размер головного убора
        private string Gas_Mask_Size;               //Размер противогаза
        private string Raspirator_Size;             //Размер распиратора
        private string Mittens_Size;                //Размер руковиц
        private string Gloves_Size;                 //Размер перчаток

        #region Свойства
        public string Change_Height
        {
            get { return Height; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
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
                    Gloves_Size = "Н/Д";
                }
                else Gloves_Size = value;
            }
        }
        #endregion

        #region Конструкторы
        public Sizes()
        {
            Height = "Н/Д";                      //Рост
            Clothing_Size = "Н/Д";               //Размер одежды
            Shoe_Size = "Н/Д";                   //Размер обуви
            Headdress_Size = "Н/Д";              //Размер головного убора
            Gas_Mask_Size = "Н/Д";               //Размер противогаза
            Raspirator_Size = "Н/Д";             //Размер распиратора
            Mittens_Size = "Н/Д";                //Размер руковиц
            Gloves_Size = "Н/Д";                 //Размер перчаток
        }

        public Sizes(string Height, string Clothing_Size, string Shoe_Size, string Headdress_Size, string Gas_Mask_Size, string Raspirator_Size,
            string Mittens_Size, string Gloves_Size)
        {
            this.Height = Height;                      //Рост
            this.Clothing_Size = Clothing_Size;               //Размер одежды
            this.Shoe_Size = Shoe_Size;                   //Размер обуви
            this.Headdress_Size = Headdress_Size;              //Размер головного убора
            this.Gas_Mask_Size = Gas_Mask_Size;               //Размер противогаза
            this.Raspirator_Size = Raspirator_Size;             //Размер распиратора
            this.Mittens_Size = Mittens_Size;                //Размер руковиц
            this.Gloves_Size = Gloves_Size;                 //Размер перчаток
        }
        #endregion
    }
}
