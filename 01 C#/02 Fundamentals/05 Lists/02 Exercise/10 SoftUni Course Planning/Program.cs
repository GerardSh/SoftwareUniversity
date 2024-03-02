List<string> schedule = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "course start")
{
    string[] commands = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    string lesson = commands[1];

    if (command == "Add")
    {
        if (!schedule.Contains(lesson))
        {
            schedule.Add(lesson);
        }
    }
    else if (command == "Insert")
    {
        int index = int.Parse(commands[2]);

        if (!schedule.Contains(lesson))
        {
            schedule.Insert(index, lesson);
        }
    }
    else if (command == "Remove")
    {
        for (int i = 0; i < schedule.Count; i++)
        {
            string temp = schedule[i];

            if (temp.Contains(commands[1]))
            {
                schedule.RemoveAt(i--);
            }
        }
    }
    else if (command == "Swap")
    {
        string secondLesson = commands[2];

        if (schedule.Contains(secondLesson) && schedule.Contains(lesson))
        {
            int firstIndex = schedule.IndexOf(lesson);
            int secondIndex = schedule.IndexOf(secondLesson);
            int firstLessonCount = 0;
            int secondLessonCount = 0;

            foreach (string element in schedule)
            {
                if (element.Contains(lesson))
                {
                    firstLessonCount++;
                }
                else if (element.Contains(secondLesson))
                {
                    secondLessonCount++;
                }
            }

            if (firstLessonCount == 1 && secondLessonCount == 1)
            {
                string temp = schedule[firstIndex];
                schedule[firstIndex] = schedule[secondIndex];
                schedule[secondIndex] = temp;
            }
            else if (firstLessonCount == 2 && secondLessonCount == 1)
            {
                string temp = schedule[firstIndex];
                string temp2 = schedule[firstIndex + 1];
                schedule[firstIndex] = schedule[secondIndex];
                schedule[secondIndex] = temp2;
                schedule.Insert(secondIndex, temp);

                for (int i = 1; i < schedule.Count; i++)
                {
                    if (schedule[i] == temp2 && schedule[i - 1] != temp)
                    {
                        schedule.RemoveAt(i);
                    }
                }
            }
            else if (firstLessonCount == 1 && secondLessonCount == 2)
            {
                string temp = schedule[secondIndex];
                string temp2 = schedule[secondIndex + 1];
                schedule[secondIndex] = schedule[firstIndex];
                schedule[firstIndex] = temp2;
                schedule.Insert(firstIndex, temp);

                for (int i = 1; i < schedule.Count; i++)
                {
                    if (schedule[i] == temp2 && schedule[i - 1] != temp)
                    {
                        schedule.RemoveAt(i);
                    }
                }
            }
            else
            {
                string temp = schedule[firstIndex];
                string temp2 = schedule[firstIndex + 1];
                schedule[firstIndex] = schedule[secondIndex];
                schedule[firstIndex + 1] = schedule[secondIndex + 1];
                schedule[secondIndex] = temp;
                schedule[secondIndex + 1] = temp2;
            }
        }
    }
    else if (command == "Exercise")
    {
        string ex = lesson + "-Exercise";

        if (schedule.Contains(lesson))
        {
            if (!schedule.Contains(ex))
            {
                int index = schedule.IndexOf(lesson);
                schedule.Insert(index + 1, ex);
            }
        }
        else
        {
            if (!schedule.Contains(lesson))
            {
                schedule.Add(lesson);
                schedule.Add(ex);
            }
        }
    }
}

for (int i = 0; i < schedule.Count; i++)
{
    Console.WriteLine($"{i + 1}.{schedule[i]}");
}

////2
//List<string> schedule = Console.ReadLine()
//    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
//    .ToList();

//string input;

//while ((input = Console.ReadLine()) != "course start")
//{
//    string[] commands = input
//        .Split(":", StringSplitOptions.RemoveEmptyEntries);
//    string command = commands[0];
//    string lesson = commands[1];

//    if (command == "Add")
//    {
//        if (!schedule.Contains(lesson))
//        {
//            schedule.Add(lesson);
//        }
//    }
//    else if (command == "Insert")
//    {
//        int index = int.Parse(commands[2]);

//        if (!schedule.Contains(lesson))
//        {
//            schedule.Insert(index, lesson);
//        }
//    }
//    else if (command == "Remove")
//    {
//        for (int i = 0; i < schedule.Count; i++)
//        {
//            string temp = schedule[i];

//            if (temp.Contains(commands[1]))
//            {
//                schedule.RemoveAt(i--);
//            }
//        }
//    }
//    else if (command == "Swap")
//    {
//        string secondLesson = commands[2];

//        if (schedule.Contains(secondLesson) && schedule.Contains(lesson))
//        {
//            int firstLesonIndex = schedule.IndexOf(lesson);
//            int secondLessonIndex = schedule.IndexOf(secondLesson);
//            int firstLessonCount = 0;
//            int secondLessonCount = 0;

