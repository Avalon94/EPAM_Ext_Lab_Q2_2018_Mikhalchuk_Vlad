using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        #region Supported things
        private DataBase<User> dataBase = new DataBase<User>();

        private List<int> IDs = new List<int>();

        private Random r = new Random();

        private User Expected;

        private int MinRandomValue = default, MaxRandomValue = 100;

        public void GetAllID()
        {
            foreach (var user in dataBase.DataBaseEmulator)
            {
                IDs.Add(user.Id);
            }
        }
        #endregion

        #region Delete
        [TestMethod]
        public void IsDeleteByExistingID()
        {
            GetAllID();

            int id = IDs[r.Next(0, IDs.Count)];

            bool expected = dataBase.Delete(id);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void IsDeleteByNonexistingID()
        {
            GetAllID();

            int id = r.Next(IDs.Count + 1, IDs.Count * 2);

            var expected = dataBase.Delete(id);

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void IsDeleteWithoutID()
        {
            Assert.IsFalse(dataBase.Delete());
        }
        #endregion

        #region Save
        [TestMethod]
        public void IsSaved()
        {
            int rndID = r.Next(MinRandomValue, MaxRandomValue);

            bool expected = dataBase.Save(new User() { Id = rndID });

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void IsSavedEntityEquals()
        {
            int rndID = r.Next(MinRandomValue, MaxRandomValue);

            dataBase.Save(new User() { Id = rndID });

            GetAllID();

            bool expected = IDs[IDs.Count - 1].Equals(rndID);

            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void IsSavedEntityNotEquals()
        {
            int rndID = r.Next(MinRandomValue, MaxRandomValue);

            dataBase.Save(new User() { Id = rndID + 1 });

            GetAllID();

            bool expected = IDs[IDs.Count - 1].Equals(rndID);

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void IsSavedNull()
        {
            bool expected = dataBase.Save();

            Assert.IsFalse(expected);
        }
        #endregion

        #region Get
        [TestMethod]
        public void GetExpected()
        {
            GetAllID();

            var rndID = IDs[r.Next(MinRandomValue, IDs.Count - 1)];

            var actual = dataBase.Get(rndID);

            foreach (var user in dataBase.DataBaseEmulator)
            {
                if (user.Id == rndID)
                {
                    Expected = user;

                    return;
                }
            }

            Assert.AreEqual(Expected, actual);
        }

        [TestMethod]
        public void GetUnexpected()
        {
            GetAllID();

            var rndID = r.Next(IDs.Count + 1, MaxRandomValue);

            var actual = dataBase.Get(rndID);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetNull()
        {
            Assert.IsNull(dataBase.Get());
        }
        #endregion

        #region GetAll
        [TestMethod]
        public void IsGetAllAreEqual()
        {
            Assert.AreEqual(dataBase.GetAll(), dataBase.DataBaseEmulator);
        }

        [TestMethod]
        public void IsGetAllHashCodeAreEqual()
        {
            var ExpectedHash = dataBase.DataBaseEmulator.GetHashCode();

            var ActualHash = dataBase.GetAll().GetHashCode();

            Assert.AreEqual(ExpectedHash, ActualHash);
        }

        [TestMethod]
        public void IsGetAllNumberOfElementsAreEqual()
        {
            var ExpectedCount = dataBase.DataBaseEmulator.Count;

            var ActualCount = dataBase.GetAll().Count;

            Assert.AreEqual(ExpectedCount, ActualCount);
        }
        #endregion
    }
}

