# General
## CSS Basic Box Model
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240830232247.png)

HTML се състои от тагове, а таговете са елементи. Всеки един елемент е тип правоъгълник и има размери, затова се нарича box модел. Browser-a взимайки съдържанието на HTML и стиловете в CSS, трябва да прецени: 

Колко е голяма кутийката.
Разстоянието между съдържанието и border-a.
Разстоянието от border-a до останалите кутийки, къде се намира, колко е голямо и тн. 

Всичко опира до това - колко са ни големи елементите, къде се намират и афектират останалите елементи.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831125925.png)

Margin: разстоянието отвън на кутийката.
This is the space outside the border of the element, creating distance between the element and other elements around it.

Border - разделя външната и вътрешната част на кутийката.
This surrounds the padding and content of the element, providing a line or edge that separates the content from the outside margin.

Padding - вътрешното разстояние между border-a и съдържанието.
This is the space inside the border, between the border and the content of the element. It provides spacing within the element to ensure that the content does not touch the border.

Element content - съдържанието.
This is the actual content inside the element, such as text, images, or other elements.
### Display
Това е много важно пропърти, което дефинира как ще се държи елемента, дали е Inline или block element. Най-общо - блоковете елементи са нещо като големи контейнери, докато инлайн елементите може да бъдат част от текст. Може да имаме много инлайн елементи един до друг и все едно са част от текста.

`display: block;` eлементът се държи като блоков елемент. Това означава, че заема цялата ширина на родителския контейнер и всеки следващ елемент ще се показва на нов ред. Автоматично създават нов ред преди и след тях и заемат цялото пространство по хоризонтала, което могат да заемат. Примери за блокови елементи са `<div>, <h1>, <p>`.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831144234.png)

`display: inline;` eлементът се държи като инлайн елемент. Това означава, че заема само толкова ширина, колкото е необходима на съдържанието му, и не започва на нов ред. Ако един елемент може да бъде част от текста, то най-вероятно е инлайн. Примери за инлайн елементи са `<span>, <a>, <strong>, <img>`.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831145100.png)

`span` и `div` са без семантична стойност и са еквивалентни, но първия е инлайн а втория блоков елемент. Ползват се, ако искаме да направим структура от елементи, които да стилизираме. Може да правим, колкото искаме от тях. 

**`span`**: Може да се зададат `padding`, `margin`, `top` и `bottom`, но не винаги ще бъде видимо как влияят на layout-а, тъй като inline елементите не формират нов ред в документа.
**`div`**: Може да се използва за структуриране на страница и прилагане на `padding`, `margin`, `top`, `bottom`, което може да повлияе на разположението на други елементи.

В примера долу се вижда много ясно разликата в държанието на блоков и инлайн елемент:

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        p {
            border: 1px solid brown;
            text-align: right;
        }
        
        span {
            border: 1px solid brown;
            text-align: right;
        }
    </style>
</head>
<body>
    <p>test</p>
    <span>test</span>
</body>
</html>
```

Размера на span-а в случая, винаги зависи от текста вътре в него, така че подравняването в дясно няма да има никакъв ефект. 
Чрез пропъртито display, може да променяме как се държи един елемент. Може да кажем на span `display: block;` и той ще почне да се държи като блоков елемент - ще заеме цялото свободно място по хоризонтала и ще добави един ред от горе и отдолу:

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        p {
            border: 1px solid brown;
            text-align: right;
        }
        
        span {
            border: 1px solid brown;
            text-align: right;
            display: block;
        }
    </style>
</head>
<body>
    test<span>test</span>test
</body>
</html>
```

Ако сложим padding на инлайн елемент, то единственото изместване на layout-a се случва по хоризонтала, защото инлайн елементите се занимават основно с текст и ги интересува хоризонталата. Ако инлайн елемента има background то той ще закрие горната част над span елемента, но не и долната:

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        p {
            border: 1px solid brown;
        }
        
        span {
            border: 1px solid brown;
            padding: 10px;
            background-color: aqua;       
        }
    </style>
</head>
<body>
    <p>
       Lorem ipsum dolor sit amet consectetur, adipisicing elit. Officia, optio ratione a ad vitae, dolorum amet quam magnam enim consequatur inventore 
       Lorem ipsum dolor sit amet consectetur adipisicing elit. <span>Lorem ipsum dolor sit</span> quia nulla voluptatem eos. Libero, earum temporibus. 
       Lorem ipsum dolor sit amet consectetur, adipisicing elit. Non, accusamus ipsa. Dolorem asperiores sed neque voluptas. Temporibus officia mollitia
</p>
</body>
</html>
```

Ако при span selector-a добавим `display: inline-block;` получаваме нещо, което е по средата между двата свята. Елемента става инлайн, но казваме да браузъра да вземе предвид и padding-а, който сме сложили и така може да направим блокче, само че вътре в текста.
### Display - inline-block
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831150936.png)

Дава ни възможност да сложим няколко елемента един до друг.
Позволява ни да дадем padding, margin, top и bottom на инлайн елементи.
### Width
Property с което може да зададем каква да е ширината на даден елемент.
Основните мерни единици са `pixels`, `em` и `rem`. Ако не декларираме width, по подразбиране заема цялата ширина. Ако искаме даден елемент да порасне в определени граници, може да ползваме `min-width` и `max-width`.
### Height
Това се ползва много рядко. Обикновено примерно слагаме текст, който се разпъва по width, колкото може и след това расте надолу на нов ред. Ние дефинираме размера по широчина, а количеството съдържание определя височината. По подразбиране height имат стойност auto -  ще расте заедно със съдържанието.
Отново имаме `min-height` и `max-height`.
### Margins and Paddings
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831180111.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831180652.png)

Shorthand - в CSS, имаме синтаксис, който позволява задаването на стойностите на няколко пропъртита с една декларация. Вместо да ги изреждаме:

```
margin-top: 20px; 
margin-right: 20px;
margin-bottom: 20px;
margin-left: 20px;
```

може да напишем shorthand нотация с четири стойности:

```
margin: 20px 20px 20px 20px;
```

Така слагаме стойностите и на четирите пропъртита, като се върви по часовниковата стрелка - top - right - bottom - left. Може да сложим само `margin: 20px;` и това ще е размерът и за четирите пропъртита. Ако сложим две стойности - `margin: 20px 20px;` първата ще отговаря за горе и отдолу а втората за ляво и дясно.

В CSS, когато имаме възможност да зададем повече от една стойност в една декларация, това обикновено е shorthand за група свойства, които имат обща част в името си.

**`margin` shorthand**:
- Обща част от името: `margin`.
- Свойства: `margin-top`, `margin-right`, `margin-bottom`, `margin-left`.
- Shorthand: `margin: 10px 20px 15px 5px;`

**`padding` shorthand**:
- Обща част от името: `padding`.
- Свойства: `padding-top`, `padding-right`, `padding-bottom`, `padding-left`.
- Shorthand: `padding: 10px 20px;`

**`border` shorthand**:
- Обща част от името: `border`.
- Свойства: `border-width`, `border-style`, `border-color`.
- Shorthand: `border: 1px solid black;`
### Border
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831213848.png)

Чрез това пропърти се настройва border-a на елемента.

`border: 10px solid #000` - първата стойност е дебелината, втората е стила / вида, а третата е цвета.
Това отново е shorthand, което е равносилно на:

