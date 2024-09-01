# General
## CSS Basic Box Model
![](Pasted%20image%2020240830232247.png)

HTML се състои от тагове, а таговете са елементи. Всеки един елемент е тип правоъгълник и има размери, затова се нарича box модел. Browser-a взимайки съдържанието на HTML и стиловете в CSS, трябва да прецени: 

Колко е голяма кутийката.
Разстоянието между съдържанието и border-a.
Разстоянието от border-a до останалите кутийки, къде се намира, колко е голямо и тн. 

Всичко опира до това - колко са ни големи елементите, къде се намират и афектират останалите елементи.

![](Pasted%20image%2020240831125925.png)

Margin: разстоянието отвън на кутийката.
This is the space outside the border of the element, creating distance between the element and other elements around it.

Border - разделя външната и вътрешната част на кутийката.
This surrounds the padding and content of the element, providing a line or edge that separates the content from the outside margin.

Padding - вътрешното разстояние между border-a и съдържанието.
This is the space inside the border, between the border and the content of the element. It provides spacing within the element to ensure that the content does not touch the border.

Element content - съдържанието.
This is the actual content inside the element, such as text, images, or other elements.
## Display
Това е много важно пропърти, което дефинира как ще се държи елемента, дали е Inline или block element. Най-общо - блоковете елементи са нещо като големи контейнери, докато инлайн елементите може да бъдат част от текст. Може да имаме много инлайн елементи един до друг и все едно са част от текста.

`display: block;` eлементът се държи като блоков елемент. Това означава, че заема цялата ширина на родителския контейнер и всеки следващ елемент ще се показва на нов ред. Автоматично създават нов ред преди и след тях и заемат цялото пространство по хоризонтала, което могат да заемат. Примери за блокови елементи са `<div>, <h1>, <p>`.

![](Pasted%20image%2020240831144234.png)

`display: inline;` eлементът се държи като инлайн елемент. Това означава, че заема само толкова ширина, колкото е необходима на съдържанието му, и не започва на нов ред. Ако един елемент може да бъде част от текста, то най-вероятно е инлайн. Примери за инлайн елементи са `<span>, <a>, <strong>, <img>`.

![](Pasted%20image%2020240831145100.png)

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

Ако при span selector-a добавим `display: inline-block;` получаваме нещо, което е по средата между двата свята. Елемента получава да е инлайн, но казваме да браузъра да вземе предвид и padding-а, който сме сложили и така може да направим блокче, само че вътре в текста.
## Display - inline-block
![](Pasted%20image%2020240831150936.png)

Дава ни възможност да сложим няколко елемента един до друг.
Позволява ни да дадем padding, margin, top и bottom на инлайн елементи.
## Width
Property с което може да зададем каква да е ширината на даден елемент.
Основните мерни единици са `pixels`, `em` и `rem`. Ако не декларираме width, по подразбиране заема цялата ширина. Ако искаме даден елемент да порасне в определени граници, може да ползваме `min-width` и `max-width`.
## Height
Това се ползва много рядко. Обикновено примерно слагаме текст, който се разпъва по width, колкото може и след това расте надолу на нов ред. Ние дефинираме размера по широчина, а количеството съдържание определя височината. По подразбиране height имат стойност auto -  ще расте заедно със съдържанието.
Отново имаме `min-height` и `max-height`.
## Margins and Paddings
![](Pasted%20image%2020240831180111.png)

![](Pasted%20image%2020240831180652.png)

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
## Border
![](Pasted%20image%2020240831213848.png)

Чрез това пропърти се настройва border-a на елемента.

`border: 10px solid #000` - първата стойност е дебелината, втората е стила / вида, а третата е цвета.
Това отново е shorthand, което е равносилно на:

```
border-width: 10px;
border-style: solid;
border-color: #000;
```
## What is the CSS box model?
![](Pasted%20image%2020240831214431.png)

![](Pasted%20image%2020240831214501.png)

![](Pasted%20image%2020240831214538.png)
## The standard CSS box model
При стандартния CSS box model, който е зададен с `box-sizing: content-box` (това е и стойността по подразбиране), браузърът калкулира ширината и височината на елемента, като включва само размера на съдържанието (`content`). **Padding** и **border** се добавят към тази стойност, което означава, че крайният размер на елемента ще бъде по-голям от зададения размер за `width` и `height`.

- Ако зададем `width: 350px`, това ще бъде само ширината на съдържанието.
- След това се добавят стойностите на `padding` и `border`.

**Крайна ширина на елемента:**

- Content width: 350px
- Padding: 20px отляво + 20px отдясно = 40px
- Border: 5px отляво + 5px отдясно = 10px
- **Обща ширина на елемента**: 350px + 40px + 10px = 400px

Това добавяне на `padding` и `border` към размера на елемента може да доведе до проблеми с общия размер на елементите в оформлението на страницата. За да се избегне това, може да се използва `box-sizing: border-box;`, което включва `padding` и `border` в зададената ширина и височина.
## The alternative CSS box model
Това е предпочитания модел. При него, когато кажем на браузъра, че искаме една кутийка да е 300px, след това независимо какъв padding сложим, кутийката ще остане 300px, но кутийката на content-a, ще се свие. 
Това се постига, чрез пропъртито `box-sizing` по малко по специфичен начин:

```
html {
  box-sizing: border-box;
}

*,
*:before,
*:after {
  box-sizing: inherit;
}
```

Чрез наследяването казваме всички елементи да наследят box-sizing, и така те ще стигнат до най-високото ниво -`<html>` от където ще наследят `box-sizing: border-box;` .  Ако искаме даден елемент да ползва друг box-sizing, може да го overrite-нем и да сложим друга стойност. Всички child елементи, на този елемент, ще ползват overrite-натата стойност. 
# Misc
## Semantic Tags
Семантичните тагове са важни, само когато ще публикуваме web site, който ще бъде достъпван от търсещи машини и тн. 
Когато правим апликация, не ни трябват, освен че ни помагат да се ориентираме в смисъла на кода, който пишем. Един добре подреден код, става по-лесен за навигация и разбиране. Ако слагаме само divider `<dvi>`  с класове, всичко изглежда еднакво и по-трудно за ориентиране. Добре е винаги да си структурираме семантично кода.
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
### Uniformity of HTML Elements with Default Property Values
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
### Inline Children Behavior
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
# Bookmarks 

