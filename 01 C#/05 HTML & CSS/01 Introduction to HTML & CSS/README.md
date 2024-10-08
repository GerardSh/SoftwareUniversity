# General
## What is HTML
Hypertext Markup Language е език, който описва съдържание. Той е основата за създаването на web страници, всички браузъри отварят и четат HTML, взимат информацията в документа и ни я презентират. Както Word чете docx файлове, така браузърите четат HTML. Всеки сайт е набор от HTML файлове, ако има 3000 страници, това означава че има 3000 HTLM файла.

Език за описване на семантична структура - параграф, заглавие и тн. 

HTML има тагове, чрез които описваме съдържанието.

Browser-a е софтуер, който си говори със сървъра чрез HTTP протокол - казва искам този адрес и сървъра връща информацията под формата на HTML, след което браузъра го разчита и ни го презентира.
### HTML Tags
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823185250.png)

Таговете са ключови думи, обградени със скоби, като един таг има начало и край. Имаме отварящ и затварящ таг, като има и самостоятелни тагове, без затварящ.
Може да имаме и вградени тагове:

```
<header>
   <h1>Welcome</h1>
</header>   
```
#### `<main></main>`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823190451.png)

Трябва да имаме само един main tag и той държи основния content на нашата страница.
#### `<aside></aside>`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823190540.png)

Използва се когато имаме sidebar, който може да съдържа линкове или друга допълнителна информация.
#### `<footer></footer>`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823191655.png)

Може да е footer за целия сайт или нещо друго.
#### `<section></section>`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823191821.png)

Ползва се, ако искаме да отделим част от съдържанието
#### `<article></article>`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823191957.png)

Ползва се, ако искаме да опишем дадена статия.
#### `<figure></figure>`
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823192512.png)

Специален таг, който описва допълнителна информация за картинки.
### Sections and Articles
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823192111.png)
### HTML Versions
В началото на всеки документ, трябва да слагаме `<!DOCTYPE html>`. Това казва на браузъра че версията на HTML е 5 и че ние поемаме ангажимент за валидността на този код. Ако го махнем браузъра работи в quirks / compatibility режим в който ни чете HTML-a и се опитва да го оправи. Това е от преди много време, когато HTML е бил пълен с грешки и браузърите са опитвали да ги оправят.
### Common HTML Tags
#### Headings and Paragraphs
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823194830.png)
#### Hyperlinks
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823194857.png)
#### Images
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823195012.png)
#### Ordered Lists
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823195126.png)
#### Unordered Lists
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823195503.png)
#### Definition Lists
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823195615.png)
### HTML Tag Attributes
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823211619.png)

Чрез атрибутите, имаме възможност да добавяме допълнителна информация към определен таг.
Имаме име на атрибута и неговата стойност - key value pair. Името е ключа, който ни позволява да стигнем до информацията. 
Има универсални атрибути, които може да се сложат навсякъде, но има и атрибути, които работят само на определени тагове.
Винаги се пишат с малки букви, а техните стойности са в двойни или единични кавички. Кавичките трябва да са еднакви при отварянето и затварянето.
### HTML Metadata Section
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823212213.png)
### Metadata Section
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240823212946.png)
### Indentation & Code formatting
Indentation-a е много важен, за да знаем бързо и лесно, къде се намираме в кода. Ползва се предимно Tab който е равен на 4 space-a.
Всеки екип работи по различен стандарт, някои предпочитат да ползват само spaces, докато други използват Tab за да изместят с един таб навътре, всеки вложен tag.
## What is CSS?
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240824105816.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240824111231.png)

Друг описателен език, който използваме за да дефинираме визуално как да изглеждат HTML елементите. HTML не е бил мислен с идеята да добавя тагове за форматиране, които да казват как да изглежда HTML. Целта на HTML е да държи съдържание и неговото описание. CSS е създаден за да държи форматирането отделно, и се ползва за да описва как да изглежда съдържанието. Това ни позволява да разделим съдържанието, от това как да изглежда. Можем да направим един и същи HTML код, да изглежда по различен начин в два отделни сайта, чрез CSS.
CSS документите са набор от правила, където ги имаме изредени. Всяко правило се състои от selector и набор от пропъртита и стойности. Чрез selector-a h1, който виждаме на картинката горе, ние казваме на всички h1 тагове в HTML file-a да им бъдат изпълнени пропъртитата в selector-a.
### Combining HTML and CSS files (External Style)
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240824112433.png)

