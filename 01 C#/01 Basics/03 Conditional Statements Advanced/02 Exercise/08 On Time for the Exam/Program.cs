int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());
//int examHour = 1;
//int examMinute = 1;
//int arrivalHour =2;
//int arrivalMinute = 1;

int examMinutes = examHour * 60 + examMinute;
int arrivalMinutes = arrivalHour * 60 + arrivalMinute;
int timeDifference = examMinutes - arrivalMinutes;

if (timeDifference < 0)
{
    timeDifference = Math.Abs(timeDifference);
    Console.WriteLine("Late");
    if (timeDifference <= 59)
        Console.WriteLine($"{timeDifference} minutes after the start");
    else
    {
        Console.WriteLine($"{timeDifference / 60}:" + (timeDifference % 60 < 10 ? "0" : "") + $"{timeDifference % 60} hours after the start");
    }
}
else if (timeDifference == 0)
{
    Console.WriteLine("On time");
}
else if (timeDifference > 0 && timeDifference <= 30)
{
    Console.WriteLine("On time");
    Console.WriteLine($"{timeDifference} minutes before the start");
}
else if (timeDifference > 30)
{
    Console.WriteLine("Early");
    if (timeDifference >= 60)
    {
        int hours = timeDifference / 60;
        int minutes = timeDifference % 60;

        Console.WriteLine($"{hours}" + (minutes < 10 ? ":0" : ":") + $"{minutes} hours before the start");
    }
    else
    {
        Console.WriteLine($"{timeDifference} minutes before the start");
    }
}




//2
int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());
//int examHour = 0;
//int examMinute = 00;
//int arrivalHour = 1;
//int arrivalMinute = 01;

int examInMinutes = examHour * 60 + examMinute;
int arrivalInMinutes = arrivalHour * 60 + arrivalMinute;
int diff = (examInMinutes - arrivalInMinutes);

string verdict = "";
string beforeAfter = "";
if (diff < 0)
{
    verdict = "Late";
    beforeAfter = "after";
}
else
{
    beforeAfter = "before";
    if (diff <= 30)
        verdict = "On time";
    else
        verdict = "Early";
}
int absoluteDiff = Math.Abs(diff);
int diffInHours = absoluteDiff / 60;
int diffInMinutes = absoluteDiff % 60;

string hoursOrMinutes = "";
if (diffInHours < 1)
{
    hoursOrMinutes = $"{diffInMinutes} minutes";
}
else
{

    hoursOrMinutes = $"{diffInHours}:{diffInMinutes:d2} hours";
}

//Output
Console.WriteLine(verdict);
if (diff != 0)
{

    Console.WriteLine($"{hoursOrMinutes} {beforeAfter} the start");

}

Third variant

int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());

int diff = examHour * 60 + examMinute - (arrivalHour * 60 + arrivalMinute);
string arrivalStatus = "";

if (diff < 0)
{
    arrivalStatus = "Late";
}
else if (diff <= 30)
{
    arrivalStatus = "On time";
}
else
{
    arrivalStatus = "Early";
}

int diffHours = Math.Abs(diff / 60);
int diffMinutes = Math.Abs(diff % 60);

{
    Console.WriteLine(arrivalStatus);
    if (diff != 0)
    {
        if (diffHours < 1)
        {
            Console.WriteLine($"{diffMinutes} minutes {(arrivalStatus == "Late" ? "after" : "before")} the start");
        }
        else
        {
            Console.WriteLine($"{diffHours}:{diffMinutes:d2} hours {(arrivalStatus == "Late" ? "after" : "before")} the start");
        }
    }
}




//3
int examHour = int.Parse(Console.ReadLine());
int examMinute = int.Parse(Console.ReadLine());
int arrivalHour = int.Parse(Console.ReadLine());
int arrivalMinute = int.Parse(Console.ReadLine());

int diff = examHour * 60 + examMinute - (arrivalHour * 60 + arrivalMinute);
string arrivalStatus = "";

if (diff < 0)
{
    arrivalStatus = "Late";
}
else if (diff <= 30)
{
    arrivalStatus = "On time";
}
else
{
    arrivalStatus = "Early";
}

int diffHours = Math.Abs(diff / 60);
int diffMinutes = Math.Abs(diff % 60);

{
    Console.WriteLine(arrivalStatus);
    if (diff != 0)
    {
        if (diffHours < 1)
        {
            Console.WriteLine($"{diffMinutes} minutes {(arrivalStatus == "Late" ? "after" : "before")} the start");
        }
        else
        {
            Console.WriteLine($"{diffHours}:{diffMinutes:d2} hours {(arrivalStatus == "Late" ? "after" : "before")} the start");
        }

    }
}