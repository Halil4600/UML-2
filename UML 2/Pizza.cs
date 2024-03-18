using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_2
{
    public class Pizza
    {
        #region Instance field
        private string _name;
        private int _price;
        private string _pizzaId;
        #endregion

        #region Constructor
        public Pizza(string name, int price, string pizzaId)
        {
            _name = name;
            _price = price;
            _pizzaId = pizzaId;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public int Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        public string PizzaId
        {
            get { return _pizzaId; }
            private set { _pizzaId = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Pizza id: {PizzaId} Name: {Name} - Price {Price}";
        }
        #endregion

    }
}
