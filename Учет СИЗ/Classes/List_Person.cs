using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Учет_СИЗ
{
    [Serializable]
    public class List_Persons<Person>
    {
        public List<Person> List_Of_Person = new List<Person>();

        //Методы
        

        public int Count                                                              
        {
            get
            {
                return List_Of_Person.Count;
            }
        }
        public void AddAfter(Person value)     
        {
            List_Of_Person.Add(value);
        }
        

    }
}