```
border-width: 10px;
border-style: solid;
border-color: #000;
```
### What is the CSS box model?
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831214431.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831214501.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240831214538.png)
### The standard CSS box model
При стандартния CSS box model, който е зададен с `box-sizing: content-box` (това е и стойността по подразбиране), браузърът калкулира ширината и височината на елемента, като включва само размера на съдържанието (`content`). **Padding** и **border** се добавят към тази стойност, което означава, че крайният размер на елемента ще бъде по-голям от зададения размер за `width` и `height`.

- Ако зададем `width: 350px`, това ще бъде само ширината на съдържанието.
- След това се добавят стойностите на `padding` и `border`.

**Крайна ширина на елемента:**

- Content width: 350px
- Padding: 20px отляво + 20px отдясно = 40px
- Border: 5px отляво + 5px отдясно = 10px
- **Обща ширина на елемента**: 350px + 40px + 10px = 400px

Това добавяне на `padding` и `border` към размера на елемента може да доведе до проблеми с общия размер на елементите в оформлението на страницата. За да се избегне това, може да се използва `box-sizing: border-box;`, което включва `padding` и `border` в зададената ширина и височина.
### The alternative CSS box model
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240902095403.png)

Това е предпочитания модел. При него, когато кажем на браузъра, че искаме една кутийка да е 300px, след това независимо какъв padding сложим, кутийката ще остане 300px, но кутийката на content-a, ще се свие. 
Това се постига, чрез пропъртито `box-sizing` по малко по специфичен начин:

```
html {
  box-sizing: border-box;
}

*,
*::before,
*::after {
  box-sizing: inherit;
}
```

Чрез наследяването казваме всички елементи да наследят box-sizing, и така те ще стигнат до най-високото ниво -`<html>` от където ще наследят `box-sizing: border-box;` .  Ако искаме даден елемент да ползва друг box-sizing, може да го overrite-нем и да сложим друга стойност. Всички child елементи, на този елемент, ще ползват overrite-натата стойност. 
## Typography
Изкуството да стилизираме текст - какъв шрифт да изберем, как да се оразмерят и тн. Чрез шрифта, може да се придаде усещане, примерно какво да е настроението на един текст. 
### Styling text
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240902101846.png)

Първото нещо, което трябва да се избере е удобна дължина на реда.

Leading (pronounced "ledding") - следващото важно нещо е разстоянието между два реда текст.

Font Families (also known as typeface) - едно font family, може да има няколко различни шрифта вътре в себе си. Когато казваме шрифт (font), имаме предвид една стилизация на текст. Може да имаме italic от един font, нормалния текст от друг font и като съберем всичките различни стилизации на един шрифт, това е font family. Примерно, когато казвам font Arial, не ползваме само един шрифт, използваме комбинация от шрифтове, които създават font family-то Arial.
#### Generic font families
В CSS са основни категории шрифтове, които групират типове шрифтове с подобни характеристики. Те се използват като резервни опции, в случай че конкретен шрифт не е наличен на системата на потребителя. Ето основните пет категории:
1. **Serif**: Шрифтове с малки линии (серифи) в края на символите. Обикновено се използват за традиционно или официално съдържание.
    - Пример: Times New Roman.
2. **Sans-Serif**: Шрифтове без серифи, което им придава чист и модерен вид.
    - Пример: Arial.
3. **Monospace**: Шрифтове, при които всеки символ заема едно и също количество хоризонтално пространство. Често се използват за програмен код.
    - Пример: Courier New.
4. **Cursive**: Шрифтове, които имитират ръкопис с плавни, свързани букви.
    - Пример: Brush Script.
5. **Fantasy**: Декоративни и често по-игриви шрифтове, които не се вписват в другите категории.
    - Пример: Papyrus.

Как работят generic font families:

Когато се зададе font-family в CSS, браузърът първо проверява дали на компютъра на потребителя е наличен първият избран шрифт. Ако този шрифт не е наличен, браузърът преминава към следващия посочен шрифт в списъка. Ако нито един от конкретните шрифтове не е наличен, браузърът използва generic font family, който е зададен като последна опция.

```
body {
    font-family: Arial, Helvetica, sans-serif;
}
```

В този пример, браузърът първо ще провери дали шрифтът `Arial` е наличен на устройството. Ако не е, ще опита да използва `Helvetica`. Ако и той не е наличен, браузърът ще поиска от операционната система да предостави какъвто и да е шрифт от категорията `sans-serif`, който е наличен на системата.
#### CSS Units - EM & REM
Винаги крайния резултат е в пиксели, независимо през какви други единици минаваме. 

`em` е единица за измерване в CSS, която се базира на текущия размер на шрифта на елемента. Един `em` е равен на текущия размер на шрифта. Например, ако шрифтът на един елемент е зададен на 16px, тогава `1em` ще бъде равен на 16px. Ако зададеш `2em`, това ще бъде равно на 32px. `em` е полезен за създаване на гъвкав дизайн, тъй като се мащабира спрямо базовия размер на шрифта на елемента или неговия родител. С други думи, `em` е единица, която се отнася към размера на шрифта и така може да мислим по-лесно с размерите на текста, вместо да мислим в пиксели.

`rem` (`root em`) винаги взима стойността на font-size на root елемента, който е html. Ако в html тага, няма зададен font-size, се използва този по подразбиране, който е 16 пиксела.
#### Web Fonts
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240902110515.png)

Може да се обърнем към сървъра и да кажем този шрифт да бъде зареден и след това, може да го ползваме в нашия дизайн. Това ще забави сайта ни, защото ако използваме шрифтовете, които са налични на операционната система на потребителя, той няма да има нужда да сваля голям файл с цялата информация за шрифта.
## Position
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240902181953.png)

