//using NUnit.Framework;
//using Sparky;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SparkNUnitTest
//{
//    [TestFixture]
//    public class GradingCalculatorXUnitTests
//    {
//        private GradingCalculator gradingCalculator;

//        [SetUp]
//        public void Setup()
//        {
//            gradingCalculator = new GradingCalculator();
//        }

//        [Test]
//        public void GradeCalc_InputScoreAttendance_90_GetAGrade() {
//            gradingCalculator.Score = 95;
//            gradingCalculator.AttendancePercentage = 90;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("A"));
//        }

//        [Test]
//        public void GradeCalc_InputScore85Attendance_90_GetAGrade()
//        {
//            gradingCalculator.Score = 95;
//            gradingCalculator.AttendancePercentage = 90;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("B"));
//        }

//        [Test]
//        public void GradeCalc_InputScore65Attendance_90_GetAGrade()
//        {
//            gradingCalculator.Score = 65;
//            gradingCalculator.AttendancePercentage = 90;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("C"));
//        }

//        [Test]
//        public void GradeCalc_InputScore95Attendance_65_GetAGrade()
//        {
//            gradingCalculator.Score = 95;
//            gradingCalculator.AttendancePercentage = 65;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("B"));
//        }


//        [Test]
//        public void GradeCalc_InputScore95Attendance_55_GetAGrade()
//        {
//            gradingCalculator.Score = 95;
//            gradingCalculator.AttendancePercentage = 65;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("F"));
//        }
//        [Test]
//        public void GradeCalc_InputScore65Attendance_55_GetAGrade()
//        {
//            gradingCalculator.Score = 65;
//            gradingCalculator.AttendancePercentage = 55;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("F"));
//        }
//        [Test]
//        public void GradeCalc_InputScore50Attendance_90_GetAGrade()
//        {
//            gradingCalculator.Score = 50;
//            gradingCalculator.AttendancePercentage = 90;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("F"));
//        }

//        [Test]
//        [Theory(95,55)]
//        [Theory(65, 55)]
//        [Theory(50, 90)]
//        public void GradeCalc_FailsureScenarios_GetFGrade(int score, int attendance)
//        {
//            gradingCalculator.Score = score;
//            gradingCalculator.AttendancePercentage = attendance;
//            string result = gradingCalculator.GetGrade();
//            Assert.That(result, Is.EqualTo("F"));
//        }

//        [Test]
//        [Theory(95, 90, ExpectedResult = "A")]
//        [Theory(85, 90, ExpectedResult = "B")]
//        [Theory(65, 90, ExpectedResult = "C")]
//        [Theory(95, 65, ExpectedResult = "B")]
//        [Theory(95, 55 , ExpectedResult = "F")]
//        [Theory(65, 55 , ExpectedResult = "F")]
//        [Theory(50, 90 , ExpectedResult = "F")]
//        public string GradeCalc_FailsureScenarios_GradeOutPut(int score, int attendance)
//        {
//            gradingCalculator.Score = score;
//            gradingCalculator.AttendancePercentage = attendance;
//            return gradingCalculator.GetGrade();
            
//        }

//    }
//}
