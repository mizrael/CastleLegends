using CastleLegends.Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CastleLegends.Editor.Tests
{
    public class TestData {
        public int Value = 0;
    }

    /// <summary>
    ///This is a test class for CommandManager_Test and is intended
    ///to contain all CommandManager_Test Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandManager_UndoTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
            

        [TestMethod()]
        public void UndoTest()
        {
            var data = new TestData();

            var command1 = new DataOpCommand(data, 1, DataOpCommand.Operations.ADD);

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.ExecuteCommands();

            Assert.AreEqual(1, data.Value);

            CommandManager.UndoCommands();

            Assert.AreEqual(0, data.Value);
        }

        [TestMethod()]
        public void MultipleUndoTest()
        {
            var data = new TestData();

            var command1 = new DataOpCommand(data, 1, DataOpCommand.Operations.ADD);

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.ExecuteCommands();

            var command2 = new DataOpCommand(data, 2, DataOpCommand.Operations.ADD);
            CommandManager.Add(command2);
            CommandManager.ExecuteCommands();

            Assert.AreEqual(3, data.Value);

            CommandManager.UndoCommand();
            Assert.AreEqual(1, data.Value);
        }

        [TestMethod()]
        public void MultipleUndoTest1()
        {
            var data = new TestData();

            var command1 = new DataOpCommand(data, 1, DataOpCommand.Operations.ADD);

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.ExecuteCommands();

            var command2 = new DataOpCommand(data, 2, DataOpCommand.Operations.ADD);
            CommandManager.Add(command2);
            CommandManager.ExecuteCommands();

            CommandManager.UndoCommands();
            Assert.AreEqual(0, data.Value);
        }
    }
}

