using CleaningRobot.Interfaces;
using System;
using System.Collections.Generic;

namespace CleaningRobot
{
    public class Robot : IRobot
    {
        public (int, int) InitialPosition { get; private set; }
        public (int, int) CurrentPosition { get; private set; }
        private HashSet<string> VisitedSpots = new HashSet<string>();
        private Int32 UniqueVisitedSpots;

        public Robot((int, int) startPosition)
        {
            InitialPosition = startPosition;
            CurrentPosition = startPosition;
            VisitedSpots.Add(FormatPoint(startPosition.Item1, startPosition.Item2));
            UniqueVisitedSpots = 1;
        }
        public Int32 StartCleaning(List<(char, int)> instructions)
        {
            foreach(var instruction in instructions)
            {
                switch (instruction.Item1)
                {
                    case 'E':
                        East(instruction.Item2);
                        break;
                    case 'W':
                        West(instruction.Item2);
                        break;
                    case 'N':
                        North(instruction.Item2);
                        break;
                    case 'S':
                        South(instruction.Item2);
                        break;
                }
            }

            return UniqueVisitedSpots;
        }
        public void Reset()
        {
            CurrentPosition = InitialPosition;
            VisitedSpots = new HashSet<string>();
            UniqueVisitedSpots = 1;
        }
        public void East(int steps)
        {
            while (steps > 0)
            {
                CurrentPosition = (CurrentPosition.Item1 + 1, CurrentPosition.Item2);
                if (!VisitedSpots.Contains(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2)))
                {
                    VisitedSpots.Add(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2));
                    UniqueVisitedSpots++;
                }
                steps--;
            }
        }
        public void West(int steps)
        {
            while (steps > 0)
            {
                CurrentPosition = (CurrentPosition.Item1 - 1, CurrentPosition.Item2);
                if (!VisitedSpots.Contains(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2)))
                {
                    VisitedSpots.Add(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2));
                    UniqueVisitedSpots++;
                }
                steps--;
            }
        }
        public void North(int steps)
        {
            while (steps > 0)
            {
                CurrentPosition = (CurrentPosition.Item1, CurrentPosition.Item2 + 1);
                if (!VisitedSpots.Contains(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2)))
                {
                    VisitedSpots.Add(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2));
                    UniqueVisitedSpots++;
                }
                steps--;
            }
        }
        public void South(int steps)
        {
            while (steps > 0)
            {
                CurrentPosition = (CurrentPosition.Item1, CurrentPosition.Item2 - 1);
                if (!VisitedSpots.Contains(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2)))
                {
                    VisitedSpots.Add(FormatPoint(CurrentPosition.Item1, CurrentPosition.Item2));
                    UniqueVisitedSpots++;
                }
                steps--;
            }
        }

        private string FormatPoint(int x, int y)
        {
            return String.Format("{0},{1}", x, y);
        }
    }
}