Понякога имаме нужда да извадим една кутийка от стандартния layout на документа и да я позиционираме, много специфично.
### Position Property
Има различни стойности:
#### Static
Това е стойността по подразбиране за всички елементи. Елемента е разположен на нормална позиция, спрямо layout flow-a. Не реагира на пропъртитата top, bottom, left, right, z-index.
#### Relative
Позволява да преместим елемента, спрямо текущата му позиция. Когато кажем position relative, ние не вадим елемента от останалия flow на документа. Реално преместваме елемента само визуално, но той продължава да си стои на неговото място.
#### Absolute
Вадим елемента от layout-a на останалите елементи и започваме да го позиционираме спрямо първия parent, който има позиция различна от static. Ако няма такъв parent елемент, позиционирането става спрямо body елемента.
#### Fixed
Елемента се позиционира спрямо viewport-a.
#### Z-index
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240902193854.png)

Използва се за да се контролира подредбата на слоевете, ако даден елемент е разположен над друг елемент. Това е все едно добавяме третo измерение на елементите. По-големия индекс се показва най-отгоре, ако има елементи с еднакъв индекс, елемента който се появява по-късно във документа, е отгоре. Може да се слагат и отрицателни стойности, ако искаме да мръднем назад даден елемент. Това работи само на позиционирани елементи - различни от static.
# Misc
## Semantic Tags
Семантичните тагове са важни, само когато ще публикуваме web site, който ще бъде достъпван от търсещи машини и тн. 
Когато правим апликация, не ни трябват, освен че ни помагат да се ориентираме в смисъла на кода, който пишем. Един добре подреден код, става по-лесен за навигация и разбиране. Ако слагаме само divider `<dvi>`  с класове, всичко изглежда еднакво и по-трудно за ориентиране. Добре е винаги да си структурираме семантично кода.
## Inspect
В режим Inspect на браузъра, когато анализираме CSS стилизирането на елементите, различните части от кутията на елемента са визуално обозначени с различни цветове:
- **Content (Съдържание)**: Оцветен в **синьо**. Това е основната област, където се показва текстът или другото съдържание на елемента. Размерът на съдържанието е определен от ширината и височината на елемента, но не включва padding и border.
- **Padding (Подложка)**: Оцветен в **зелено**. Това е пространството между съдържанието на елемента и неговата граница. Padding-а може да бъде зададен с различни стойности (например `padding: 10px;`), което увеличава размера на елемента, без да променя размера на съдържанието.
- **Border (Граница)**: Оцветен в **жълто** (или може да бъде показан в друг цветен код в зависимост от браузъра). Това е линията, която обгражда съдържанието и padding-а на елемента. Границата може да бъде с различна дебелина, стил и цвят.
- **Margin (Отстояние)**: Оцветен в **оранжево**. Това е пространството между елемента и другите съседни елементи или границата на контейнера. Margin-а не влияе на размера на самия елемент, а на разстоянието между него и съседните елементи.
## Inherit
В CSS, някои пропъртита са наследими по подразбиране - което означава, че дъщерните елементи автоматично наследяват стойността му от родителя, освен ако не е зададена друга стойност за конкретния елемент. Други пропъртита не са наследими. Примерно, ако кажем color в `div` елемент да е red и после вкараме `p` в `div` елемента, то пропъртито color на `p`, ще наследи цвета, който идва от `div` елемента. `p`, който е извън `div`, няма да наследи от него а от `body`. `a` елемента, който също е в `div` не наследява автоматично, защото линковете обикновено имат собствен стил, който браузърът задава (например син цвят за ненавиждани линкове и лилав за посетени), затова ако искаме да наследим цвета от родителя, трябва изрично да зададем `color: inherit` на линка.

```
<style>   
    div {
        color:red; /* Всички дъщерни елементи наследяват този цвят, освен ако не се промени */
    }
    
    p {
        /* Не е нужно да добавяме color: inherit, защото p е наследимо */
    }    
    
    a {
        color:inherit; /* Трябва изрично да наследим цвета за <a>, защото то по подразбиране не наследява */
        }       
    </style>
    
</head>
<body>
    <div>
        <p>Този текст ще бъде червен</p>
        <a href="#">Този линк също ще бъде червен</a>
    </div>
    
    <p>Този текст ще бъде с цвета на body (по подразбиране черен)</p>
</body>
```

**Обобщение:**

- Не е нужно да използваме `color: inherit` за да наследими елементи като `<p>`, тъй като те автоматично наследяват цвета на родителя.
- За елементи като `<a>`, които имат свои собствени стилизации по подразбиране, е необходимо да използваме `color: inherit`, ако искаме те да наследяват цвета от родителя.
- Можем да зададем `inherit` на **всяко CSS свойство**. Ако свойството не се наследява автоматично, `inherit` ще го принуди да приеме стойността на родителя.
## Pseudo Elements
**Псевдоелементите** в CSS са елементи, които не съществуват в HTML документа, но могат да бъдат създадени и стилизирани чрез CSS. Те ни позволяват да добавяме и стилизираме допълнително съдържание или части от съществуващи елементи без да се налага да променяме HTML структурата.

**Най-често използвани псевдоелементи:**

1. `::before` – добавя съдържание пред избрания елемент.
2. `::after` – добавя съдържание след избрания елемент.

```
p::before {
  content: "Псевдоелемент: ";
  color: red;
}

p::after {
  content: " - край";
  color: blue;
}
```

Това ще добави текст "Псевдоелемент: " пред всяко `<p>`, и текст " - край" след него, без да променяме самото HTML съдържание.

**Други псевдоелементи:**

- `::first-letter` – стилизира първата буква на елемента.
- `::first-line` – стилизира първия ред на елемента.

Тези псевдоелементи са полезни за по-фин контрол върху стилизирането на HTML съдържанието.
## Order of CSS Selectors
Колкото по абстрактен и глобален е даден селектор, толкова по-нагоре трябва да е сложен в кода.
# ChatGPT
## Height Property and Its Effects:
1. **Space Allocation**:
    - When you set a fixed `height` on a block-level element like `<p>`, the browser will reserve that amount of vertical space on the page, regardless of the content's height.
    - Even if the content inside the element is shorter than the specified height, the element itself will still occupy the full height, meaning the next element on the page will appear after this reserved space.
2. **Background Color**:
    - If you apply a background color to the element, it will cover the entire area defined by the `height` and `width` properties.
    - This makes the specified height visually apparent, even if the content inside doesn't fill the entire space.

Example:

```
p {
  height: 3cm;
  width: 3cm;
  background-color: lightgrey;
}
```

