using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcWin.Models.Calculator
{
    public class Ingredients
    {
        public Fruit Fruit { get { return _fruit; } set { _fruit = value; } }
        private Fruit _fruit;

        public bool Selected { get { return _selected; } set { _selected = value; } }
        private bool _selected;

        public double Quantity { get { return _quantity; } set { _quantity = value; } }
        private double _quantity;
    }
}
