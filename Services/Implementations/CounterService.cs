using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Services.Abstractions;

namespace WebProject.Services.Implementations
{
    public class CounterService : ICounterService
    {
        private int _counter;
        public int IncreaseCounter()
        {
            ++_counter;
            return _counter;
        }
    }
}