В head частта на HTML file-a добавяме тага `<link>` ,който трябва да има пътя към CSS file-a.
### CSS Selectors
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240824113013.png)

[CSS selectors - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Selectors) - документация.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240824113216.png)
#### Type selector
Селектираме HTML тагa по неговото име за да приложим CSS пропъртита към всички елементи от този тип.
#### Class selector
Може да дефинираме клас в CSS, използвайки име с точка (`.`) пред него, и след това да приложим този клас към всеки HTML елемент чрез атрибута `class`. Имената се пишат най-често с Kebab Case (Hyphen-Separated) - примерно my-class.  
Aко дефинираме клас с име `odd`:

```
.odd {
  font-size: 10px;
}
```

След това в HTML може да приложим този клас към всеки елемент:

```
<p class="odd">Този параграф ще има размер на шрифта 10px.</p>
<div class="odd">Този div също ще има размер на шрифта 10px.</div>
```
#### ID selector
Може да добавим атрибута id в класа. В CSS file-a се достъпва чрез # последван от стойността на id-то. Може да имаме само един id номер на елемент.
#### Attribute selector
Може да се селектират елементите, които имат определени атрибути или елементите, които имат определена стойност на определен атрибут.
#### Universal selector
Универсалния селектор хваща абсолютно всички елементи и се използва със символа `*`. Използва се много рядко, защото смъква performance-a на браузъра. Принципно в днешно време, браузърите са много оптимизирани и това не е проблем, но не трябва да се прекалява.
#### Combined CSS Selectors
Имаме и комбинирани селектори, където може да комбинираме различни селектори, примерно определен таг и името на клас. Така всички елементи от този таг, включени в класа ще бъдат стилизирани.

CSS хваща набор от елементи и им прилага определени пропъртита.
#### CSS Combinators
##### Descendant combinator ( ` `)
Позволява да таргетираме елементи, които са вложени вътре в други елементи. Използва се интервал между селекторите, за да укажем, че селектираме всички съвпадащи наследници в рамките на даден елемент.

```
header p {
     color: red;
     font-weight: bold;
}
```

Това означава да хванем всички параграфи, които са наследници на header, тоест някъде вътре в header тага, ако имаме параграфи, те ще бъдат стилизирани от този селектор.
##### Selector list (`,`)
Може да листваме селектори със запетайка:

```
header, p, div {
     color: red;
     font-weight: bold;
}
```

Изредените тагове, ще бъдат стилизирани.
##### Child combinator (`>`)
Само директните наследници на даден таг биват стилизирани

```
header > p {
     color: red;
     font-weight: bold;
}
```

Ако `p` се намира непосредствено след header тага, ще бъде стилизиран, но ако е някъде навътре в йерархията от наследници, няма.
##### Adjacent Sibling Combinator (`+`)
Този селектор се използва за таргетиране на елемент, който веднага следва друг елемент като негов "съсед".

```
p + p {
    background-color: lightblue;
}
```

В този пример всички `<p>` елементи, които веднага следват друг `<p>` елемент, ще имат светлосин фон. Ако имаме два `<p>` елемента един след друг, вторият ще бъде стилизиран.
##### General Sibling Combinator (`~`)
Този селектор таргетира всички елементи, които са siblings на даден елемент, но не е задължително да са непосредствено след него.

```
p ~ p {
    background-color: lightgreen;
}
```

Всички `<p>` елементи, които са siblings (следват в същия родителски елемент) на даден `<p>` елемент, ще имат светлозелен фон. Те не е нужно да са непосредствено след първия `<p>` елемент, за да бъдат стилизирани.
##### Universal Combinator (`*`)
Селектира всички елементи в даден контейнер или в цялата страница. Този комбинатор може да бъде комбиниран с други селектори и комбинатори, за да таргетира специфични групи от елементи.

```
* {
    margin: 0;
    padding: 0;
}
```
### Adding CSS to our HTML documents
Имаме три опции:
#### External style sheet
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826093404.png)

CSS file, който го линкваме в HTML file-a. Това е основно, което ще ползваме.
В head тага слагаме link tag с адреса на CSS file-a.
#### Internal style sheet
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826093436.png)

Може да напишем style tag вътре в HTML-a и да пишем вътре CSS.
#### Inline style
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826093636.png)

