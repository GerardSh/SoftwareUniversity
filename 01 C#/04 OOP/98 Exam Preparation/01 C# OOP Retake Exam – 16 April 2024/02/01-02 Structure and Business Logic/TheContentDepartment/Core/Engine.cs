using TheContentDepartment.Core.Contracts;
using TheContentDepartment.IO.Contracts;
using TheContentDepartment.IO;

namespace TheContentDepartment.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
            controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "JoinTeam")
                    {
                        string memberType = input[1];
                        string memberName = input[2];
                        string path = input[3];

                        result = controller.JoinTeam(memberType, memberName, path);
                    }
                    else if (input[0] == "CreateResource")
                    {
                        string resourceType = input[1];
                        string resourceName = input[2];
                        string path = input[3];

                        result = controller.CreateResource(resourceType, resourceName, path);
                    }
                    else if (input[0] == "LogTesting")
                    {
                        string memberName = input[1];

                        result = controller.LogTesting(memberName);
                    }
                    else if (input[0] == "ApproveResource")
                    {
                        string resourceName = input[1];
                        bool isTested = bool.Parse(input[2]);

                        result = controller.ApproveResource(resourceName, isTested);
                    }
                    else if (input[0] == "DepartmentReport")
                    {
                        result = controller.DepartmentReport();
                    }
                    writer.WriteLine(result);
                    writer.WriteText(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    writer.WriteText(ex.Message);
                }
            }

        }

    }
}
