namespace TimeManagere.Tests
{
    [TestClass]
    public class TimeManagerTests
    {
        [TestMethod]
        public void UtcAfterCreate()
        {
            var timeManager = new TimeManager();
            var dateTime = timeManager.GetTime();
            Assert.IsTrue(dateTime.EndsWith("+00:00"));
        }

        [TestMethod]
        public void SetExistsTimeZone()
        {
            var timeManager = new TimeManager();
            Assert.IsTrue(timeManager.SetTimeZone("America/Guatemala"));
            Assert.IsTrue(timeManager.GetTime().EndsWith("-06:00"));
        }

        [TestMethod]
        public void SetNotExistsTimeZone()
        {
            var timeManager = new TimeManager();
            Assert.IsTrue(timeManager.SetTimeZone("America/Guatemala"));
            Assert.IsFalse(timeManager.SetTimeZone("NotExistsTimeZoneName"));
            Assert.IsTrue(timeManager.GetTime().EndsWith("-06:00"));
            Assert.IsTrue(timeManager.SetTimeZone("Europe/Moscow"));
            Assert.IsFalse(timeManager.SetTimeZone("NotExistsTimeZoneName"));
            Assert.IsTrue(timeManager.GetTime().EndsWith("+03:00"));
        }

        [TestMethod]
        public void ConvertDataFormat1()
        {
            var expectedResult = "13.01.2023 01:02:00 +00:00";
            var timeManager = new TimeManager();
            var result = timeManager.ConvertDate("13.01.2023 01:02");
            Assert.IsTrue(expectedResult == result);
        }

        [TestMethod]
        public void ConvertDataFormat2()
        {
            var expectedResult = "14.01.2023 02:03:04 +00:00";
            var timeManager = new TimeManager();
            var result = timeManager.ConvertDate("14/01/2023 02-03-04");
            Assert.IsTrue(expectedResult == result);
        }

        [TestMethod]
        public void ConvertDataFormat3()
        {
            var expectedResult = "15.01.2023 03:04:05 +04:00";
            var timeManager = new TimeManager();
            var result = timeManager.ConvertDate("15.01.2023 03:04:05 +04:00");
            Assert.IsTrue(expectedResult == result);
        }

        [TestMethod]
        public void ConvertDataNotExistsFormat()
        {
            var expectedResult = "";
            var timeManager = new TimeManager();
            var result = timeManager.ConvertDate("15/01/2023 03:04:05 +04:00");
            Assert.IsTrue(expectedResult == result);
        }
    }
}