//            foreach (string element in schedule)
//            {
//                if (element.Contains(lesson))
//                {
//                    firstLessonCount++;
//                }
//                else if (element.Contains(secondLesson))
//                {
//                    secondLessonCount++;
//                }
//            }

//            if (firstLessonCount == 1 && secondLessonCount == 1)
//            {
//                string temp = schedule[firstLesonIndex];
//                schedule[firstLesonIndex] = schedule[secondLessonIndex];
//                schedule[secondLessonIndex] = temp;
//            }
//            else if (firstLessonCount == 2 && secondLessonCount == 1)
//            {
//                int firstExerciseIndex = firstLesonIndex + 1;

//                schedule[firstLesonIndex] = secondLesson;
//                schedule[secondLessonIndex] = lesson;
//                schedule.Insert(secondLessonIndex + 1, schedule[firstExerciseIndex]);

//                if (firstLesonIndex < secondLessonIndex)
//                {
//                    schedule.RemoveAt(firstExerciseIndex);
//                }
//                else
//                {
//                    schedule.RemoveAt(firstExerciseIndex + 1);
//                }

//            }
//            else if (firstLessonCount == 1 && secondLessonCount == 2)
//            {
//                int secondExcerciseIndex = secondLessonIndex + 1;

//                schedule[secondLessonIndex] = lesson;
//                schedule[firstLesonIndex] = secondLesson;
//                schedule.Insert(firstLesonIndex + 1, schedule[secondLessonIndex + 1]);

//                if (secondLessonIndex > firstLesonIndex)
//                {
//                    schedule.RemoveAt(secondExcerciseIndex + 1);
//                }
//                else
//                {
//                    schedule.RemoveAt(secondExcerciseIndex);
//                }
//            }
//            else
//            {
//                string temp = schedule[firstLesonIndex];
//                string temp2 = schedule[firstLesonIndex + 1];
//                schedule[firstLesonIndex] = schedule[secondLessonIndex];
//                schedule[firstLesonIndex + 1] = schedule[secondLessonIndex + 1];
//                schedule[secondLessonIndex] = temp;
//                schedule[secondLessonIndex + 1] = temp2;
//            }
//        }
//    }
//    else if (command == "Exercise")
//    {
//        string ex = lesson + "-Exercise";

//        if (schedule.Contains(lesson))
//        {
//            if (!schedule.Contains(ex))
//            {
//                int index = schedule.IndexOf(lesson);
//                schedule.Insert(index + 1, ex);
//            }
//        }
//        else
//        {

//            schedule.Add(lesson);
//            schedule.Add(ex);
//        }
//    }
//}

//for (int i = 0; i < schedule.Count; i++)
//{
//    Console.WriteLine($"{i + 1}.{schedule[i]}");
//}
////3
//List<string> schedule = Console.ReadLine()
//    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
//    .ToList();

//string input;


//while ((input = Console.ReadLine()) != "course start")
//{
//    string[] commands = input
//        .Split(":", StringSplitOptions.RemoveEmptyEntries);
//    string command = commands[0];

//    string lesson = commands[1];
//    string excerciseLesson = lesson + "-Exercise";

//    int indexLesson = schedule.IndexOf(lesson);
//    int indexExerciseLesson = schedule.IndexOf(excerciseLesson);

//    if (command == "Add")
//    {
//        if (!schedule.Contains(lesson))
//        {
//            schedule.Add(lesson);
//        }
//    }
//    else if (command == "Insert")
//    {
//        int index = int.Parse(commands[2]);

//        if (!schedule.Contains(lesson))
//        {
//            schedule.Insert(index, lesson);
//        }
//    }
//    else if (command == "Remove")
//    {
//        if (indexLesson > -1)
//        {
//            schedule.RemoveAt(indexLesson);
//        }
//        if (indexExerciseLesson > -1)
//        {
//            schedule.RemoveAt(indexExerciseLesson - 1);
//        }
//    }
//    else if (command == "Swap")
//    {
//        string secondLesson = commands[2];
//        string exerciseSecondLesson = secondLesson + "-Exercise";

//        int indexSecondLesson = schedule.IndexOf(secondLesson);
//        int indexSecondExerciseLesson = schedule.IndexOf(exerciseSecondLesson);

//        bool isThereFirstExercise = indexExerciseLesson > -1;
//        bool isThereSecondExercise = indexSecondExerciseLesson > -1;

//        if (schedule.Contains(lesson) && schedule.Contains(secondLesson))
//        {
//            schedule[indexLesson] = secondLesson;
//            schedule[indexSecondLesson] = lesson;

//            if (isThereFirstExercise && isThereSecondExercise)
//            {
//                schedule[indexExerciseLesson] = exerciseSecondLesson;
//                schedule[indexSecondExerciseLesson] = excerciseLesson;
//            }
//            else if (isThereFirstExercise && !isThereSecondExercise)
//            {
//                schedule.Insert(indexSecondLesson + 1, excerciseLesson);

