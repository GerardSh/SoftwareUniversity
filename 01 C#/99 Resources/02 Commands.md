# List
Начин да преместим даден елемент, който е уникален в поредицата, без да се притесняваме къде точно го инсъртваме.
```
List<string> list = new List<string>() { "test1", "test2", "test3" };

string temp = list[2];
list.Insert(1, temp + "descriptor");
list.Remove(temp);
list[list.IndexOf(temp + "descriptor")] = temp;

Console.WriteLine(string.Join(" ", list));
```
# Dictionary
Сортираме елементите на речник, въз основа на средните стойности във вътрешния речник:
```
var test = new Dictionary<string, Dictionary<string, int>>()
{
    {"Outer1", new Dictionary<string, int>(){ {"inner1",2 },{"inner2",3}}},
    {"Outer2", new Dictionary<string, int>(){ {"inner1",3}, {"inner2",6}}}
};

// Подреждаме елементите въз основа на средните стойности във вътрешния речник.
var test2 = test.OrderByDescending(x => x.Value.Values.Sum());
```
Събиране на елементи с два вложени речника, както и намирането на сбора на вътрешните елементи с key=a на първия речник:
```
var test = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>()
{
    {"Outer1", new Dictionary<string, Dictionary<string, int>>(){{"Middle", new Dictionary<string, int>(){{"Inner",5},{"inner2",50}}},{"Middle2", new Dictionary<string, int>(){{"Inner", 5},{"inner2", 50}}}}},
    {"Outer2", new Dictionary<string, Dictionary<string, int>>(){{"Middle", new Dictionary<string, int>(){{"Inner",1600}}}}},
    {"Outer3", new Dictionary<string, Dictionary<string, int>>(){{"Middle", new Dictionary<string, int>(){{"Inner",200}}}}}
};

var sumUsingLinq = test.Values.Sum(x=>x.Values.Sum(x=>x.Values.Sum()));
int biggestSum = 0;
int sumAll = 0;
string bestElement = "";

foreach (var outerKvp in test)
{
    int sum = 0;

    foreach (var middleKvp in outerKvp.Value)
    {
        foreach (var innerKvp in middleKvp.Value)
        {
            sumAll += innerKvp.Value;
            sum += innerKvp.Value;

            if (sum > biggestSum)
            {
                biggestSum = sum;     
                bestElement = outerKvp.Key;
            }
        }
    }
}
```
# Stack
`stack = new Stack<int>(stack.Reverse());` - бърз начин да обърнем елементите в стака.
# Queue
`queue = new Queue<int>(queue.Reverse());` - бърз начин да обърнем елементите в кю-то.
# String
Обхождане на даден стринг, докато е нужно, без да излизаме от индекса:
```
string text = "test ";
int index = 0;

for (int j = 0; j < 12; j++)
{
    Console.Write(text[index % text.Length]);
    index++;
}
```
# Misc
`Console.WriteLine((50 % 60 < 10 ? "0" : "1"));` - Проверява дали нещо е изпълнено и връща резултат.