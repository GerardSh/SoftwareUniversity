using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Test
    {
        public static void Main()
        {

            var userByForceSide = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] commands;
                string command;
                if (input.Contains(" | "))
                {
                    commands = input
                          .Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    command = "register";
                }
                else
                {
                    commands = input
                            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    command = "join";
                }

                string forceSide;
                string forceUser;

                if (command == "register")
                {
                    forceSide = commands[0];
                    forceUser = commands[1];

                    if (!userByForceSide.ContainsKey(forceSide))
                    {
                        userByForceSide.Add(forceSide, new List<string>());
                    }

                    bool existingUser = false;

                    foreach (var userList in userByForceSide.Values)
                    {
                        if (userList.Contains(forceUser))
                        {
                            existingUser = true;
                        }
                    }

                    if (!existingUser)
                    {
                        userByForceSide[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    forceUser = commands[0];
                    forceSide = commands[1];

                    if (!userByForceSide.ContainsKey(forceSide))
                    {
                        userByForceSide.Add(forceSide, new List<string>());
                    }

                    bool existingUser = false;

                    foreach (var userList in userByForceSide.Values)
                    {
                        if (userList.Contains(forceUser))
                        {
                            existingUser = true;
                        }
                    }

                    if (!existingUser)
                    {
                        userByForceSide[forceSide].Add(forceUser);

                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                        continue;
                    }

                    if (userByForceSide[forceSide].Contains(forceUser))
                    {
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else
                    {
                        userByForceSide[userByForceSide.FirstOrDefault(x => x.Value.Contains(forceUser)).Key].Remove(forceUser);
                        userByForceSide[forceSide].Add(forceUser);

                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }

            var sortedDictionary = userByForceSide
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedDictionary)
            {
                kvp.Value.Sort();

                if (kvp.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (string user in kvp.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}




//2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp
{
    class Test
    {
        static void Main()
        {
            var membersByForceSide = new Dictionary<string, List<string>>();
            var forceSideByMembers = new Dictionary<string, string>();

            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {

                if (input.Contains(" | "))
                {
                    string[] commands = input
                                       .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = commands[0];
                    string forceUser = commands[1];

                    if (!membersByForceSide.ContainsKey(forceSide))
                    {
                        membersByForceSide.Add(forceSide, new List<string>());
                    }

                    if (!membersByForceSide.Any(x => x.Value.Contains(forceUser)))
                    {
                        membersByForceSide[forceSide].Add(forceUser);

                        forceSideByMembers.Add(forceUser, forceSide);
                    }
                }
                else
                {
                    string[] commands = input
                                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = commands[0];
                    string forceSide = commands[1];

                    if (!membersByForceSide.ContainsKey(forceSide))
                    {
                        membersByForceSide.Add(forceSide, new List<string>());

                    }

                    if (forceSideByMembers.ContainsKey(forceUser))
                    {
                        string oldForceUserSide = forceSideByMembers[forceUser];
                        membersByForceSide[oldForceUserSide].Remove(forceUser);
                    }

                    //Raboti i taka bez nujda ot vtori list  
                    //if (membersByForceSide.Any(x => x.Value.Contains(forceUser)))
                    //{
                    //    membersByForceSide[membersByForceSide.First(x => x.Value.Contains(forceUser)).Key].Remove(forceUser);
                    //}

                    membersByForceSide[forceSide].Add(forceUser);
                    forceSideByMembers[forceUser] = forceSide;

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }
            }

            var sortedForceSide = membersByForceSide
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var forceSide in sortedForceSide)
            {
                if (forceSide.Value.Count == 0)
                {
                    break;
                }

                Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");

                forceSide.Value.Sort();

                foreach (string member in forceSide.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }

        }
    }
}




//3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp
{
    class Test
    {
        static void Main()
        {
            Dictionary<string, List<string>> usersBySide = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] firstCommand = input
                  .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = firstCommand[0];
                    string forceUser = firstCommand[1];

                    bool doesExist = false;

                    foreach (var users in usersBySide.Values)
                    {
                        if (users.Contains(forceUser))
                        {
                            doesExist = true;
                            break;
                        }
                    }

                    if (!usersBySide.ContainsKey(forceSide))
                    {
                        usersBySide.Add(forceSide, new List<string>());
                    }

                    if (!doesExist)
                    {
                        usersBySide[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    string[] secondCommand = input
            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = secondCommand[1];
                    string forceUser = secondCommand[0];

                    foreach (var users in usersBySide.Values)
                    {
                        users.Remove(forceUser);
                    }

                    if (!usersBySide.ContainsKey(forceSide))
                    {
                        usersBySide.Add(forceSide, new List<string>());
                    }

                    usersBySide[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            usersBySide = usersBySide.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in usersBySide)
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var user in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}