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

`span` и `div` са без семантична стойност и са еквивалентни, но първия е инлайн а втория блоков елемент. Ползват се, ако искаме да направим структура от елементи, които да стилизираме. Може да правим, колкото искаме от тях. Специфичното е, че може да им дадем padding, margin, top и bottom, но няма да афектира layout-a на страницата.
## Display - inline-block
![](Pasted%20image%2020240831150936.png)

Дава ни възможност да сложим няколко елемента един до друг.
Позволява ни дадем padding, margin, top и bottom на инлайн елементи
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
# Bookmarks 
