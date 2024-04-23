# General
[Methods](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/01%20Methods.md#Stream)

[Commands](https://github.com/GerardSh/SoftwareUniversity/blob/main/01%20C%23/99%20Resources/02%20Commands.md#Stream)

Потоците, файловете и директориите, са важни защото повечето програми, боравят и записват дългосрочно, някаква информация. Това е така, защото почти няма програма, която да работи само с паметта на компютъра и да не се налага да записва нищо.
Най-добрата опция да запишем нещо за постоянно, са файловете.

Един char в C# заема 2 байта, което е 16 бита. 
Кодовите таблици - encoding-ите казват как байтовете в даден файл, да бъдат интерпретирани като символи.
Когато инициализираме StreamWriter, може в конструктора да добавим кой encoding да се ползва:
`using var output = new StreamWriter("output.txt", false, Encoding.ASCII);`
Кодовата таблица ASCII използва за един символ един байт.
Ако ползваме Unicode като encoding, тогава един символ има 2 байта, като има 2 контролни байта в началото на файла. Затова ако отворим даден файл с различен encoding, ще стане нечетим, защото байтовете са интерпретирани по грешен начин. Без encoding-ите, файловете са масив от байтове, записан върху файловата система.
## Streams
Това е подсистема, начин, концепция, чрез която може да пренасяме информация.
Играе ролята на поток, който има два края, първият е нашата програма а другият може да бъде друг компютър, може да бъде файл, периферно устройство, друга програма и тн. 
Предоставя канал за комуникация, между две неща, като обикновено едно от нещата е нашата програма, но може да бъде и между файл и файл и тн.
Стрийм-а има глава, която се мести по данните, които четем, той винаги знае колко сме прочели и понякога знае, колко ни остава да прочетем. Мести се из данните и може да ги чете и праща от една точка и друга точка, без значение къде се намират точките.
Има стрийм-ове, при които само четем, или само пишем, зависи от контекста дали дадена операция е позволена или не.
Достъпа до информацията е последователен.
За да може да работим, първо трябва да ги отворим и после да се затворят, това е много важно защото може да доведе до загуба на информация. Това е така, защото ако програмата приключи преди да сме затворили стрийм-а, то информацията която се пази в буфера, няма да бъде прехвърлена във файла и ще се изгуби.
Ако работим примерно с файл, ние първо трябва да отворим файла и после да създадем стрийм върху файла.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240417202520.png)

Информацията може да се чете освен от конзолата и от други места, например базовите стриймо-ве са: File Stream, Memory Stream и Network Stream. Всеки един от тези стрийм-ове, ни дава достъп до информация. 

`FileStream` - дава достъп до информацията записана в даден файл. 

`MemoryStream` - е реално масив от байтове, който се държи като истински стрийм, с истинска информация. Заместител на реален източник на информация, ползва се примерно при Unit тестове, или когато искаме да видим поведението на даден код, но без да го записваме във файл, а в паметта на компютъра.

`NetworkStream` - пращане и получаване на информация по мрежата.

На по-високо ниво са декораторите, които ни позволяват да надградим съществуваща функционалност по удобен начин с няколко неща едно върху друго.

`GZipStream` - може да се сложи вид компресия в по-малък брой байтове дадена информация.

`CryptoStream` - да криптираме една информация чрез парола, която най-често е масив от байтове и да се направи информация записана в стрийм-а, нечетима за отсрещната страна.

`BufferedStream` - добавя буфера върху стрийм-а и почти всички стрийм-ове имат буфер.

На по-високо ниво са стрийм-ове, които директно използваме, когато искаме да свършим конкретна работа, примерно да прочетем текстов файл или да пишем в него.
Всички файлове във файловата система, са винаги binary files - единици и нули.

Всеки един клас в C# наследява рано или късно базовия клас Stream. 
`StreamWriter` наследява `TextWriter`, който наследява други класове, водещи до базовия клас. 
За всички стрийм-ове имаме общи неща, които може да ползваме.
Примерно метода `Flush()` всичко което е записано до момента в буфера, се изпраща директно във файла. Ако след всяко писане, ползваме flush, то ще отнеме много повече време, но е удобно за дебъг, защото може да следим резултата поетапно, както на конзолата. За да изключим буфера, може да ползваме пропъртито `sw.AutoFlush = true;`
### Buffer
Междинно съхранение на информация, обикновено част от стрийм-а, която събира данни и когато ние или програмата решим, или се препълни буфера, събраната информация се засилва към стрийм-а.
Прави много по-бърза работата с файлове, защото ако трябва за всяка операция да се обръщаме към файловата система, ще е много бавно.
Размера на buffer-а в .NET и Windows е 4096-байта - 2 на 12 степен. 
В buffer-а ние може да направим 1000 операции и после да ги прати на куп всичките, като така пести време от правенето на отделни операции. За сравнение най-бърз е достъпа до регистрите на процесора. Следващото по бързина е достъпа до кеша, който е на 3 нива - L1, L2 и L3. Нямаме достъп до тези нива. На трето място е РАМ паметта, където имаме почти пряк достъп. На четвърто място 
Всяко ниво надолу, става 100 и повече пъти по-бавно.
Кеша на процесора спрямо РАМ паметта е хиляди пъти по-бърз, която пък е стотици хиляди пъти по-бърза спрямо писането във файлове.
### Readers and Writers

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240417205418.png)

