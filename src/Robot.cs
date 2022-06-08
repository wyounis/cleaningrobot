using CleaningRobot.Interfaces;
using System;
using System.Collections.Generic;

namespace CleaningRobot
{
    public class Robot : IRobot
    {
        public (int, int) InitialPosition { get; }
        public (int, int) CurrentPosition { get; }
        private HashSet<string> VisitedSpots = new HashSet<string>();
        private Int32 UniqueVisitedSpots;

        public Robot((int, int) startPosition)
        {
            InitialPosition = startPosition;
            CurrentPosition = startPosition;
            VisitedSpots.Add(String.Format("{0},{1}", startPosition.Item1, startPosition.Item2));
            UniqueVisitedSpots = 1;
        }

        public Int32 StartCleaning(List<(char, int)> instructions)
        {
            throw new NotImplementedException();
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
        public void East(int steps)
        {
            throw new NotImplementedException();
        }
        public void West(int steps)
        {
            throw new NotImplementedException();
        }
        public void North(int steps)
        {
            throw new NotImplementedException();
        }
        public void South(int steps)
        {
            throw new NotImplementedException();
        }
    }
}
