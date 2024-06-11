using System;
namespace Design_Patterns.Structural.Proxy
{

    interface IFileManager
    {
        void ReadFile(string fileName);
    }

    class FileManager : IFileManager
    {
        public void ReadFile(string fileName)
        {
            Console.WriteLine($"Reading file: {fileName}");
        }
    }

    class AccessControlProxy : IFileManager
    {
        private readonly IFileManager _fileManager;
        private readonly List<string> _allowedUsers = new List<string> { "admin", "manager" };

        public AccessControlProxy(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public void ReadFile(string fileName)
        {
            if (IsUserAllowed())
            {
                _fileManager.ReadFile(fileName);
            }
            else
            {
                Console.WriteLine("Access denied.");
            }
        }

        private bool IsUserAllowed()
        {
            // Check user's permissions
            return _allowedUsers.Contains(GetCurrentUser());
        }

        private string GetCurrentUser()
        {
            // Simulate getting current user
            return "user";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFileManager fileManager = new AccessControlProxy(new FileManager());
            fileManager.ReadFile("document.txt"); // Access denied.
        }
    }

}

