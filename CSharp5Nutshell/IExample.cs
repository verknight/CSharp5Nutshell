using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5Nutshell
{
    interface IUndoable
    {
        void Undo();
    }
    public class TextBox : IUndoable
    {
        void IUndoable.Undo()
        {
            Console.WriteLine("Here first");
            Undo();
        }
        protected virtual void Undo()
        {
            Console.WriteLine("TextBox.call");
        }
    }
    public class RichTextBox : TextBox
    {
        protected override void Undo()
        {
            Console.WriteLine("RichTextBox.call");
        }

        
    }
    class IExample
    {
        
    }
}
