using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    interface IElectricCar : ICar
    {
        int Battery { get; }
    }
}