Това са специални класове, които ни помагат да пишем или да четем информация. Чрез тях преобразуваме битовете в текст.

Има два вида стрийм-а - текстови, които интерпретират всичко, което четем и пишем като чар-ове. 

При `StreamReader`-a информацията идва от файл и се записва във файл при `StreamWriter`-a.

Начина по който интерпретираме байтовете в текст, се нарича encoding. Важно е какъв encoding ще изберем при писането и четенето на файла. В C# се използва Unicode кодовата таблица, за символни низове, където един символ се записва като 2 байта информация.

Втория вид стрийм са binary - при тях няма редове, няма такава концепция, всичко е една голяма поредица от байтове.

Има два варианта да разберем, дали сме свършили с четенето от даден файл.
1. Когато нямаме какво повече да четем, програмата връща null.
```
        while ((line = sr.ReadLine()) != null)
        {

        }
```
2. Да въртим цикъл, докато не стигнем края на стрийм-а.
```
        while (!sr.EndOfStream)
        {

        }
```
### FileStream

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240419132334.png)

Когато отваряме даден файл, трябва да посочим mode.
При четенето на binary files трябва да контролираме къде ще отидат данните и да направим буфер - масив от байтове, който да запише това, което е прочетено от файла. Реално като отворим даден файл с FileStream, виждамe истинското му съдържание директно в байтове. От encoding-a, който ползва даден текстови файл, зависи колко байта ще има, защото различните encoding-и, ползват различен брой байтове да представляват един символ.

```
using var fileReader = new FileStream("output.txt", FileMode);
byte[] buffer = new byte[100];
fileReader.Read(buffer, 0, 10);
```
Можем да обърнем даден стринг в масив от байтове с код:
```
string text = "test";
byte[] bytes = Encoding.UTF8.GetBytes(text);
```
Взимаме байтовете на даден стринг в посочения encoding.

Може да зададем и optional parameters като създаваме стрийм-а - `FileAccess.Read` ще може само да четем. Това се пази и като булево property на класа `CanWrite`.
Също може пак като optional параметър да зададем как споделяме този файл, с останалите програми, примерно `FileShare.None`. Операционната система се грижи за това да се знае кой е отворил файла, кой друг може да го отваря, кой иска достъп и тн.
Писането е обратно на четенето - имаме байт масив с данни, който ползваме за да ги запишем във файл. Отново полазваме FileStream - като трябва да посочим output file-а. 