//                if (indexLesson < indexSecondLesson)
//                {
//                    schedule.RemoveAt(indexExerciseLesson);
//                }
//                else
//                {
//                    schedule.RemoveAt(indexExerciseLesson + 1);
//                }
//            }
//            else if (!isThereFirstExercise && isThereSecondExercise)
//            {
//                schedule.Insert(indexLesson + 1, exerciseSecondLesson);

//                if (indexSecondLesson < indexLesson)
//                {
//                    schedule.RemoveAt(indexSecondExerciseLesson);
//                }
//                else
//                {
//                    schedule.RemoveAt(indexSecondExerciseLesson + 1);
//                }
//            }
//        }
//    }

//    else if (command == "Exercise")
//    {
//        if (!schedule.Contains(lesson))
//        {
//            schedule.Add(lesson);
//            schedule.Add(excerciseLesson);
//        }
//        else if (!schedule.Contains(excerciseLesson))
//        {
//            schedule.Insert(indexLesson + 1, excerciseLesson);
//        }
//    }
//}

//for (int i = 0; i < schedule.Count; i++)
//{
//    Console.WriteLine($"{i + 1}.{schedule[i]}");
//}

////4
//List<string> schedule = Console.ReadLine()
//    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
//    .ToList();

//string input;

//while ((input = Console.ReadLine()) != "course start")
//{
//    string[] commands = input
//        .Split(":", StringSplitOptions.RemoveEmptyEntries);
//    string command = commands[0];

//    string lesson = commands[1];
//    int lessonIndex = schedule.IndexOf(lesson);

//    if (command == "Add")
//    {
//        if (!schedule.Contains(lesson))
//        {
//            schedule.Add(lesson);
//        }
//    }
//    else if (command == "Insert")
//    {
//        int indexToInsert = int.Parse(commands[2]);

//        if (!schedule.Contains(lesson))
//        {
//            schedule.Insert(indexToInsert, lesson);
//        }
//    }
//    else if (command == "Remove")
//    {
//        if (schedule.Contains(lesson))
//        {
//            if (lessonIndex < schedule.Count - 1 && schedule[lessonIndex + 1] == $"{lesson}-Exercise")
//            {
//                schedule.RemoveRange(lessonIndex, 2);
//            }
//            else
//            {
//                schedule.Remove(lesson);
//            }
//        }
//    }
//    else if (command == "Swap")
//    {
//        string otherLesson = commands[2];

//        if (schedule.Contains(lesson) && schedule.Contains(otherLesson))
//        {
//            int otherLessonIndex = schedule.IndexOf(otherLesson);

//            schedule[lessonIndex] = otherLesson;
//            schedule[otherLessonIndex] = lesson;

//            bool exerciseLesson = lessonIndex + 1 < schedule.Count && schedule[lessonIndex + 1] == $"{lesson}-Exercise";
//            bool exerciseOtherLesson = otherLessonIndex + 1 < schedule.Count && schedule[otherLessonIndex + 1] == $"{otherLesson}-Exercise";

//            int exerciseLessonIndex = lessonIndex + 1; ;
//            int exerciseOtherLessonIndex = otherLessonIndex + 1;

//            if (exerciseLesson && exerciseOtherLesson)
//            {
//                string temp = schedule[exerciseLessonIndex];
//                schedule[exerciseLessonIndex] = schedule[exerciseOtherLessonIndex];
//                schedule[exerciseOtherLessonIndex] = temp;
//            }
//            else if (exerciseLesson && !exerciseOtherLesson)
//            {
//                schedule.Insert(exerciseOtherLessonIndex, schedule[exerciseLessonIndex]);

//                if (exerciseLessonIndex < otherLessonIndex)
//                {
//                    schedule.RemoveAt(exerciseLessonIndex);
//                }
//                else
//                {
//                    schedule.RemoveAt(exerciseLessonIndex + 1);
//                }
//            }
//            else if (!exerciseLesson && exerciseOtherLesson)
//            {
//                schedule.Insert(exerciseLessonIndex, schedule[exerciseOtherLessonIndex]);

//                if (exerciseOtherLessonIndex < lessonIndex)
//                {
//                    schedule.RemoveAt(exerciseOtherLessonIndex);
//                }
//                else
//                {
//                    schedule.RemoveAt(exerciseOtherLessonIndex + 1);
//                }
//            }
//        }
//    }
//    else if (command == "Exercise")
//    {
//        if (!schedule.Contains(lesson))
//        {
//            schedule.Add(lesson);
//            schedule.Add($"{lesson}-Exercise");
//        }
//        else if (lessonIndex == schedule.Count - 1)
//        {
//            schedule.Add($"{lesson}-Exercise");
//        }
//        else if (schedule[lessonIndex + 1] == $"{lesson}-Exercise")
//        {
//            continue;
//        }
//        else
//        {
//            schedule.Insert(lessonIndex + 1, $"{lesson}-Exercise");
//        }
//    }
//}

//for (int i = 0; i < schedule.Count; i++)
//{
//    Console.WriteLine($"{i + 1}.{schedule[i]}");
//}