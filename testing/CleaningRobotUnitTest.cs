using CleaningRobot.Interfaces;
using CleaningRobot;
using NUnit.Framework;
using System.Collections.Generic;

namespace CleaningRobotTesting
{
    [TestFixture]
    public class CleaningRobotUnitTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        #region East Movement
        [Test]
        public void MoveEast1Step_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.East(1);
            Assert.Equals(r.CurrentPosition, (2, 1));
        }

        [Test]
        public void MoveEast10Steps_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.East(10);
            Assert.Equals(r.CurrentPosition, (11, 1));
        }
        #endregion

        #region West Movement
        [Test]
        public void MoveWest1Step_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.West(1);
            Assert.Equals(r.CurrentPosition, (0, 1));
        }

        [Test]
        public void MoveWest10Steps_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.West(10);
            Assert.Equals(r.CurrentPosition, (-9, 1));
        }
        #endregion

        #region North Movement
        [Test]
        public void MoveNorth1Step_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.North(1);
            Assert.Equals(r.CurrentPosition, (1, 2));
        }

        [Test]
        public void MoveNorth10Steps_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.North(10);
            Assert.Equals(r.CurrentPosition, (1, 11));
        }
        #endregion

        #region South Movement
        [Test]
        public void MoveSouth1Step_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.South(1);
            Assert.Equals(r.CurrentPosition, (1, 0));
        }

        [Test]
        public void MoveSouth10Steps_CurrentPosition_ReturnsCorrectMovement()
        {
            Robot r = new Robot((1, 1));
            r.South(10);
            Assert.Equals(r.CurrentPosition, (1, -9));
        }
        #endregion

        #region Reset Robot
        [Test]
        public void MoveAndReset_CurrentPosition_ReturnsCorrectStartPosition()
        {
            Robot r = new Robot((1, 1));
            r.South(1);
            r.West(10);
            r.Reset();
            Assert.Equals(r.CurrentPosition, (1, 1));
        }
        #endregion 

        #region Start Cleaning
        [Test]
        public void StartCleaning_NonOverlappingMovements1_UniqueVisitedSpots_Correct()
        {
            Robot r = new Robot((1, 1));
            int uniqueMovements = r.StartCleaning(new List<(char, int)> { 
                ('E',3),
                ('N',3),
                ('W',3)
            });
            Assert.Equals(uniqueMovements, 10);
        }

        [Test]
        public void StartCleaning_NonOverlappingMovements2_UniqueVisitedSpots_Correct()
        {
            Robot r = new Robot((1, 1));
            int uniqueMovements = r.StartCleaning(new List<(char, int)> {
                ('E',9000),
                ('N',9000),
                ('W',9000)
            });
            Assert.Equals(uniqueMovements, 27001);
        }

        [Test]
        public void StartCleaning_OverlappingMovements1_UniqueVisitedSpots_Correct()
        {
            Robot r = new Robot((1, 1));
            int uniqueMovements = r.StartCleaning(new List<(char, int)> {
                ('E',3),
                ('N',3),
                ('W',3),
                ('S',5)
            });
            Assert.Equals(uniqueMovements, 14);
        }

        [Test]
        public void StartCleaning_NonOverlapping_UniqueVisitedSpots_Correct()
        {
            Robot r = new Robot((10, 22));
            int uniqueMovements = r.StartCleaning(new List<(char, int)> {
                ('E',2),
                ('N',1)
            });
            Assert.Equals(uniqueMovements, 4);
        }
        #endregion 
    }
}