Когато създадем FileStream и посочим даден файл, то ако файлът съществува, всичките му байтове се зареждат в обекта, който сме създали. Съответно ако влезнем в обекта в дебъг, ще видим че имаме информация колко байта са заредени, на каква позиция е главата която чете данните към дадения момент и тн. Имайки тази информация, ние може да вкараме байтовете в buffer char масив чрез метода Read(). В него може да заредим всички байтове от файла или като допълнителна възможност, да посочим от кой индекс да започне да пише в buffer масива и колко байта да прочете:

```
fileReader.Read(buffer, 2, 5);  // ще запише 5 байта от наличните в FileStream-a, като ще почне да ги записва от втория елемент в чар масива buffer.

fileReader.Read(buffer); // ще запише всички налични байтове в buffer масива. Ако размера на масива е по-малък от наличните байтове във fileReader-a, то ще бъде запълнен целия масив и позицията на глава ще индикира до къде е стигнала. Ако направим втори масив с достатъчен размер, ще може да вкараме всички останли байтове, започвайки от позицията на главата.
```

Може да ползваме метода Seek() чрез който да манипулираме позицията на главата.

Записваме върху даден файл, чрез метода Write(). Там трябва да посочим масива от който взимаме байтовете и като опция да изберем стартовия индекс и колко байта искаме да запишем.

За всеки файл с който работим, трябва да имаме отделен FileStream.

Работата с FileStream е същата като с StreamReader/Writer с разликата, че буфера трябва да си го направим сами. Преди да може да ползваме данните от файла, трябва да ги вкараме в буфера.

Ако ползваме `FileMode.Append` - тогава ако пишем във файла и той съществува, главата винаги е разположена в края му и всичко което пишем, се записва накрая. Ако не съществува, бива създаден нов файл. Създаване на stream в този режим, не позволява използването на Seek() метода.

