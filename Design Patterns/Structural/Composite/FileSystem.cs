using System;
namespace Design_Patterns.Structural.Composite
{    

    using System;
using System.Collections.Generic;

// Component: Defines the common interface for both files and directories.
public abstract class FileSystemItem
{
    protected string Name;

    public FileSystemItem(string name)
    {
        Name = name;
    }

    public abstract void Display();
}

// Leaf: Represents a file.
public class File : FileSystemItem
{
    public File(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine($"File: {Name}");
    }
}

// Composite: Represents a directory that can contain files or other directories.
public class Directory : FileSystemItem
{
    private readonly List<FileSystemItem> _items = new();

    public Directory(string name) : base(name) { }

    public void Add(FileSystemItem item)
    {
        _items.Add(item);
    }

    public void Remove(FileSystemItem item)
    {
        _items.Remove(item);
    }

    public override void Display()
    {
        Console.WriteLine($"Directory: {Name}");
        foreach (var item in _items)
        {
            item.Display();
        }
    }
}

// Client: Builds and interacts with the filesystem.
public class Program
{
    public static void Main()
    {
        // Create files
        var file1 = new File("File1.txt");
        var file2 = new File("File2.txt");
        var file3 = new File("File3.txt");

        // Create directories
        var subDirectory1 = new Directory("SubDirectory1");
        var subDirectory2 = new Directory("SubDirectory2");
        var rootDirectory = new Directory("RootDirectory");

        // Build the filesystem structure
        subDirectory1.Add(file1);
        subDirectory1.Add(file2);

        subDirectory2.Add(file3);

        rootDirectory.Add(subDirectory1);
        rootDirectory.Add(subDirectory2);

        // Display the entire filesystem
        rootDirectory.Display();
    }
}

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