Може в самия таг да пишем CSS, което е най-непредпочитания вариант и се ползва изключително рядко. Това чупи идеята да разделим стилизацията със съдържанието в отделни файлове, защото така ги свързваме в един файл и нямаме гъвкавост.
### Basic CSS Properties
#### font-size
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826154821.png)

Размера на шрифта, като може да използваме различни мерни единици.
#### font-weight
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826163604.png)

Kолко да е bold-нат шрифта.
#### font-style
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826154934.png)
#### text-align
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826163529.png)

justify не трябва да се използва никога, защото е най-бързия начин да се счупи четимостта на текста. Разстоянията между думите се променя и от там идва главния проблем.
#### line-height
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826163221.png)
#### letter-spacing
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826163823.png)

Основно се ползва за ефектни заглавия с голям текст, рядко се ползва за body текст.
#### text-decoration
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826164010.png)
#### text-indent
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826164154.png)

Премества текста навътре.
#### text-overflow
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826164244.png)

Контролира какво се случва, когато нямаме място за целия текст в нашия елемент. Вместо да отреже текста, може да сложи точки или нещо друго.
#### text-transform
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826164502.png)
#### word-break
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826164607.png)
#### text-shadow
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826164953.png)
#### text-color
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826165014.png)

Имаме набор от ключови думи, които се разбират от браузърите, като red, blue и тн.
Може да ползваме hexadecimal и rgb. Преди е трябвало да се ползва rgba за да се направи прозрачност, където последната стойност отговаря за прозрачността, като е в границите от 0 до 1. Това вече е събрано в rgb и няма нужда да се добавя а, може да се добави запетая и да се сложи стойност за прозрачност. 
В CSS има и нови допълнителни системи за цветове.
#### background-color
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826165042.png)
#### cursor
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826171641.png)
#### outline
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240826175841.png)
# Misc
## Web
Състои се от CSS, HTML и JavaScript, където CSS е визията, HTML е съдържанието, a JavaScript е behavior-a.
Реално без HTML, нищо друго няма смисъл. Идеята е че използваме елементи, които ги подреждаме, след което ги стилизираме с CSS и ако искаме допълнителни функционалности, може да ползваме и JS.
## Emmet
Това е инструмент за уеб разработчици, който ускорява писането на HTML и CSS код чрез съкращения. Работи в много текстови редактори като Visual Studio Code, Sublime Text и други.
- Съкращения: Например, `ul>li*5` се разширява до:

```
<ul>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
    <li></li>
</ul>
```

- CSS-подобни селектори: Например, `div#container>ul.list>li.item*3` и получаваме:

```
<div id="container">
    <ul class="list">
        <li class="item"></li>
        <li class="item"></li>
        <li class="item"></li>
    </ul>
</div>
```

- Автоматично завършване и навигация в кода, което улеснява работата.

Как се използва: Въвеждате съкращения в редактора си и натискаме `Tab` или `Enter`,  за да разширим кода.

Emmet е полезен за бързо генериране на HTML/CSS структури и спестяване на време.
## Semantic Tags
**Семантични тагове** в HTML са елементи, които описват значението на съдържанието, което обгръщат. Те помагат на браузърите и на достъпностните технологии да разбират структурата на документа и предлагат по-добра четимост на кода. Позволяват ни да разделяме определени части от съдържанието, по смислен начин.

 Примери:
- **`<header>`**: Заглавна част на страницата или секция.
- **`<footer>`**: Долна част на страницата или секция.
- **`<article>`**: Самостоятелно съдържание като статия или пост.
- **`<section>`**: Тематични раздели от съдържанието.
- **`<nav>`**: Навигационни връзки.
- **`<aside>`**: Допълнителна информация или страничен панел.
- **`<main>`**: Основното съдържание на страницата.

Тези тагове подобряват SEO (Search Engine Optimization) и достъпността, като предлагат ясно структурирано съдържание.
На ниво сайт, всеки документ може да има header, main и footer части. Main е само една част, докато header и footer може да са много. В един main, може да има много articles, а всеки article да има header и footer. Допълнително article-a, може да е разделен на sections, където може да имаме header и footer за всеки section. Семантичните тагове се формират от съдържанието и са абстрактни

# ChatGPT
## HTML Tags and  CSS Selectors relation
In HTML, **tags** like `<p>`, `<div>`, and `<img>` define the structure of a webpage. These tags can have **attributes** that provide extra information, such as `href` in `<a href="https://example.com">` or `src` in `<img src="image.jpg">`.

