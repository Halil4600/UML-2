using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_2
{
    public class Customer
    {
        #region Instance Field
        private string _name;
        private int _id;
        #endregion

        #region Constructor
        public Customer(string name, int id) 
        {
            _name = name;
            _id = id;
        }
        #endregion

        #region Properties
        public string Name 
        { 
            get { return _name; } 
            private set { _name = value; }
        
        }

        public int Id
        { 
            get { return _id; } 
            private set { _id = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Customer Id: {Id} Customer name: {Name}";
        }
        #endregion

    }
}
