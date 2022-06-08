using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningRobot.Interfaces
{
    public interface IRobot
    {
        (int, int) InitialPosition { get; }
        (int, int) CurrentPosition { get; }

        Int32 StartCleaning(List<(char, int)> instructions);
        void Reset();
        void East(int steps);
        void West(int steps);
        void North(int steps);
        void South(int steps);
    }
}