In CSS, **selectors** target HTML elements to apply styles. For example, `p` targets all `<p>` elements, while `.className` targets elements with a specific class. **Properties** define the styles applied, such as `color`, `font-size`, and `margin`.

Most CSS properties can be used with any selector, but their impact depends on the type of HTML element. For example:
- **Text-related properties** like `font-size` work on text-containing elements (`<p>`, `<h1>`).
- **Layout properties** like `display` or `position` apply to block and inline elements (`<div>`, `<span>`).
- **Specific properties** like `list-style-type` only affect lists (`<ul>`, `<ol>`).

Some properties may have no effect if used with the wrong element type (e.g., `font-size` on an `<img>`). Understanding the relationship between tags, attributes, selectors, and properties ensures effective styling.
## Difference between Tab and 4 Spaces
Using a tab and four spaces can look similar but are not the same. A tab is a single, adjustable-width character, while four spaces are four fixed-width characters. 
Tabs are more flexible but can cause alignment issues across different editors. 
Spaces ensure consistent indentation but take up more characters. The choice between tabs and spaces often depends on project style guides.
## Tags compared to `C#`
In both HTML and C#, the concept of a "tag" refers to different things, reflecting the different purposes and structures of the languages.

HTML Tags:
- **Definition**: In HTML, a tag is a keyword surrounded by angle brackets (`<` and `>`). Tags are used to define elements in a web page.
- **Purpose**: HTML tags describe the structure and content of a webpage, such as headings, paragraphs, links, images, and more.
- **Example**: `<p>This is a paragraph.</p>` defines a paragraph element.
- 
C# Tags:
- **Definition**: C# doesn’t have "tags" in the same sense as HTML. However, the closest concept might be **attributes**, which are used to provide metadata about code elements.
- **Purpose**: Attributes in C# are used to add metadata to classes, methods, or other entities. This metadata can be used for various purposes, such as controlling behavior at runtime, influencing how methods are executed, or providing information to the compiler.
- **Example**: `[Obsolete("This method is deprecated.")]` marks a method as obsolete.
- 
Summary:
- **HTML Tags**: Define the structure and content of a web page.
- **C# Attributes**: Provide metadata about code elements to control or influence behavior.

Though both involve a form of markup or annotation, their roles are fundamentally different due to the nature of the languages they belong to.
## Inline Styles vs. CSS Selectors

**Inline Styles**:
- Applied directly in HTML using the `style` attribute.
- **Example**: `<h1 style="font-size: 36px; color: blue;">Hello, World!</h1>`
- **Pros**: Quick for single elements.
- **Cons**: Increases HTML file size, harder to maintain, and inconsistent for multiple elements.
- **CSS Selectors**:
- Styles are defined in CSS files or `<style>` blocks.

**Example**:
```
h1 {
  font-size: 36px;
  color: blue;
}
```

**Pros**:
 - Separation of content and presentation.
 - Consistent styling across elements.
 - Easier maintenance and updates.
 - Reduced HTML file size and improved readability.
 - Supports advanced styling features.
 
**Priority**:
 - **Inline Styles** take precedence over CSS selectors. If both CSS rules and inline styles apply to an element, the inline styles will override the CSS styles.
 
 **Summary**:
CSS selectors are generally preferred for their efficiency, consistency, and maintainability in styling web pages. Inline styles are useful for quick, single-element changes but are less ideal for large-scale or consistent styling. When both are used, inline styles will override CSS selectors due to their higher specificity.
## Selector Types
**1. Compound Selectors:**
- **Definition:** Compound selectors are combinations of simple selectors (like tags, classes, IDs, and attributes) without using combinators. They are used to target elements that meet all the specified criteria simultaneously.

```
p.highlight { color: yellow; }
```

**2. Combinators with Simple or Compound Selectors:**
- **Definition:** Combinators (like space , `>`, `+`, `~`) are used to define the relationship between selectors. You can use combinators with simple selectors or even with compound selectors to create more complex patterns.

```
.container .box.shadow > p { color: blue; }
```

 **Combination of Both:**

- You can combine both compound selectors and combinators to form highly specific rules.

```
#main .content > article.featured p.intro { font-weight: bold; }
```

This flexibility allows CSS to be both simple and powerful, letting you apply styles to exactly the elements you need, with precision.

