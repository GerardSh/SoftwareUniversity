# In this folder, you will find solutions to many of the previous exams.
Below are some tips and usefull information about Judge behaviour observed in some exams.

Трябва да внимаваме при избора на namespace когато ползваме атрибути. Например, атрибутът `[Key]` съществува в два namespace-a, но в нашия случай трябва да ползваме `System.ComponentModel.DataAnnotations`.

Когато имаме пропърти с фиксирана дължина на символите, можем да ползваме атрибута `[Column(TypeName = "Char(15)")]`, за да зададем колоната в базата данни като тип Char с точно определен брой символи. Атрибутът `[MaxLength]` има смисъл да се ползва само когато дължината на текста може да варира.

`[Range]` и `[Regex]` атрибутите както и всички останали validation атрибути и атрибути задесериализация се поставят в import DTO обектите, а не на ниво база в ентити моделите.
Когато искаме да валидираме типове с Range атрибута, които са различни от int или double, примерно decimal, трябва да ползваме `[Range(typeof(decimal), "0.01", "500")]`. Ако валидираме тип double, е важно да ползваме стойности като 2.0 вместо 2, примерно - `[Range(2.0, 10.0)]`. В противен случай, при стойност например 1.56, тя може да се закръгли на 2 и да премине успешно валидацията, което не е коректно.

Когато Foreign Key-a е nullable, тогава ползваме `int?` и правим и навигационното пропърти nullable s `?`

За да валидираме Enum стойности в DTO обектите, ако идват като думи, тогава може да ползваме Enum.TryParse(dto.Gender, out Gender gender)
Когато стойностите идват като числа, Enum.TryParse ще ги интерпретира, но ако числото е извън обхвата на дефинираните стойности в енум класа, то все пак ще върне true, което води до невярна проверка.
Затова, освен Enum.TryParse, трябва да добавим и допълнителната проверка с Enum.IsDefined, за да се уверим, че числото съответства на валидна стойност в енум класа - `if (Enum.TryParse(dto.Gender, out Gender gender) && Enum.IsDefined(typeof(Gender), gender))`

Не трябва да забравяме да инициализираме навигационните колекции.

Когато правим import, трябва да следваме три последнователни стъпки:

 1. Define DTO structure by the file structure.
 2. Define validation attributes based on the description.
 3. Implement business logic for import.
 
 При export има една стъпка по-малко:
 
 1. Define ExportDTO structure and describe with XmlAnnotation.
 2. Implement business logic for export.
 
Когато сортираме при експорт, винаги е добре да го правим преди проекцията, защото след нея обикновено пропъртитата са стрингове. Но трябва да се внимава, защото има задачи където противно на очакваното, числени стойности трябва да са сортирани като стрингове. Това може да доведе до невъзможност EF Core да преведе заявката към базата данни и тогава трябва да я материализираме в самото начало, като трябва да ползваме eager loading защото lazy loading-a няма да работи и ще хвърля exception-и. 
Другия вариант, ако трябва да сортираме по стринг, вместо да материализираме заявката и да ползваме eager loading е да извършим сортирането преди селекцията и да извикаме .ToString() метода на пропъртитата:

```csharp
ExportHouseholdExpensesDto[] households = context.Households
    .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
    .OrderBy(h => h.ContactPerson)
    .Select(h => new ExportHouseholdExpensesDto()
    {
        ContactPerson = h.ContactPerson,
        Email = h.Email,
        PhoneNumber = h.PhoneNumber,
        Expenses = h.Expenses
        .Where(e => e.PaymentStatus != PaymentStatus.Paid)
		// Ordering is done here, calling the ToString() method
        .OrderBy(e => e.DueDate.ToString())
        .ThenBy(e => e.Amount.ToString()).ToArray()
        .Select(e => new ExportExpenseDto
        {
            ExpenseName = e.ExpenseName,
            Amount = e.Amount.ToString("f2"),
            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
            ServiceName = e.Service.ServiceName
        })
        .ToArray()
    })
    .ToArray();
```

В папката с резултатите, най-лесната проверка е ако селектираме двата файла през Visual Studio и с десен бутон на мишката да изберем "Compare Selected".
## Judge
В задача 2 от C# DB Advanced Retake Exam - 16 Dec 2021 един тест не минава, ако добавим проверка дали подадените стойности за чужди ключове (FK) в import DTO обектите, са валидни първични ключове (PK) в съответните таблици. Тази проверка е правилна, защото предотвратява изключение при невалидни стойности, но понякога Judge не я харесва.