- **Visual Behavior**: The paragraph will occupy a height of 1 cm on the page, regardless of how much text it contains.
- **Next Element Positioning**: Any subsequent element will be positioned below this 1 cm tall `<p>` block.
- **Background Coverage**: The light grey background will fill the entire 1 cm height, making the height visible.

Summary:
- **Height**: The `height` property indeed controls the vertical space the element takes up, even if the content is smaller.
- **Background Color**: The background color will fill the entire specified box, making the height visible even with short content.
- **Next Element**: The following element on the page will start after the specified height, ensuring the space is respected visually.

This makes the `height` property very effective in controlling layout, spacing, and design, even when content doesn't fully fill the defined height.
## Margin and Padding Difference
Understanding the difference between **margin** and **padding** is key to mastering CSS layout. Here's a clear breakdown:

Margin
- **What It Is**: The margin is the space outside the element’s border.
- **Purpose**: It creates space between the element and other elements around it, pushing them away.
- **Impact on Layout**: Margin affects the spacing between different elements on the page. Increasing the margin will move the element away from its neighbors.
- **No Background Color**: The margin area is transparent. Even if the element has a background color, the margin area won’t be colored.
- The `margin` property in CSS controls the space around an element, and it affects the distance in two ways:
1. **Between Sibling Elements**: The margin defines the space between an element and its neighboring elements (siblings) on the same level within a parent container. For example, if you have two `<div>` elements next to each other, the margin will determine how much space is between them.
2. **Between a Child and Its Parent**: The margin also determines the space between a child element and the inside edge of its parent element. For example, if a child element has a top margin, it will create space between the top of the child element and the top edge of the parent container.

Padding
- **What It Is**: The padding is the space inside the element’s border but outside the content.
- **Purpose**: It creates space between the content of the element (like text or images) and the element’s border.
- **Impact on Layout**: Padding affects the space inside the element itself, making the content appear farther from the border.
- **Background Color**: The padding area inherits the background color of the element. This means the padding area will be colored the same as the element if a background color is applied.

Visual Representation
Imagine a box:
- **Content**: The core of the box where your text or images sit.
- **Padding**: The space directly around the content, inside the box.
- **Border**: The line that wraps around the padding and content.
- **Margin**: The space outside the border, separating this box from other boxes.
Example:

```
div {
  margin: 20px;  /* Space outside the element */
  padding: 10px; /* Space inside the element, around the content */
  border: 2px solid black; /* Border around the element */
  background-color: lightblue; /* Background of the content + padding */
}
```

- **Margin**: 20px of space will be added around the outside of the element, pushing other elements away from this one.
- **Padding**: 10px of space will be added inside the element’s border, creating space between the content and the border.
- **Border**: A solid black line, 2px wide, around the element.
- **Background Color**: The light blue background will fill the content area and the padding area but not the margin.

Summary:
- **Padding** is inside the border, increasing the space between the content and the border. It’s part of the element's internal spacing. Importantly, the background color extends through the padding area, but the padding itself cannot extend beyond the border. The padding creates space within the box and visually separates the content from the border, but it does not push the border outward.
- **Margin** is outside the border, increasing the space between the element and other elements. It affects the element's external spacing and ensures separation from neighboring elements. The margin area is transparent and does not inherit the background color of the element.

This distinction is crucial when laying out elements on a page, as it helps control both the internal appearance and the spacing between different components, ensuring that elements are visually appealing and properly positioned.

**Negative Margin**

Using a negative margin in CSS,, shifts the element in the direction of the margin where it would normally be placed. Here's how it works:

- **Negative Top Margin (`margin-top: -25px;`)**: Moves the element 25 pixels up.
- **Negative Bottom Margin (`margin-bottom: -25px;`)**: Moves the element 25 pixels closer to the next element below it, possibly overlapping.
- **Negative Left Margin (`margin-left: -25px;`)**: Moves the element 25 pixels to the left.
- **Negative Right Margin (`margin-right: -25px;`)**: Moves the element 25 pixels to the right.
## Inherit
In CSS, the `inherit` value is used to make a property inherit its value from its parent element. This means that the child element will take on the same property value as its parent.

Imagine you have a `div` element inside another `div`. You want the inner `div` to have the same text color as the outer `div`, regardless of what that color is.

This approach is useful when you want to ensure that certain properties remain consistent across child elements without needing to manually set the same value for each child.
## Semantic Properties
Semantic properties like `margin-top-start` refer to logical properties in CSS that allow styling based on the content's flow and writing direction, rather than fixed physical directions (like `top`, `right`, `bottom`, `left`).

For example:

- **`margin-top-start`**: Refers to the margin at the start of the block, which could be on the top or left, depending on the writing mode (e.g., left-to-right or right-to-left text).
- **`margin-block-start`** and **`margin-inline-start`**: Respectively control the margin at the start of block-level and inline-level content, adapting to different writing directions.

These properties help create more flexible and language-sensitive layouts, especially for multilingual websites.
## Default CSS Styles for HTML Elements
In HTML, different elements come with their own default styles applied by the browser's user agent stylesheet. These default styles can vary between elements and include properties like margins, padding, display types, and font sizes. Here's a quick overview:

1. **Block-Level Elements**:
    - **Paragraphs (`<p>`)**: Typically have default margins applied to the top and bottom (`margin-top` and `margin-bottom`), usually around `1em`, which creates space between paragraphs.
    - **Headings (`<h1>`, `<h2>`, etc.)**: Often have larger default margins and font sizes, making them stand out more as titles or section headers.
    - **Divs (`<div>`)**: Usually do not have any default margins, padding, or font styles, serving as a generic container without added spacing unless specified.
2. **Inline Elements**:
    - **Span (`<span>`)**: Typically has no default margins, padding, or block-level characteristics. It flows inline with surrounding text.
    - **Links (`<a>`)**: Often have default underlining and color styles applied, such as blue text and underline for unvisited links.
3. **Form Elements**:
    - **Inputs (`<input>`)**: May have default padding, borders, and specific sizing based on the input type (e.g., text input, checkbox).
    - **Buttons (`<button>`)**: Generally have default padding, border styles, and background colors to make them visually distinct as interactive elements.
4. **Lists (`<ul>`, `<ol>`, `<li>`)**:
    - **Unordered and Ordered Lists**: Usually have default padding or margins to indent the list, as well as default bullet points or numbering.
    - **List Items (`<li>`)**: Inherits spacing and list-style properties from the parent `<ul>` or `<ol>`.

