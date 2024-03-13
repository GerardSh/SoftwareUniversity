# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/03%20Regex.md#Methods)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/03%20Regex.md)

[Regex](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/03%20Regex.md)

Последователност от символи, които ни позволяват да открием съвпадения в даден текст. Използват се само и единствено за обработка на текст.
Това което прави регекс-а е да търси съвпадения по определен pattern (шаблон), който се дефинира със специален синтаксис.

`[abxz]` - квадратните скоби дефинират възможно множество в рамките на един символ, в търсения текст. Може да бъде и интервал `[0-9]+`, който се определя по кодовата таблица с която работим. Задаваме символ от който започваме и символ в който свършва интервала, като и двата крайни символа също влизат. Интервалите може и да се групират `[a-co-x]`
Когато имаме `[A-Z][a-z]*` това са интервали за два символа, звездичката означава, че може да имаме много символи от втория интервал.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240303193156.png)

`[^abc]` - с ^ дефинираме множество от символи, които не трябва да се съдържат.
## [Predefined Classes](03%20Regex.md#PredefinedClasses)
Това са шаблони които се ползват много често. Работят само с латинската азбука. Голямата буква е тяхното отрицание. 
## [Quantifiers](03%20Regex.md#Quantifiers)
Стоят след символ и определят колко пъти въпросния символ трябва да се повтаря. Понеже са специални символи, ако искаме да търсим по тях, трябва да се escape-нат с `\`
## [Grouping Constructs](03%20Regex.md#GroupingConstructs)
`(subexpression)` - Capture group - ползват се за две неща:
1. Да се промени приоритета на операциите. Ако имаме | оператор и всички възможности са верни, то взима най-лявата.
2. Позволяват да вземем части от текста и да извършим действия върху тях. Тогава всяка такава група има индекс, който може да използваме за да вземем информацията, която ни трябва.
`(?:subexpression)` Когато искаме да ги ползваме само за приоритет, ползваме non-capturing group.
`(?<name>subexpression)` - Именована capture group, върнатата информация може да я търсим освен по индекс, но и по името което сме сложили.
Всеки `Match` по default има като първа група с индекс 0 целия намерен резултат.
Можем да достъпим стойността на даден capture group по името или индекса - `match.Groups["FirstName"]`

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240303220142.png)

## Backreferences
Позволява ни ако сме extract-нали някаква част от текста, да я използваме по нататък в самия регулярен израз.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240304224131.png)

Мач-ваме второто b по референцията от първото което сме открили в скобите. На мястото на символа, може да е всичко и точно това е идеята, да открием какво има и после да го ползваме обратно напред в expression-a. Най често се ползва с числа `\number`. Ползват се числата от capture групите.
## CSharp
Имаме Regex клас, който може да ползваме. Желателно е като си дефинираме pattern-a да ползваме string verbatim @, за да няма нужда да escape-ваме чарове.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240304225829.png)

Използваме класа `Match` с метода `Match(text)` за вземане на резултата от търсенето, което ще бъде първия намерен резултат. За да получим всички резултати, използваме класа `MatchCollection` с метода `Matches(text)` Намерените резултати, ще бъдат вкарани в масив, където всеки един от елементите ще бъде от типа `Match`

Полезни сайтове:
[RegExr: Learn, Build, & Test RegEx](https://regexr.com/)

[regex101: build, test, and debug regex](https://regex101.com/)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/a/Pasted%20image%2020240303191609.png)

Тук може да изберем кой engine да ползваме, дали вградения в browser-а или на самия сървър.
Флаговете отдясно примерно global, означава че търсим не просто едно съвпадение, а всички съвпадения в текста.
В tools долу в сайта, имаме обяснения какво се случва, като групира нещата в expression-a и елементите в tools по цветове.
В таба List на tools, ще даде всички match-нати елементи.
В менюто имаме characters set с примери, имаме и cheatsheet и много друга полезна информация.

Regex се използва първо за откриване на дадена информация - дали нещо което отговаря на шаблона, съществува в нашия текст. Също може да извадим това което е match-нато в capture група.
Може нещото което е намерено, да бъде заменено, а също може и да split-нем данните
# Misc
Когато работим с regex реално въпроса е колко пъти дадения шаблон, се съдържа в текста където търсим.

Ако искаме да вложим променливи в pattern-а, може да ползваме string interpolation. Aко тази променлива е част от quantifier, се escape-ва с двойни `{{{}}}`,  където вътрешните скоби са част от string interpolation-а, а външните съставят quantifier-a:
```
string symbol = "[A]";
int number = 4;
Match match = Regex.Match("AAAA", @$"{symbol}{{{number}}}");

//The above pattern is the same as:
Match match2 = Regex.Match("AAAA", @"[A]{4}");
```

Най-сигурния начин да намерим дадена дума независимо от какви символи е съставена, само ако е разделена от space-ове или е в началото/края на текста - `(?<=\s|^)[^\s]+(?=\s|$)` 
# ChatGPT
## Capture Groups
`(\d|\d{2})-Dec-1994` here we first check which is true d or d2 and then we check for the other text if its there, but here without the capture group - `\d|\d{2}-Dec-1994` the check is if we have d OR d2-Dec-1994, the whole expression after the or operator

ChatGPT
Yes, you've correctly identified the difference in behavior between the two regular expressions.

In the regular expression `(\d|\d{2})-Dec-1994`, the parentheses create a capturing group, and the alternation (`|`) operator applies to either a single digit (`\d`) or two consecutive digits (`\d{2}`). After that, the rest of the pattern (`-Dec-1994`) must match.

So, the logic is: "Match either a single digit or two consecutive digits, followed by '-Dec-1994'."

In the regular expression `\d|\d{2}-Dec-1994`, the alternation (`|`) applies directly to the whole pattern on both sides of it. This means it's saying: "Match either a single digit (`\d`) or the pattern `\d{2}-Dec-1994`."

So, the logic is: "Match either a single digit or the entire pattern '\d{2}-Dec-1994'."

The placement of the alternation operator affects the grouping and the scope of what is being alternated. This distinction is important for constructing regex patterns that accurately reflect the intended logic and pattern matching criteria.
## Word and non word chars
In regular expressions, a "word character" is typically defined as any alphanumeric character (a-z, A-Z, 0-9) or an underscore (_). A "non-word character" is any character that is not a word character.
# Bookmarks 
[RegExr: Learn, Build, & Test RegEx](https://regexr.com/)
[regex101: build, test, and debug regex](https://regex101.com/)

Course completion: 13.03.2024
