using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CastleLegends.Editor.Commands;

namespace CastleLegends.Editor.Tests
{ 
    public class StringAddCommand : ICommand
    {   
        private string _toAdd = string.Empty;

        public StringAddCommand(string source, string toAdd) {
            Source = source;
            _toAdd = toAdd;
        }

        public void Execute()
        {
            Source = Source + _toAdd;
        }

        public void Undo()
        {
            var start = Source.Length - _toAdd.Length;
            Source = Source.Remove(start, _toAdd.Length);
        }

        public string Source { get; private set; }
    }
        
    public class DataOpCommand : ICommand
    {   
        private int _value = 0;

        public DataOpCommand(TestData data, int value, Operations op)
        {
            this.Data = data;
            this.Op = op;
            _value = value;
        }

        public void Execute()
        {
            switch(this.Op){
                case Operations.ADD:
                    this.Data.Value += _value;
                    break;
                case Operations.REMOVE:
                    this.Data.Value -= _value;
                    break;
            }            
        }

        public void Undo()
        {
            switch (this.Op)
            {
                case Operations.ADD:
                    this.Data.Value -= _value;
                    break;
                case Operations.REMOVE:
                    this.Data.Value += _value;
                    break;
            }     
        }

        public TestData Data { get; private set; }
        public Operations Op { get; private set; }

        public enum Operations{
            ADD,
            REMOVE
        }
    }
}
