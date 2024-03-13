# PredefinedClasses
`\w` отговаря на `[a-zA-Z0-9_]`, тоест всички alphanumeric символи. 
`\W` - всичко останало освен този range.
`\s` - всички white spaces(space, tab..)`
`\d` - всички цифри
# Quantifiers
`*` - предният символ може да се повтори 0 или повече пъти.
`+` - предният символ може да се повтори 1 или повече символи.
`?` - предният символ 0 или един път. Води се optional може да го има или да го няма.
`{number}` - колко пъти трябва да мач-не даден символ.  Примерно `\d{6}` ще вземе само 6 цифри.
`{number, }` - ще match-не от посоченото число до безкрай.
`{number, secondNumber}` - ще match-не в посочения интервал.
`.` - match-ва всички символи.
`?` - Lazy. Слага се след останалите quantifiers и match-ва възможно най-малко символи, необходими, за да match-не pattern-а. Примерно ако имаме pattern `.*\d+` и текст `abc123` ще match-не всичко до последната тройка и ще остави минимума (последната цифра 3) на следващата част от pattern-а, която в случая е `\d`, това поведение се нарича greedy. Създава проблем, ако сме сложили `\d` в capture група и искаме да вземем всички цифри. Ако сложим lazy quantifier, ще решим проблема ``.*?\d+``. Така ще match-не само толкова символи, колкото е нужно докато стигне до следващата част от pattern-a и ще остави тя да match-не остатъка. Ако след `?` няма други символи в pattern-на, тогава ще match-не, само един символ а не целия текст.
# Anchors
`^` - символ който има специално значение, само ако се сложи в началото на regex-а. Означава че преди търсения текст, не трябва да има нищо друго.
`$` - същото като `^` само че за края на regex-a. Връща резултат, само ако няма никакъв друг текст след края на шаблона по който търсим.
`\b` - отляво и отдясно, символите трябва да са word и non word, ползва се когато искаме да хванем думи или символи, които нямат преди или след тях други word символи.
```
- Before the first `\b`, there should be a position where the preceding character is a non-word character or the start of the string.
- After the second `\b`, there should be a position where the following character is a non-word character or the end of the string.
```
# GroupingConstructs
`(subexpression)` - Capture group.
`(?<name>subexpression)` - Named capture group.
`(?:subexpression)` - non-capturing group.
# Lookaround
`test(?=[0-9])` - Positive lookahead, ще match-не test само ако след него има поне една цифра.
`test(?![0-9])` - Negative lookahead, ще match-не test само ако след него няма цифри.
`(?<![0-9])test` - Negative lookbehind, ще match-не test само ако преди това няма цифри.
`(?<=[0-9])test` - Positive lookbehind, ще match-не test само ако преди това има поне една цифра.
# Methods
Всичките методи ги имаме към инстанция и като статични в класа. Разликата е че ако ползваме статичните методи, трябва да добавяме като параметър pattern-a. Когато работим с един и същи pattern, по-добре да си направим инстанция, в противен случай, по-удобно ще е да ползваме статичния еквивалент.

`IsMatch(text)` - проверява дали имаме мач в даден текст, връща bool.

`Match(text)` - намираме първото съвпадение и го вкарваме в променлива от тип Match.

`Matches(text)` - вкарва всички съвпадения в `MatchCollection`, който е масив.

`Replace(text, replacment)` - връща текста с направените промени.

`Split(text, pattern)` - split-ва даден текст по зададения шаблон и връща масив. В pattern-а не трябва да има capture groups защото те развалят сплита.
# Properties
`Success` - връща bool при успешно намиране на match.