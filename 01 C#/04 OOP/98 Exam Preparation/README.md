# In this folder, you will find solutions to many of the previous exams.
Below are some tips and usefull information about Judge behaviour observed in some exams.
## 01-02 Structure and Business Logic
- Не трябва да има публични сетъри, освен ако не се изисква от интерфейса. Това е една от най-честите причини, на първа задача да дава грешка. Ако на наследяващ клас му трябва достъп до сетъра, се дава protected access modifier вместо private.
- Винаги трябва да се проверяват параметрите в конструктора, че са в правилния ред, според както се иска в задачата, за да не става объркване после.
- Трябва да се хвърлят точните Exceptions с правилните съобщения.
- Всички колекции, трябва да се инициализират.
- Трябва да се внимава със сетерите когато имат някаква проверка и корекция, да не даваме стойност директно на полетата в даден метод, но винаги да минава валидацията на сетъра.

## 03 Unit Tests
- Трябва да проверяваме дали дадена колекция е с правилния count, когато добавяме и махаме елементи. Добре е да се провери и при добавяне и махане дали count-та се е променил.
- Понякога на Judge не му харесва, ако позлваме string interpolation в assert-a:

```
Assert.That(result, Is.EqualTo($"{planet2.Name} is destructed!"));

Когато се сравяват стойностите, по добре е да са хардокднати:

Assert.That(result, Is.EqualTo("name2 is destructed!"));
 ```
 
- Ако има стойности, които даден метод намалява когато се изпълнява и проверява ако са паднали под определено ниво, за да хвърли грешка или да върне съобщение, добре е да сложим такава стойност, която да не е по-ниска от тази за която метода проверява, защото така пак ще върне съобщението или грешката, но на Judge е имало задачи в които не му харесва и не зачита резултата. Тогава Judge е очаквал съобщението да бъде върнато едва след като стойността е била над очакваната стойност, но е била намалена вътре в самия метод.
 
- Понякога, ако имаме два exception-a един след друг, примерно за "capacity reached" и "element exists in the collection", Judge дава грешка, ако капацитета на колекцията е направен на 1. Трябва да е поне 2, защото според логиката му, ако е само 1 елемент, няма как да се направи проверка дали втори елемент няма да има еднакво име. Принципно не е вярно това и може да се направи, ако проверката за сходство в имената е преди проверката за капацитет, но Judge очаква друго. 