**Uniformity of HTML Elements with Default Property Values**
In HTML, while all elements are fundamentally the same in terms of their core functionality and behavior, they differ primarily in their default property values. Here’s a concise summary:

1. **Core Functionality**:
    - **Uniformity**: All HTML elements are fundamentally similar; they serve as containers or structures for content and can be styled and manipulated with CSS.
    - **Basic Behavior**: Every element can have properties like `margin`, `padding`, `border`, and `display` applied to it.
2. **Default Property Values**:
    - **Predefined Defaults**: Each HTML element comes with predefined default values for properties like margins, padding, font size, and display type.
    - **Example Differences**:
        - **`<p>`**: Typically has default margins (`margin-top` and `margin-bottom`) to separate paragraphs, but no default padding.
        - **`<div>`**: Usually has no default margins or padding, acting as a generic container.
        - **`<h1>`**: Comes with larger default margins and font size for headings.
3. **Custom Styling**:
    - **Flexibility**: Although elements have default values, these can be overridden or adjusted using CSS to fit specific design requirements.
    - **Consistency**: The core properties of elements remain the same, but their default styles provide a starting point that can be customized.

Key Takeaway
All HTML elements share a similar core functionality but differ in their default property values and inherent styles. Understanding these default settings allows for effective customization and design, ensuring consistent and flexible web development.
Key Points:
- **Default Styles**: Different HTML elements come with different default styles applied by browsers.
- **Custom Styling**: To achieve specific layouts and designs, these default styles can be overridden using CSS.
- **Understanding Defaults**: Knowing the default behavior helps in designing and troubleshooting layouts, especially when elements behave differently based on their type.

This foundational knowledge helps in creating more predictable and controlled web designs.
## Child Larger Than Parent
**Behavior:**
- When a child element is larger than its parent, it will overflow the parent container. This means that the child can extend beyond the edges of the parent box, potentially causing horizontal or vertical scrollbars, depending on the overflow settings of the parent.

Inline Children Behavior
**Behavior:**
- When using `inline` or `inline-block` display for children, the elements align horizontally within their parent. If the combined width of the inline elements exceeds the width of the parent container, the extra inline elements will wrap to the next line, similar to how text wraps in a paragraph.

Summary:
1. **Overflowing Child**: If a child element is larger than its parent, it will overflow outside the parent’s box. The `overflow` property on the parent controls how this overflow is handled (scrollbars, hidden content, etc.).
2. **Inline Children Wrapping**: When using `inline` or `inline-block` for child elements, they will align horizontally until the parent’s width is exceeded. The excess inline children will then wrap to the next line.

Understanding these behaviors helps in managing layouts and ensuring that elements are displayed as intended across different screen sizes and resolutions.
## Box Size
You
If we make a very small box and the content cant fit in, it will just overflow?

ChatGPT
Yes, if you create a very small box (for example, with a small `width` and `height`), and the content inside it cannot fit within the box's dimensions, the content will overflow. How this overflow is handled depends on the CSS `overflow` property applied to the box.

Here are the possible behaviors:

1. **`overflow: visible;`** (default): The content will overflow the box and remain visible outside the box's boundaries.
    
2. **`overflow: hidden;`**: The overflowing content will be clipped, meaning it will be cut off and not visible outside the box.
    
3. **`overflow: scroll;`**: Scrollbars will appear on the box, allowing users to scroll to see the hidden content.
    
4. **`overflow: auto;`**: Scrollbars will appear only if the content overflows. If the content fits within the box, no scrollbars will be shown.

For example:

```
<div style="width: 100px; height: 50px; overflow: auto;">
  This is some very long content that won't fit in the box.
</div>
```

## Content and Box
The content within an HTML element is always linked to its containing box. 

- **Content Size and Box Size:** The size of the content is determined by the content itself, while the size of the containing box is determined by CSS properties like `width`, `height`, `padding`, `border`, and `margin`.

- **Overflow:** The `overflow` property manages how the content behaves if it exceeds the boundaries of the containing box. It doesn't change the size of the box or the content but dictates what happens when the content is larger than the box:
    - `visible`: Content spills out of the box.
    - `hidden`: Content is clipped, and the overflow is not visible.
    - `scroll`: Scrollbars are added to navigate the overflowed content.
    - `auto`: Scrollbars are added only if the content overflows.

In summary, while `overflow` controls the visibility and behavior of excess content, it doesn’t alter the size of the content or the box itself.
## Shorthand `/` Divider
In CSS, the `/` character is used in shorthand properties to separate different types of values. Here's a general summary and example of its usage:

The `/` character in CSS shorthand properties separates values that are related but pertain to different aspects of the property. It is used to delineate between two different types of values within the same shorthand declaration.

`font: [font-style] [font-variant] [font-weight] [font-size] / [line-height] [font-family];`

**Explanation:**

- **Font Style, Variant, and Weight** are related to the type and emphasis of the font.
- **Font Size and Line Height** are separated by `/` where the font size is defined first, followed by the line height.
- **Font Family** specifies the typeface used.

**Example Usage:**

```
font: italic small-caps bold 16px / 24px Arial, sans-serif;
```

- **Italic**: Font style.
- **Small-caps**: Font variant.
- **Bold**: Font weight.
- **16px**: Font size.
- **24px**: Line height (specified after `/`).
- **Arial, sans-serif**: Font family.

**Name of the Divider:** The `/` character does not have a specific name, but it functions as a **delimiter** or **separator** within CSS shorthand properties to clearly distinguish between different types of values.
## `em` Unit in CSS
**Definition**: The `em` unit is a relative measurement in CSS, where 1em equals the current font size of the element it is applied to. It scales proportionally with the font size, ensuring that all dimensions using `em` remain consistent with the text size.

**Usage**:
- **Font Size**: If an element's font size is set to `2em`, it will be twice the size of its parent element’s font size. For example, if the parent font size is 16px, then `2em` will be 32px.
- **Padding and Margin**: When applied to padding, margin, or other properties, `em` units scale relative to the font size, maintaining proportional spacing.

**Compounded Scaling Effects**:

```
html {
    font-size: 16px; /* Base font size */
}

.parent {
    font-size: 2em; /* 2 * 16px = 32px */
}

.child {
    font-size: 1.5em; /* 1.5 * 32px = 48px */
    margin: 2em; /* 2 * 48px = 96px */
}
```

 **Explanation**: In this example, `.parent` has a font size of `32px`, making `.child`'s `1.5em` font size equal to `48px` (1.5 * 32px). Additionally, `.child`'s `2em` margin translates to `96px` (2 * 48px), demonstrating compounded scaling effects where changes in font size propagate through nested elements.

