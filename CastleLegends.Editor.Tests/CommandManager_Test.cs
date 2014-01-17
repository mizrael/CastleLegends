using CastleLegends.Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CastleLegends.Editor.Tests
{
  
    /// <summary>
    ///This is a test class for CommandManager_Test and is intended
    ///to contain all CommandManager_Test Unit Tests
    ///</summary>
    [TestClass()]
    public class CommandManager_Test
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
        public void AddTest()
        {
            ICommand command = new StringAddCommand("mamma", "mia");

            CommandManager.Clear();
            CommandManager.Add(command);

            Assert.AreEqual(CommandManager.Count, 1);
            Assert.AreEqual(CommandManager.UndoCount, 0);
        }

        [TestMethod()]
        public void AddTest1()
        {
            StringAddCommand command1 = new StringAddCommand("mamma", "mia");
            StringAddCommand command2 = new StringAddCommand("mamma", "mia");

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.Add(command2);

            Assert.AreEqual(CommandManager.Count, 2);
            Assert.AreEqual(CommandManager.UndoCount, 0);
        }

        [TestMethod()]
        public void MultipleExecuteTest()
        {
            var text = "mamma";

            var command1 = new StringAddCommand(text, "mia");          

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.ExecuteCommands();

            Assert.AreEqual("mammamia", command1.Source);

            var command2 = new StringAddCommand(command1.Source, "tua");
            CommandManager.Add(command2);

            Assert.AreEqual(1, CommandManager.Count);
            Assert.AreEqual(1, CommandManager.UndoCount);            

            CommandManager.ExecuteCommands();

            Assert.AreEqual("mammamiatua", command2.Source);

            Assert.AreEqual(0, CommandManager.Count);
            Assert.AreEqual(2, CommandManager.UndoCount);
        }

        [TestMethod()]
        public void MultipleExecuteUndoTest()
        {
            var text = "mamma";

            var command1 = new StringAddCommand(text, "mia");

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.ExecuteCommands();

            var command2 = new StringAddCommand(command1.Source, "tua");
            CommandManager.Add(command2);
            CommandManager.ExecuteCommands();
            
            CommandManager.UndoCommands();

            Assert.AreEqual("mammamia", command2.Source);
            Assert.AreEqual("mamma", command1.Source);
        }

        [TestMethod()]
        public void MultipleExecuteRedoTest()
        {
            var text = "mamma";

            var command1 = new StringAddCommand(text, "mia");

            CommandManager.Clear();
            CommandManager.Add(command1);
            CommandManager.ExecuteCommands();

            var command2 = new StringAddCommand(command1.Source, "tua");
            CommandManager.Add(command2);
            CommandManager.ExecuteCommands();

            CommandManager.UndoCommands();

            CommandManager.ExecuteCommands();

            Assert.AreEqual("mammamia", command1.Source);
            Assert.AreEqual("mammamiatua", command2.Source);
        }

        /// <summary>
        ///A test for AddAndExecute
        ///</summary>
        [TestMethod()]
        public void AddAndExecuteTest()
        {
            StringAddCommand command = new StringAddCommand("mamma", "mia");

            CommandManager.Clear();
            CommandManager.AddAndExecute(command);

            Assert.AreEqual(CommandManager.Count, 0);

            Assert.AreEqual("mammamia", command.Source);

            Assert.AreEqual(1, CommandManager.UndoCount);
        }

        /// <summary>
        ///A test for UndoCommands
        ///</summary>
        [TestMethod()]
        public void UndoCommandsTest()
        {
            StringAddCommand command = new StringAddCommand("mamma", "mia");

            CommandManager.Clear();
            CommandManager.AddAndExecute(command);

            CommandManager.UndoCommands();

            Assert.AreEqual("mamma", command.Source);
            Assert.AreEqual(0, CommandManager.UndoCount);
            Assert.AreEqual(1, CommandManager.Count);
        }
    }
}

