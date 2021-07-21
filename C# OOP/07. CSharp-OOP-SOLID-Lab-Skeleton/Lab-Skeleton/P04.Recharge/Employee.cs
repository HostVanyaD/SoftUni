﻿namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }

        public override void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}