**Inheritance**: The `em` unit inherits its size relative to its parent element’s font size. If the parent’s font size changes, all child elements using `em` units will adjust accordingly, resulting in a cascading effect.

 **Benefits**:
- **Consistent Proportions**: Ensures that text, padding, and margins scale proportionally with font size changes.
- **Responsive Design**: Facilitates responsive layouts by keeping dimensions and spacing in proportion to the font size, enhancing readability and adaptability.

Using `em` units allows for scalable and adaptable design, ensuring that all elements adjust proportionally to font size changes, creating a cohesive and responsive layout.
## Margin Collapsing
When two elements have adjacent vertical margins, and one of them has a larger margin, the resulting margin between them will be equal to the larger of the two margins. This behavior is known as **margin collapsing**.

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Margin Collapsing Example</title>
    <style>
        .element1 {
            margin-bottom: 30px;
            background-color: lightblue;
        }
        .element2 {
            margin-top: 50px;
            background-color: lightgreen;
        }
    </style>
</head>
<body>
    <div class="element1">Element 1</div>
    <div class="element2">Element 2</div>
</body>
</html>
```

- `element1` has a bottom margin of `30px`.
- `element2` has a top margin of `50px`.

Instead of the total space between the elements being `30px + 50px = 80px`, the actual space will be `50px`, which is the larger of the two margins. The smaller margin collapses into the larger one.

Important Points:

- **Margin collapsing** only applies to vertical margins (top and bottom).
- Horizontal margins (left and right) do not collapse in this way; they simply add up.

**Margin collapsing** (sometimes referred to as **"bleeding margins"**) occurs when the top and bottom margins of certain block-level elements collapse into one another instead of adding together. This behavior affects vertical margins between block elements, and understanding it can help you avoid unexpected layout issues in CSS.

**Key Points of Margin Collapsing**

**Vertical Margins Only:** Margin collapsing only happens with **vertical margins** (i.e., `margin-top` and `margin-bottom`), not with horizontal margins (`margin-left` and `margin-right`).
    
**How Collapsing Works:** When two vertical margins meet (e.g., the bottom margin of one element and the top margin of the next element), they **collapse** and the larger margin takes precedence. The resulting space between the elements will be equal to the largest of the two margins, not the sum of both.

```
<div style="margin-bottom: 20px;"></div>
<div style="margin-top: 30px;"></div>
```

The space between the two `<div>` elements will be **30px**, not 50px, because the larger margin (30px) takes over.
    
**Adjacent Block Elements:** Collapsing typically happens between **adjacent block-level elements** in the normal document flow. If one block element has a bottom margin and the next block has a top margin, the margins collapse into a single margin (the larger of the two).
    
**Nested Block Elements:** Margin collapsing can also happen between a parent block element and its first/last child. If a child element has a top margin, and the parent doesn't have a border, padding, or overflow, the child's top margin may collapse with the parent’s margin.
    
```
<div style="margin: 50px;">
  <p style="margin: 30px 0;">Text inside</p>
</div>
```

Here, the top margin of the `<p>` may collapse with the margin of the `<div>`, reducing the space between the top edge of the `<div>` and the first line of text inside.

**Non-Collapsing Cases:** Vertical margins do not collapse in the following cases:
- When there’s **border**, **padding**, or **content** separating the margins.
- When an element has a **float** or is set to **absolute positioning**.
- If the parent element has `overflow: auto` or `overflow: hidden`, margin collapsing will be prevented.

**Empty Elements:** If a block element is **empty** and has no content, padding, or borders, its margins might collapse. This can lead to the unexpected disappearance of space between the empty block and its surrounding elements.

**Examples of Margin Collapsing**
**Two Adjacent Block Elements:**

```
<div style="margin-bottom: 50px;">Block 1</div>
<div style="margin-top: 20px;">Block 2</div>
```

The space between Block 1 and Block 2 will be **50px**, not 70px, because the margins collapse to the larger value (50px).

**Parent and First Child Collapse:**

```
<div style="margin-top: 30px;">
  <p style="margin-top: 40px;">This is a paragraph.</p>
</div>
```

 The space between the top of the `<div>` and the first line of text in the `<p>` will be **40px** (the margin of the child), not 70px, because the margins collapse.

**Preventing Margin Collapsing**

You can prevent margin collapsing using the following methods:

1. **Add padding or border** to the parent or adjacent elements.
2. **Use `overflow: hidden`** or another overflow value on the parent.
3. **Use `display: inline-block`** or `display: flex` to change the layout model.
4. **Apply float or positioning** (e.g., `position: relative`).

Example of preventing collapsing by adding padding:

```
<div style="margin-top: 30px; padding-top: 1px;">
  <p style="margin-top: 40px;">This is a paragraph.</p>
