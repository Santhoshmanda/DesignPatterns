using System;
namespace Design_Patterns.Structural.Composite
{
    //Object inside object
    // Component interface
    interface IFileSystemNode
    {
        void DisplayDetails(int depth);
    }

    // Leaf class representing a file
    class File : IFileSystemNode
    {
        private string name;

        public File(string name)
        {
            this.name = name;
        }

        public void DisplayDetails(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
    }

    // Composite class representing a directory
    class Directory : IFileSystemNode
    {
        private string name;
        private List<IFileSystemNode> children = new List<IFileSystemNode>();

        public Directory(string name)
        {
            this.name = name;
        }

        public void AddNode(IFileSystemNode node)
        {
            children.Add(node);
        }

        public void RemoveNode(IFileSystemNode node)
        {
            children.Remove(node);
        }

        public void DisplayDetails(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);

            foreach (var child in children)
            {
                child.DisplayDetails(depth + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating files
            IFileSystemNode file1 = new File("file1.txt");
            IFileSystemNode file2 = new File("file2.txt");
            IFileSystemNode file3 = new File("file3.txt");

            // Creating directories
            Directory dir1 = new Directory("Folder 1");
            Directory dir2 = new Directory("Folder 2");

            // Adding files to directories
            dir1.AddNode(file1);
            dir1.AddNode(file2);
            dir2.AddNode(file3);

            // Adding directories to directories
            Directory root = new Directory("Root");
            root.AddNode(dir1);
            root.AddNode(dir2);

            // Displaying file system structure
            root.DisplayDetails(0);
        }
    }

}