**Simple Selector**:
- Targets elements based on a single criterion, such as a tag, class, or ID.
- Examples:
      - `p` targets all `<p>` elements.
    - `.box` targets all elements with the class `box`.
    - `#header` targets the element with the ID `header`.
**Combined Class Selector**:
- A type of compound selector where multiple classes are combined without any spaces or combinators.
- Example:
      - `.box.shadow` targets elements that have both the `box` and `shadow` classes.
- This is indeed a **compound selector** but specific to classes.
**Compound Selector**:
- A compound selector is a sequence of simple selectors that are not separated by a combinator. A compound selector represents a set of simultaneous conditions on a single element. A given element is said to match a compound selector when the element matches all the simple selectors in the compound selector.
- Compound selectors target elements based on multiple conditions applied to the element itself, without considering its position or relationship to other elements. This allows for precise styling based on the element's attributes and classes, independent of its place in the document structure.
- Combines multiple simple selectors without using combinators. It can include tags, classes, and IDs together.
- Example:
    - `div.box.shadow` targets all `<div>` elements with both `box` and `shadow` classes.
- No combinators are required; it combines the selectors directly.
4. **Complex Selectors**:
- A complex selector is a sequence of one or more simple and/or compound selectors that are separated by combinators, including the white space descendant combinator. A complex selector represents a set of simultaneous conditions on a set of elements.
- Combinators such as descendant ( ), child (`>`), adjacent sibling (`+`), and general sibling (`~`) are used to combine simple or compound selectors to form more complex rules.
- Examples:
    - `header h1` (descendant combinator) targets all `<h1>` elements inside `<header>`.
    - `.box > .shadow` (child combinator) targets `.shadow` elements that are direct children of `.box`.

Summary:

- **Simple Selector**: Targets elements based on a single criterion.
- **Compound Selector**: Combines multiple simple selectors without combinators (e.g., `.box.shadow` or `div#main.content`).
- **Combined Class Selector**: A specific type of compound selector that targets elements with multiple classes (e.g., `.box.shadow`).
- **Complex Selectors**: Use combinators to define relationships between elements (e.g., `header h1` or `.box > .shadow`).
## CSS Specificity
**Specificity** determines which CSS rules are applied when multiple rules target the same element. It's calculated based on the types of selectors used:

1. **Inline Styles**: 1000 points (highest priority).
2. **ID Selectors**: 100 points.
3. **Class Selectors, Attribute Selectors, and Pseudo-classes**: 10 points each.
4. **Element Selectors and Pseudo-elements**: 1 point each.

**More Specific Selectors** override less specific ones. For example, `#id .class p` is more specific than `.class p`, so it takes precedence.
## Attributes in Selectors
IDs and classes are technically attributes but have their own syntax. IDs use `#` and classes use `.` for targeting, whereas other attributes use square brackets `[]`.

**Selector Syntax**:
- **Classes and IDs**: Use `.` for classes and `#` for IDs directly in the selector. Example: `.class1`, `#id`.
- **Other Attributes**: Use `[attribute="value"]` syntax. Example: `[href="test"]`.
**Selector Order**:
- **Element First**: The selector must start with an element if combined with other types of selectors. Example: `a.class1` or `a[id="example"]`.
- **Order of Classes**: The order of classes in the HTML should match the order in the CSS if using `class="class1 class2"` with `a[class="class1 class2"]`.
**Performance**: Using `a.class1` is typically faster than `a[class="class1"]` because the latter involves attribute matching which is generally slower.
## Selector Categories
CSS selectors can be categorized in various ways, and the ones you mentioned cover a broad range of the available selectors. Here's a breakdown of the main types:
1. **Simple Selectors**
- **Type Selector**: Selects elements based on their tag name (e.g., `div`, `p`).
- **Class Selector**: Selects elements based on their class attribute (e.g., `.className`).
- **ID Selector**: Selects an element based on its ID attribute (e.g., `#idName`).
- **Attribute Selector**: Selects elements based on the presence or value of an attribute (e.g., `[type="text"]`).
- **Universal Selector**: Selects all elements (e.g., `*`).

2. **Compound Selectors**
- **Combined Class Selector**: Selects elements that have multiple classes (e.g., `.class1.class2`).
- **Combined ID and Class Selector**: Selects an element by combining ID, class, and other simple selectors (e.g., `div#id.class1`).