</div>
```

In this case, the 1px padding prevents the margins from collapsing, so you’ll get the full combined margin (30px + 40px).

**Conclusion**

Margin collapsing (or bleeding margins) is a CSS behavior where vertical margins of adjacent block-level elements combine into a single margin instead of adding together. Understanding when and why margins collapse helps you control spacing and avoid unintended layout shifts.
## Viewport
The viewport is the visible area of a webpage on a user's screen. It's the portion of the webpage that is currently visible within the browser window, excluding any off-screen content. The size of the viewport can vary depending on the device, such as desktops, tablets, or smartphones. Web developers often use viewport-related properties in CSS and meta tags to create responsive designs that adapt to different screen sizes, ensuring a consistent user experience across various devices.
## Normal Document Flow
By default, elements in HTML follow a flow where they do not overlap. This default behavior is referred to as the **normal document flow**. In this flow:

1. **Block-level elements** (like `<div>`, `<p>`, `<h1>`, etc.) are stacked vertically on top of each other, taking up the full width of their container. Each element starts on a new line.
    
2. **Inline elements** (like `<span>`, `<a>`, `<strong>`, etc.) are placed next to each other horizontally, within a line, until the line's width is filled, at which point they move to the next line.

**Overlapping Without Manual Positioning:**

- **Normal Flow**: In normal document flow, elements do not overlap. They are laid out in the order they appear in the HTML, either vertically (for block elements) or horizontally (for inline elements).

- **No Overlap**: Without changing the positioning properties (`position: relative;`, `position: absolute;`, etc.), elements remain in their designated places, and the browser ensures that they don't overlap.

However, once you start using positioning (like `absolute`, `relative`, `fixed`, or `sticky`) or certain CSS properties like `float` or `negative margins`, elements can overlap each other. This is where properties like `z-index` become useful to control the stacking order of the overlapping elements.
## z-index
The concept of `z-index` in CSS is akin to adding a third dimension to the layout of a webpage.

**The Three Dimensions:**

1. **X-axis (Horizontal)**: This represents the left-to-right positioning of elements on the page.
2. **Y-axis (Vertical)**: This represents the top-to-bottom positioning.
3. **Z-axis (Depth)**: This is where `z-index` comes in. It determines the stacking order of elements along the "depth" axis—how elements are layered on top of or behind each other.

**How `z-index` Works:**

- **Default Stacking**: By default, elements are stacked in the order they appear in the HTML. Later elements in the DOM tree are layered on top of earlier ones.
    
- **Using `z-index`**: By applying `z-index`, you can control the order in which elements overlap. A higher `z-index` value means the element will appear on top of others with a lower `z-index` value.
    
    - For example:
        - An element with `z-index: 10` will appear above an element with `z-index: 5`.
        - If two elements have the same `z-index`, their order will depend on the order in which they appear in the HTML.
- **Positioned Elements**: For `z-index` to work, the element must have a position other than `static` (which is the default). Commonly used values are `relative`, `absolute`, `fixed`, or `sticky`.

**Visualizing `z-index`:**

You can think of `z-index` as layers in a stack of paper:

- The **bottom-most layer** (lowest `z-index`) is the first piece of paper.
- Higher layers (higher `z-index`) stack on top of this, obscuring parts or all of the layers beneath them.

In this way, `z-index` adds a third dimension to the otherwise two-dimensional layout of web pages, allowing elements to overlap and create more complex designs.
## Zoom Levels in Web Design
**Zoom Levels**:

- **Definition**: Zoom levels adjust the size of content displayed in the browser, affecting how elements are rendered and viewed.
- **Types**:
    - **In**: Enlarges content, making elements appear larger but potentially causing layout issues due to fractional pixel rendering.
    - **Out**: Reduces content size, which can compress elements and affect readability.

**Effects on Layout**:

- **Pixel Measurement**: Zooming can cause pixel values to appear fractional in the browser’s inspector, impacting precision in element measurements.
- **Rendering Adjustments**: Browsers may adjust how borders, fonts, and spacing are rendered to fit the zoom level, leading to inconsistencies.

**Best Practices**:

- **Design at 100%**: For accurate design and measurement, work and test at a 100% zoom level.
- **Check Responsiveness**: Ensure layouts are responsive and functional across different zoom levels and device pixel ratios.
- **Consistency**: Verify element sizes and positions after adjusting zoom to ensure visual consistency and accuracy.

Understanding zoom levels helps in designing and debugging web layouts effectively, ensuring elements appear as intended across different viewing contexts.
## User Agent Stylesheet
A **user agent stylesheet** is the default set of CSS styles that a web browser applies to HTML elements when no other styles are specified by the author of the webpage. Every browser comes with its own built-in user agent stylesheet to ensure that web pages have a basic, consistent appearance even without any custom CSS.

Key Points about User Agent Stylesheets:

- **Defaults:** They provide default styles for HTML elements like headings, paragraphs, lists, tables, etc. For example, browsers typically render `<h1>` elements with a larger font size than `<h2>`, and `<p>` elements with some default margin.
- **Override:** You can override these default styles by specifying your own CSS. The styles in your stylesheet or inline styles will take precedence over the user agent stylesheet due to CSS's cascading nature.
- **Cross-Browser Differences:** While most user agent stylesheets are similar across browsers, there can be slight differences, which is why the same HTML may look slightly different in different browsers.
- **Normalization:** Developers often use CSS "reset" or "normalize" stylesheets at the beginning of their own CSS to standardize styles across browsers, effectively neutralizing differences in user agent stylesheets.

In summary, user agent stylesheets are the browser's way of ensuring that web pages have a base level of styling, which you can customize or override with your own CSS.
## Typeface / Font Family
- **Definition**: The design or style of a set of characters. It is essentially the visual appearance or design of text.
- **Example**: _Georgia_, _Times New Roman_, _Helvetica_.

Font Family
- **Definition**: A collection of related typefaces that share common design elements but come in different styles or weights. This collection often includes variations such as regular, bold, italic, and so on.
- **Example**: The _Georgia_ font family includes _Georgia Regular_, _Georgia Bold_, _Georgia Italic_, and _Georgia Bold Italic_.

The terms **typeface** and **font** are often used interchangeably, but they have distinct meanings, especially in the context of typography and design.

Typeface
- **Definition**: A typeface is a collection of characters that share a common design. It represents the style or design of the text, encompassing all of its variations (like different weights and styles).
- **Example**: _Helvetica_, _Times New Roman_, _Georgia_.
- **Components**: Includes various fonts such as Regular, Bold, Italic, and so on, within a single design.

Font
- **Definition**: A font is a specific instance of a typeface. It refers to the actual implementation of a typeface in a specific style and size. In the past, fonts were physical objects used in printing, but now they are digital files.
- **Example**: _Helvetica Bold 12pt_, _Times New Roman Italic 14pt_.
- **Components**: A font refers to a specific style, weight, size, and other attributes.

 Key Differences
- **Scope**: A typeface is a broader term encompassing various styles and weights of a single design. A font refers to a particular style and size of that typeface.
- **Example**: If _Arial_ is the typeface, then _Arial Regular 12pt_, _Arial Bold 14pt_, and _Arial Italic 10pt_ are different fonts within that typeface.

Analogy
- **Typeface as a Class**: In programming, a class defines a blueprint or template for creating objects. Similarly, a typeface defines a general design or style for a set of characters.
- **Font as an Object**: An object is an instance of a class with specific attributes and behaviors. Similarly, a font is an instance of a typeface with specific attributes such as weight, style, and size.
- **Typeface** represents the overarching design concept (the class definition).
- **Font** represents a specific implementation of that concept (an object created from the class).

Summary
- **Typeface**: The design or style of a collection of characters (e.g., _Arial_).
- **Font**: A specific version or size of a typeface (e.g., _Arial Bold 12pt_).
- **Typeface**: The specific design (e.g., Georgia).
- **Font Family**: The group of related typefaces based on that design (e.g., Georgia Regular, Georgia Bold, etc.).

In CSS, the `font-family` property allows you to specify the typefaces or font families that should be used for the text. If the preferred typeface is not available, the browser will use the next option in the list, or fall back to a generic font family if none of the specified fonts are available.
The typeface defines the design, while the font applies specific attributes to that design. 
You can think of the typeface as the foundational style, and the font as the application of that style with detailed settings.
## Block, Inline-Block Differences
The primary differences between `inline-block` and `block` elements are:

1. **Content Flow**:
    
    - **Block Elements**: Always start on a new line and take up the full width available, pushing other elements above or below them.
    - **Inline-Block Elements**: Do not start on a new line. They allow other elements to sit beside them (to their left or right) if there is enough space. This allows them to appear in the same line with other `inline` or `inline-block` elements.
2. **Width**:
    
    - **Block Elements**: By default, the width of a block element is 100% of its container's width (unless specified otherwise).
    - **Inline-Block Elements**: The width of an `inline-block` element depends on its content. However, you can still set a specific width for an `inline-block` element, and it will respect that width. So, while `inline-block` elements don’t inherently take up the full width of their parent like block elements do, they can still do so under the right conditions (such as having enough content or a specified width).
3. **Height**:
    
    - **Block Elements**: The height of a block element is determined by its content (or a set value), and it extends to fill its parent container horizontally.
    - **Inline-Block Elements**: The height of an `inline-block` element is also determined by its content (or a set value), but it does not expand to fill the entire width of its parent container horizontally.
4. **Box Model**:
    
    - **Block and Inline-Block Elements**: Both respect all aspects of the CSS box model, including padding, margin, and borders.

In summary, `inline-block` elements combine the flow of inline elements with the layout flexibility of block elements, allowing them to sit next to other elements while still supporting width, height, and other block-level properties.
## Behavior of Inline Elements
- **No Control Over Width and Height**: Inline elements only take up as much width as their content requires, and they ignore `width` and `height` properties. This means you cannot explicitly control their dimensions in the same way as block elements.
- **Flow Within Text**: Inline elements flow with the surrounding text, and they only occupy the width of the content inside them. Their height is determined by the line-height of the text.
- **CSS Width Ignored**: Even though you can see the `width` set in the browser's inspector, it won't have any visible effect on an inline element. The `width` property is applied but isn't respected by inline elements because they are not intended to behave like block elements.
## Block, Inline / Vertical, Horizontal

- **Inline** elements are primarily concerned with **horizontal flow**.
- They are placed **next to each other** horizontally, like text in a sentence, until they hit the edge of the container or run out of space.
- Examples of inline elements include `<span>`, `<a>`, and `<em>`.
- They **don’t start on a new line** and respect the content’s flow.
- Inline elements only take up the **width of their content** and do not break the flow of the surrounding content vertically.

**Block Elements:**

- **Block** elements are more concerned with **vertical flow**.
- They typically start on a **new line** and take up the full width of their container by default, pushing content vertically below them.
- Examples of block elements include `<div>`, `<p>`, and `<h1>`.
- Block elements **stack vertically** and typically expand to fill the width of their parent container (unless a specific width is set).

**Margin and Layout

- When we refer to **"inline"** in the context of CSS layout (e.g., `margin-inline`, `padding-inline`), it refers to the **horizontal dimension** (left and right in left-to-right languages).
- Similarly, **"block"** refers to the **vertical dimension** (top and bottom).

**Inline vs. Block Summary:**

- **Inline:** Horizontal alignment and flow. Elements are placed side by side.
- **Block:** Vertical stacking, where elements push content below and fill available width.

**In CSS terminology:**

- **Inline** = generally related to **horizontal behavior** (left/right).
- **Block** = generally related to **vertical behavior** (top/bottom).
## Pseudo Elements
Here’s a concise summary of how pseudo-elements work and how they compare to HTML elements:

**Default Behavior:**

- **`::before` and `::after` (default display: inline):**
    - **`::before`**: Adds content **before** the content of the element.
    - **`::after`**: Adds content **after** the content of the element.
    - **Default Display**: Acts like an inline element, similar to a `<span>`. It does not start on a new line.

**Changing Display:**

- **Changing to `display: block;`:**
    - **`::before` (block-level)**: Adds content before the element, and this content behaves like a block-level element (similar to a `<div>`).
    - **`::after` (block-level)**: Adds content after the element, and this content also behaves like a block-level element.

**HTML Comparisons:**

- **Default Inline (like `span`):**

```
<body>
    <p>Text <span>Inserted content</span></p>
