using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleLegends.Editor.Commands
{
    public static class CommandManager
    {
        private static Queue<ICommand> _commands;
        private static Stack<ICommand> _undoCommands;

        static CommandManager()
        {
            _commands = new Queue<ICommand>();
            _undoCommands = new Stack<ICommand>();
        }

        public static void Clear() {
            _commands.Clear();
            _undoCommands.Clear();
        }

        public static void Add(ICommand command) {
            if (null == command)
                throw new ArgumentNullException("command");
            _commands.Enqueue(command);
        }

        public static void AddAndExecute(ICommand command)
        {
            Add(command);
            ExecuteCommands();
        }

        public static void ExecuteCommand()
        {
            ExecuteCommands(true);
        }

        public static void ExecuteCommands()
        {
            ExecuteCommands(false);
        }

        public static void ExecuteCommands(bool lastOnly)
        {
            if (!_commands.Any())
                return;

            var executedCommands = new List<ICommand>();

            while (0 != _commands.Count) {
                var command = _commands.Dequeue();
                command.Execute();

                _undoCommands.Push(command);
                executedCommands.Add(command);
                if (lastOnly) break;
            }

            if (null != CommandsExecuted)
                CommandsExecuted(new CommandEventArgs(executedCommands.ToArray(), false));
        }

        public static void UndoCommand() {
            UndoCommands(true);
        }

        public static void UndoCommands()
        {
            UndoCommands(false);
        }

        public static void UndoCommands(bool lastOnly)
        {
            if (!_undoCommands.Any())
                return;

            var executedCommands = new List<ICommand>();

            while (0 != _undoCommands.Count)
            {
                var command = _undoCommands.Pop();
                command.Undo();

                _commands.Enqueue(command);
                executedCommands.Add(command);
                if (lastOnly) break;
            }

            if (null != CommandsUndo)
                CommandsUndo(new CommandEventArgs(executedCommands.ToArray(), true));
        }

        public static int UndoCount {
            get { return _undoCommands.Count; }
        }

        public static int Count
        {
            get { return _commands.Count; }
        }

        #region Custom Events

        public delegate void CommandEventHandler(CommandEventArgs data);
        public static event CommandEventHandler CommandsExecuted;
        public static event CommandEventHandler CommandsUndo;

        #endregion Custom Events
    }

    public class CommandEventArgs : EventArgs
    {
        public CommandEventArgs(IEnumerable<ICommand> commands, bool isUndo)
        {
            this.Commands = commands;
            this.IsUndo = isUndo;
        }

        public IEnumerable<ICommand> Commands { get; private set; }
        public bool IsUndo { get; private set; }
    }
}