3. **Complex Selectors**
- **Descendant Combinator**: Selects elements that are descendants of a specified element (e.g., `div p`).
- **Child Combinator**: Selects direct children of a specified element (e.g., `div > p`).
- **Adjacent Sibling Combinator**: Selects an element that is the immediate sibling of another (e.g., `h1 + p`).
- **General Sibling Combinator**: Selects all siblings of an element (e.g., `h1 ~ p`).

4. **Universal Selector**
- **Universal Selector (`*`)**: Matches any element.

5. **Pseudo-Class Selectors**
- A **pseudo-class selector** is used in CSS to target elements based on their state or behavior, rather than their HTML structure. It allows you to style elements when they are in a specific condition, such as when they are being hovered over by a mouse, when they have been visited, or when they are the first child of a parent element.
- **Pseudo-class selectors** generally target elements based on dynamic states (like `:hover`, `:focus`) or specific conditions related to their position in the document (like `:first-child`, `:nth-child`). While many pseudo-classes respond to user interactions or changes in element states, others are indeed structural, depending on the HTML layout to apply styles.
- Two Types of Pseudo-Classes:
  **State-based Selectors**: Select elements based on their state (e.g., `:hover`, `:focus`, `:checked`).
  **Structural Selectors**: Select elements based on their position within the DOM (e.g., `:first-child`, `:nth-child`, `:last-child`).

6. **Pseudo-Element Selectors**
- A **pseudo-element selector** is used to style specific parts of an element, rather than the entire element itself. Pseudo-elements target specific portions of content within an element, such as the first letter, the first line, or content that is inserted before or after the element's main content.
- The `::` pseudo-element selector is used specifically on the last element in your CSS selector chain to style a specific part of that element. It doesn't help in navigating through elements in the DOM but rather targets a specific part (like `::before`, `::after`, `::first-letter`, etc.) of the final selected element.
- **Element Parts**: Select and style specific parts of an element (e.g., `::before`, `::after`, `::first-letter`, `::first-line`).

7. **Attribute Selectors**
- **Exact Attribute Selector**: Selects elements with a specific attribute value (e.g., `[type="text"]`).
- **Partial Attribute Selectors**: Select elements based on partial matches within an attribute (e.g., `[href^="http"]`, `[href$=".com"]`).

8. **Group Selectors**
- **Selector List**: Group selectors to apply the same style to multiple elements (e.g., `h1, h2, p`).

**Understanding the Hierarchy**
- **Simple Selectors** form the basis of more complex selectors.
- **Compound Selectors** and **Complex Selectors** build on simple selectors to target elements with more precision.
- **Pseudo-Class** and **Pseudo-Element Selectors** add specific conditions or target specific parts of elements.
- **Group Selectors** allow you to apply the same style to multiple elements efficiently.

This categorization helps in understanding how different selectors work and how they can be combined to target elements with increasing specificity.

CSS Selector Summary
When using selectors such as `nav ul li:last-child a`, the styling process involves:
**Hierarchy Definition**: Selectors are applied in a hierarchical manner. Each individual selector in the chain defines a step in the path from general to specific elements:
- **General to Specific**: Starting with broad elements (e.g., `nav`), moving through intermediate elements (e.g., `ul`, `li:last-child`), and ending with the final specific target (e.g., `a`).
**Applying Conditions**: Pseudo-classes and pseudo-elements refine the selection based on conditions (e.g., `:last-child`).
**Targeting the Element**: The last selector in the chain is the actual element that will be styled, based on the conditions defined by the preceding selectors.

**In Summary**: Each selector in the CSS chain defines part of the path to the final element. The overall selector works by progressively narrowing down from general elements to apply styles specifically to the last element in the chain.
# Bookmarks 

[Lorem Ipsum - All the facts - Lipsum generator](https://www.lipsum.com/) - генериране на random текст за тестови цели.

[CSS selectors - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Selectors) - CSS документация.

[HTML elements reference - HTML: HyperText Markup Language | MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Element)

[HTML basics - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/Getting_started_with_the_web/HTML_basics)

[Semantics - MDN Web Docs Glossary: Definitions of Web-related terms | MDN](https://developer.mozilla.org/en-US/docs/Glossary/Semantics)

[The W3C Markup Validation Service](https://validator.w3.org/)

[CSS Diner - Where we feast on CSS Selectors!](https://flukeout.github.io/) игра за упражнение на селекторите.

[Selectors Explained](https://kittygiraudel.github.io/selectors-explained/) - може да проверяваме какво точно селектират дадени селектори.

Course completion: 26.08.2024