</body>
```

- **Equivalent CSS:**

```
    <style>  
        p::after {
            content: " Inserted content";
        }
    </style>
</head>

<body>
    <p>Text</p>
</body>
```

- **Block-Level (like `div`):**

```
<body>
    <div style="margin-top: 12px;">Block-level element</div>
    <p style="margin-top: 0;">Text</p>
</body>
```

- **Equivalent CSS for `::before` or `::after` with `display: block;`:**

```
    <style>   
        p::before { 
            content: "Block-level element"; 
            display: block; 
        }
    </style>
</head>
<body>
    <p>Text</p>
</body>
```

 **Block-Level (like `div`):**

```
<body> 
    <p style="margin-bottom: 0;">Text</p>
    <div style="margin-bottom: 12px;">Block-level element</div>
</body>
```

- **Equivalent CSS for `::before` or `::after` with `display: block;`:**

```
    <style>   
        p::after { 
            content: "Block-level element"; 
            display: block; 
        }
    </style>
</head>
<body>
    <p>Text</p>
</body>
```

**Placement:**

- **`::before`**: Inserts content before the actual content of the element (in the case of a block-level pseudo-element, before the content starts).
- **`::after`**: Inserts content after the actual content of the element (in the case of a block-level pseudo-element, after the content ends).

This flexibility allows you to add extra content and style it without modifying the HTML structure directly.

**Margin Issue Summary:**

- **Pseudo-Elements (`::before` and `::after`)**:
    
    - **Behavior**: They are considered part of the parent element, so their spacing is influenced by the parent's margin, padding, and overall layout.
    - **Issue**: Adjusting the spacing can be tricky because pseudo-elements are nested inside the parent element, making their spacing relative to the parent’s styling.
- **HTML Elements**:
    
    - **Behavior**: They are separate from each other and positioned as siblings or children in the DOM.
    - **Issue**: Margins and padding are applied directly to these elements, so adjusting spacing is straightforward but requires careful positioning relative to other elements.

**To match the visual output**:

- Use margin adjustments on the parent element or pseudo-elements to align spacing between pseudo-elements and regular HTML elements effectively.
# Bookmarks 

[Figma](https://www.figma.com) - Figma is used in web development to design user interfaces, facilitate collaboration among design and development teams, create design systems, and streamline the handoff process. Its real-time collaboration features and integration with design systems make it a valuable tool in creating and refining web applications and websites.

Completion: 02.09.2024