# In this folder, you will find solutions to many of the previous exams.
Below are some tips and usefull information about Judge behaviour observed in some exams.

Трябва да внимаваме при избора на namespace когато ползваме атрибути. Например, атрибутът `[Key]` съществува в два namespace-a, но в нашия случай трябва да ползваме `System.ComponentModel.DataAnnotations`.

Когато имаме пропърти с фиксирана дължина на символите, можем да ползваме атрибута `[Column(TypeName = "Char(15)")]`, за да зададем колоната в базата данни като тип Char с точно определен брой символи. Атрибутът `[MaxLength]` има смисъл да се ползва само когато дължината на текста може да варира.

`[Range]` и `[Regex]` атрибутите както и всички останали validation атрибути и атрибути задесериализация се поставят в import DTO обектите, а не на ниво база в ентити моделите.

Когато искаме да валидираме типове с Range атрибута, които са различни от int или double, примерно decimal, трябва да ползваме `[Range(typeof(decimal), "0.01", "500")]`

Когато Foreign Key-a е nullable, тогава ползваме `int?` и правим и навигационното пропърти nullable s `?`

Не трябва да забравяме да инициализираме навигационните колекции.

Когато правим import трябва да следваме три последнователни стъпки:

 1. Defined DTO structure by the file structure.
 2. Define validation attributes based on the description.
 3. Implement business logic for import.