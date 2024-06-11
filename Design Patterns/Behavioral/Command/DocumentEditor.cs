using System;
namespace Design_Patterns.Behavioral.Command2
{
	//receiver as it is
	public class Document
	{
		public Document()
		{

		}
        public void Copy() { /* Copy text */ }
        public void Paste() { /* Paste text */ }
        public void Format() { /* Format text */ }



    }

	//command
	public interface ICommand
	{
		public void Execute();
        public void Undo();
	}

    public class CopyCommand : ICommand
	{
        Document doc;
		public CopyCommand(Document doc)
		{
			this.doc = doc;
		}

		public void Execute()
		{
			this.doc.Copy();

		}

        public void Undo()
        {
            //clear clipboard
        }
    }

    public class PasteCommand : ICommand
    {
        Document doc;
        public PasteCommand(Document documentEditor)
        {
            this.doc = documentEditor;
        }

        public void Execute()
        {
            doc.Paste();

        }

        public void Undo()
        {
            //clear last pasted content from document
        }
    }



    public class FormatCommand : ICommand
    {
        Document doc;
        public FormatCommand(Document doc)
        {
            this.doc = doc;
        }

        public void Execute()
        {
            doc.Format();

        }

        public void Undo()
        {
            //unformat the document
        }
    }


    //Invoker

    public class DocumentEditor
    {
        ICommand command;
        Stack<ICommand> comandsHistory = new Stack<ICommand>();
        public DocumentEditor(ICommand command)
        {
            this.command = command;

        }

        public void Execute()
        {
            this.command.Execute();
            this.comandsHistory.Push(command);
        }

        public void Undo()
        {
            //nullcheck
            var command=comandsHistory.Pop();
            command.Undo();

        }


    }


    //CLient


    public class Client
    {
        public void Test()
        {
            var DocumentEditor = new DocumentEditor(new CopyCommand(new Document()));
            DocumentEditor.Execute();
            DocumentEditor.Undo();

        }
    }


}