Когато ползваме FileStream за да запишем байтовете в даден файл, използваме байт буфер, от който ги четем. Тези байтове не се записват веднага във файла на хард диска, защото е бавна информация, но отново се буферират скрито в паметта и по някое време се пращат към файла. Ако искаме веднага да се запишат във файла, след прочитането им от байт буфера, трябва да извикаме flush() метода.
## bin & obj folders
След като напишем source code-a в текстови файл, кода минава процес наречен компилация в който се създават изпълнимите файлове, които са двоични. 
Нашия проект, има два файла - `Program.cs` - source code и `.csproj` - проектен файл, съдържащ мета информация - framework версията и др. 
Когато стартираме проекта, той минава през процеса наречен компилация и се създава изпълним код, който процесора разбира. Създават се двете папки `bin` и `obj`, където в `obj` има служебна информация с временни файлове, които не ни вършат работа. В `bin` се намира резултат от компилацията на програмата, `exe` което е изпълнимият файл и `dll` където е нашия код. Тези два файла заедно представляват конзолното приложение. Другите файлове са служебни - `pdb` е с цел debugging, свързва изпълнимия файл с оригиналния код, с цел да може да видим пълната информация, ако има exception, на кой ред е бил.
### Relative path
Това е път, който не е пълен. Тоест, ако създадем текстови файл, без да зададем пътя до директорията и папката където искаме да бъде, а само името на файл-а, той ще се създаде в bin папката, към която води relative path-a. 
За да проверим пълния път, може в source code-a да го проверим с `Console.WriteLine(Environment.CurrentDirectory);`
Когато ползваме Relative path и искаме да запишем файла в предишна директория, може от ляво на името на файл-а, да сложим `..\` което ще го създаде в предишната директория.
Реално relative path-а е стартовата позиция на работната директория, от която навигираме между директориите, когато търсим файлове. Тази позиция обикновено започва от директорията където са `exe` и `dll` файловете. 
В Solution Explorer view-то във VS виждаме файловете, които са в папката със сорс кода на програмата. Ако искаме някой от тези файлове, да се копират в работната директория за програмата, трябва да цъкнем десен бутон върху файла - properties - Copy to Output Directory - Copy always. Това е удобно, защото няма да има нужда да търсим тези файлове спрямо работната директория, а файловете ще се копират директно там.
## Using Statement

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240418155549.png)

Когато ползваме външен ресурс, нещо което е външно за нашата програма, като текстови файл, когато приключим да го ползваме, трябва да го освободим. Освобождаването навсякъде се нарича `Dispose`. Dispose е универсалното име, за освобождаване на външен ресурс. Всички ресурси, които подлежат на освобождаване, имат метода `Dispose()`.
Когато искаме по лесен начин да уточним какъв ресурс ще ползваме, в какъв scope - редовете код и после програмата автоматично да го изчисти чрез Dispose метода, ползваме конструкцията using. Конструкцията много прилича на if конструкциите. От няколко версии насам в C# е позволено да се ползва using без скобите.
```
using StreamReader sr = new StreamReader(@"temp\01. Odd Lines\Input.txt");
using StreamWriter sw = new StreamWriter(@"temp\output.txt");
```
# Misc
Когато ползваме `StreamReader` е добре да го затваряме като свършим четенето, за да освободим файла. Когато една програма като захапе даден файл, не го освобождава, докато не затворим stream-a.

`StreamReader`-a е еквивалент на `Console.ReadLine()`, с разликата че чете от текстови файл, а не от конзолата. 
Когато `StreamReader`-a попадне на символа за нов текст `\n` или `\r\n`, във текстовия файл, спира да чете. 
`Console.ReadLine()` спира четенето при натискане на Enter или в края на първия ред, ако paste-нем текст на няколко реда, копиран от текстови файл.

`StreamWriter`-a е еквивалент на `Console.WriteLine()`,  като текста бива изписан във текстови файл, по същия начин, както би се показал на конзолата, ако ползваме `Console.WriteLine()`.

Можем да пренасочим текста изписва на конзолата с `Console.WriteLine()` да отива към външен файл, с командата:
```
using var output = new StreamWriter("console.txt");
Console.SetOut(output);
```
Друг начин за пренасочване е ако стартираме през конзолата приложението и напишем `> out.txt`, към който да изпратим текста.
A може да пренасочим и входа `out.txt`.
Също може изхода на едната програма да отиде като вход към друга програма, това се нарича pipe.

Linux се ползва често като хранилище за web приложения.

Ако запишем даден файл като .bin и го отворим с Visual Studio, ще видим байтовете му като HEX стойности.

JIT - just in time е когато компилираме C# кода до междинен език IL и този език се дава в някаквa система за да се преобразува в машинен код MC. Трябва да има .NET

AOT - ahead of time - когато се вземе кода на C#, мине се през IL междинен език, директно се направи на машинен код MC и тогава се подава към друга система. Няма нужда от .NET. Пример за използване са мобилните приложения за андроид и iOS.

Path.Combine - може да се ползва, когато имаме два пътя, един от тях релативен и се комбинират за да станат цял адрес.

Във всеки файл има headers, които дават команда на програмата как да го стартира. 
# ChatGPT
## Escaping chars in text
When we use methods like `SreamReader.ReadLine()` from a text its basically reading the text until it finds `\n` or `\r\n`?

ChatGPT
Yes, that's correct. When you use methods like `StreamReader.ReadLine()` to read lines from a text file, the method reads characters from the file until it encounters a newline character (`\n`), a carriage return character followed by a newline character (`\r\n`), or reaches the end of the file.

The exact behavior may vary slightly depending on the platform and the text file's encoding. For example, on Windows systems, text files typically use `\r\n` as the line ending convention, so `ReadLine()` would stop reading characters when it encounters `\r\n`. On Unix-like systems, where `\n` is commonly used as the line ending, `ReadLine()` would stop at `\n`. However, many modern text-processing libraries and tools are capable of handling different line-ending conventions transparently.

So when we press enter in a text file, it adds the `\r\n` at the end of the line

ChatGPT
When you press the "Enter" or "Return" key in a text file on a Windows system, the operating system typically inserts the `\r\n` sequence to denote the end of the line. This convention stems from historical reasons, as early computer systems and typewriters used a carriage return (`\r`) followed by a line feed (`\n`) to move the cursor to the beginning of the next line.

On Unix-like systems (such as Linux and macOS), pressing "Enter" typically inserts only `\n` as the line ending, omitting the carriage return.

It's important to note that different operating systems have different conventions for representing line endings, and text files created on one system may not display properly on another if the line endings are not properly converted. This is why text-processing tools and libraries often handle line-ending conversions automatically to ensure cross-platform compatibility.
## FileStream
Working with FileStream is the same as with StreamReader/Writer except that we have to create the buffer ourselves. Before we can use the data from the file, we have to put it into the buffer.

ChatGPT
Yes, this is a correct statement in C#. When working with FileStream in C#, you need to create your own buffer to read from or write to the file. This is different from StreamReader and StreamWriter, which already have built-in buffers that automatically manage the data streams. Managing the buffer manually in FileStream gives you more control over file operations, but it requires more code and attention to detail.
## Seek method
We have the seek method for FileStream does it work with StreamWriter/Reader?

ChatGPT
No, the `Seek` method is specific to the `FileStream` class and is not available in `StreamReader` or `StreamWriter`.

The `Seek` method in `FileStream` allows you to move the position within the file stream, enabling random access to different parts of the file. This is useful for tasks such as reading or writing data at specific locations within the file.

`StreamReader` and `StreamWriter`, on the other hand, are designed for sequential access to text data in files, and they do not provide a `Seek` method because they operate on a higher level of abstraction and are optimized for sequential reading and writing. If you need to perform random access operations on a file, you would typically use `FileStream` along with binary reading or writing methods, rather than `StreamReader` or `StreamWriter`.

So they are just one direction?

ChatGPT
Yes, that's correct. `StreamReader` and `StreamWriter` are optimized for sequential reading and writing, respectively, and they operate in one direction.

- `StreamReader` reads text sequentially from a file or stream, moving forward from the beginning to the end of the file.
- `StreamWriter` writes text sequentially to a file or stream, appending to the end of the file.

They are efficient for tasks where you need to process text data line by line or character by character in a sequential manner. If you need to perform operations such as random access or seek within the file, you would typically use `FileStream` along with binary reading or writing methods.
## File Mode Append
In C#, `FileMode.Append` is an enumeration value that you can pass as an argument when opening or creating a file using the `FileStream` class.

When you open or create a file with `FileMode.Append`, the file pointer is positioned at the end of the file. Any data you write to the file will be appended to the existing content, ensuring that the original content remains intact, and new data is added at the end.

Here's a basic example of how you might use `FileMode.Append` with `FileStream`:

If the file already exists, the new data will be appended to the end of the file. If the file does not exist, it will be created, and the new data will be written to it.

It's important to note that `FileMode.Append` does not allow you to seek to arbitrary positions within the file; it always writes data to the end. If you need to perform random access or seek operations, you would typically use `FileMode.Open` or `FileMode.Create` with `FileStream`, along with the appropriate seeking operations.
# Bookmarks 
[Представяне на текст в компютрите (eee.bg) - YouTube](https://www.youtube.com/watch?v=KklC0gqhBk8&t=3s) - Бонус видео, Николай Костов
[Как успешно да преминем интервю за работа в IT сектора (2012) - YouTube](https://www.youtube.com/watch?v=NLoQJamzL8M) - Николай Костов

Course completion: 22.04.2024
