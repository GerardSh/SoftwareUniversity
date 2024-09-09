# General
The Flexible Box Module - това е система от пропъртита, които описват логически как ние да разпределяме пространство на елементи, в 2D среда. Все едно да вземем лист хартия и да искаме да нарисуваме кутийки с най-различни размери. Чрез flexbox, много ефективно може да разделим пространството на листа. С други думи - това е система, която ни позволява да разпределим пространството на страницата. Занимава се с layout-a, кое колко да е голямо, позицията на елементите и тн. Може да работи хоризонтално и вертикално.
## The Flex Model
![](Pasted%20image%2020240909111017.png)

Флекс модела се състои от `flex container` и `flex items`. Може да зададем на даден елемент `diaplay: flex` и след това всички деца на този елемент става items, което ни позволява да им задаваме различни правила.

**Main axis** - основна кордината, която по подразбиране е хоризонтална.
**Cross axis** - основна кордината, която по подразбиране е вертикална.

Flexbox има огромно количество от пропъртита, като в 99% от времето се ползва не повече от 1/3.
## Container Properties
### Display - flex
![](Pasted%20image%2020240909111834.png)

[CSS Flexbox Layout Guide | CSS-Tricks](https://css-tricks.com/snippets/css/a-guide-to-flexbox/) -cheat sheet.
### Flex Direction
![](Pasted%20image%2020240909112250.png)

`flex-direction: row;`
В каква посока работи флекс бокса - хоризонтална от ляво на дясно или обратното,  вертикална от горе надолу или обратното. Може да сменяме посоката и axis-a.
### Flex Wrap
![](Pasted%20image%2020240909112826.png)

По подразбиране, стойността е `nowrap`, което казва, че нашите елементи никога няма да минат на нов ред.
Ако ползваме wrap - това ще позволи на елементите да паднат на нов ред. Може да ги обърнем с `wrap-reverse`. Обръща ги и от долу нагоре и почти никога не се ползва.
### Flex Flow
![](Pasted%20image%2020240909113151.png)
### Justify Content
Ползва се за изравняване по хоризонтала.

![](Pasted%20image%2020240909115134.png)

![](Pasted%20image%2020240909115325.png)

![](Pasted%20image%2020240909115304.png)

Може да сложим и space-evenly, което ще изравни разстоянията навсякъде, включително и началото и края, а не както при space-around.
### Align Items
Ползва се за изравняване по вертикала.

![](Pasted%20image%2020240909115716.png)

![](Pasted%20image%2020240909115854.png)

![](Pasted%20image%2020240909120238.png)

baseline - подрежда елементите по текста вътре, няма да гледа техния height.
### Align Content
Има значение, само когато имаме повече от един ред - `flex-wrap: wrap`. 
Ползва се много рядко.

![](Pasted%20image%2020240909121020.png)

![](Pasted%20image%2020240909121308.png)

![](Pasted%20image%2020240909121458.png)

![](Pasted%20image%2020240909121639.png)

![](Pasted%20image%2020240909121702.png)

![](Pasted%20image%2020240909121721.png)

![](Pasted%20image%2020240909121748.png)
## Children Properties
### Order
Може да подреждаме елементите както искаме. Source и визуалния order може да се различават.
Може да преместим всеки един от елементите, където искаме.

![](Pasted%20image%2020240909132723.png)

![](Pasted%20image%2020240909132924.png)
### Flex Grow
![](Pasted%20image%2020240909133048.png)

Контролираме логически елементите. По подразбиране, флекс бокс оразмерява кутийките спрямо съдържанието им. Може да кажем на даден елемент да порасне, ако има свободно пространство.
### Flex Shrink
![](Pasted%20image%2020240909133444.png)

![](Pasted%20image%2020240909133650.png)

Контролираме дали позволяваме на елемента да се смали.
Това и предишното пропърти, се ползват много често в комбинация с Flex Basis.
### Flex Basis
![](Pasted%20image%2020240909133709.png)

Би трябвало да замени width, когато казваме размери, предимно по хоризонтала.
### Flex
![](Pasted%20image%2020240909134106.png)

Бърз и удобен начин, да посочим и трите пропъртита, които казват на един елемент, колко да е голям.
## Align Self
![](Pasted%20image%2020240909135031.png)

![](Pasted%20image%2020240909135049.png)

Ползва се много рядко.
# Misc
# Styles Order
Имаме няколко нива на прилагане на CSS стилове:

1. **User agent styles** – това са вградените стилове, които браузърът по подразбиране прилага към елементите (най-ниското ниво).
2. **Нашите стилове (author styles)** – това са стиловете, които разработчикът задава, и те override-ват user agent стиловете.
3. **User setting styles (user styles)** – това са стиловете, зададени от потребителя в настройките на браузъра или чрез персонални стилове, и те могат да override-ват стиловете на разработчика.

Така че, **user styles** имат най-висок приоритет, след тях са **author styles**, и най-накрая са **user agent styles**.
# ChatGPT
## Main and Cross Axes
**Main Axis** (Controlled by `flex-direction`)

- **`justify-content`**:
    
    - **Purpose**: Aligns and distributes flex items **along the main axis**.
    - **Effect**: Determines how items are spaced out and aligned within the container along the main axis (horizontal if `flex-direction: row`, vertical if `flex-direction: column`).
    
    **Values**:
    
    - `flex-start`: Aligns items at the start of the main axis.
    - `flex-end`: Aligns items at the end of the main axis.
    - `center`: Centers items along the main axis.
    - `space-between`: Distributes items with space between them.
    - `space-around`: Distributes items with space around them.
    - `space-evenly`: Distributes items with equal space between and around them.

**Cross Axis** (Perpendicular to the Main Axis)

- **`align-items`**:
    
    - **Purpose**: Aligns flex items **along the cross axis**.
    - **Effect**: Determines how items are aligned and stretched across the cross axis (vertical if `flex-direction: row`, horizontal if `flex-direction: column`).
    
    **Values**:
    
    - `stretch` (default): Stretches items to fill the container's cross axis.
    - `flex-start`: Aligns items at the start of the cross axis.
    - `flex-end`: Aligns items at the end of the cross axis.
    - `center`: Centers items along the cross axis.
    - `baseline`: Aligns items based on their text baseline.

**Summary**

- **`justify-content`**: Aligns items along the main axis (distribution and spacing).
- **`align-items`**: Aligns items along the cross axis (vertical or horizontal alignment).

These properties are used to manage how items are arranged and aligned within a flex container, and they adapt based on the orientation of the main and cross axes.

## Positions Along the Axes

1. **Main Axis Positions**:
    
    - **`main-start`**: The beginning of the main axis.
        - For `flex-direction: row`, this is the left edge of the container.
        - For `flex-direction: column`, this is the top edge of the container.
    - **`main-end`**: The end of the main axis.
        - For `flex-direction: row`, this is the right edge of the container.
        - For `flex-direction: column`, this is the bottom edge of the container.
2. **Cross Axis Positions**:
    
    - **`cross-start`**: The beginning of the cross axis.
        - For `flex-direction: row`, this is the top edge of the container.
        - For `flex-direction: column`, this is the left edge of the container.
    - **`cross-end`**: The end of the cross axis.
        - For `flex-direction: row`, this is the bottom edge of the container.
        - For `flex-direction: column`, this is the right edge of the container.

**Key Flexbox Properties**

1. **Aligning Along the Main Axis** (`justify-content`):
    
    - **`flex-start`**: Aligns items to `main-start`.
    - **`flex-end`**: Aligns items to `main-end`.
    - **`center`**: Centers items along the main axis.
    - **`space-between`**: Distributes items with space between them.
    - **`space-around`**: Distributes items with space around them.
    - **`space-evenly`**: Distributes items with equal space around them.
2. **Aligning Along the Cross Axis** (`align-items`):
    
    - **`flex-start`**: Aligns items to `cross-start`.
    - **`flex-end`**: Aligns items to `cross-end`.
    - **`center`**: Centers items along the cross axis.
    - **`baseline`**: Aligns items based on their text baselines.
    - **`stretch`** (default): Stretches items to fill the container along the cross axis.

**Usage**

- **`start` and `end`** provide flexible, context-aware references that adapt to the layout direction and writing mode, making them more versatile than fixed edges (left/right or top/bottom).
- **Default Behavior**: In most cases, `flex-start` and `flex-end` align items to the edges of the container, but these references are adaptable to different flex directions and writing modes.

This summary should help you understand how `start` and `end` positions work in different flexbox layouts and how they relate to alignment properties.
## Inline Elements Behaving Like Block Elements in Flex Containers
- **Default Behavior**:
    
    - **Inline Elements**: By default, elements like `<span>` are inline and flow within text, not affecting the layout of surrounding elements.
    - **Block Elements**: Elements like `<div>` are block-level, meaning they start on a new line and span the full width available.
- **Flex Container Effect**:
    
    - When elements are placed inside a flex container (`display: flex`), they behave as flex items.
    - **Transformation**: Regardless of their original display type (`inline`, `inline-block`, `block`), all child elements of a flex container are treated as block-level within the flex context. They are laid out according to flexbox rules.
- **Implications**:
    
    - **Display and Sizing**: Inline elements like `<span>` will behave like block-level elements regarding layout and sizing within the flex container. They can have widths, heights, margins, and paddings applied, and they will respect flexbox properties like `justify-content` and `align-items`.
    - **Flexbox Control**: Flexbox properties such as `flex-direction`, `align-items`, and `justify-content` will apply to all children, regardless of their initial display type.

**Key Takeaway**: In a flex container, all child elements, including inline elements, are treated as flex items with block-level behavior, allowing for consistent application of flexbox layout properties.
## Managing Alignment of `inline-block` Elements
1. **Baseline Alignment**:
    
    - **Definition**: `inline-block` elements are aligned along their text baselines by default.
    - **Effect**: Margins and content height can shift elements vertically, affecting alignment with other `inline-block` elements.
2. **Adjusting Vertical Alignment**:
    
    - **`vertical-align` Property**: Controls vertical alignment of `inline-block` elements. Options include:
        - `top`: Aligns the top of the element with the top of the line box.
        - `middle`: Aligns the middle of the element with the middle of the line box.
        - `bottom`: Aligns the bottom of the element with the bottom of the line box.
        - `text-top` and `text-bottom`: Align with the top or bottom of the text.
3. **Using Flexbox or Grid Layout**:
    
    - **Flexbox**: Provides a flexible layout model with properties like `align-items` and `justify-content` for precise control over vertical and horizontal alignment.
    - **Grid Layout**: Offers a grid-based layout system with robust alignment features for both rows and columns.
4. **Using Positioning**:
    
    - **Relative Positioning**: Can be used to adjust the position of `inline-block` elements within their normal flow.
    - **Absolute Positioning**: Allows precise placement of elements relative to their containing block, bypassing baseline alignment issues.

By using these techniques, you can manage and override the default baseline alignment of `inline-block` elements, achieving more control over the layout and positioning of your elements.

# Bookmarks 

[CSS Flexbox Layout Guide | CSS-Tricks](https://css-tricks.com/snippets/css/a-guide-to-flexbox/) - cheat sheet.

[An Interactive Guide to Flexbox in CSS • Josh W. Comeau](https://www.joshwcomeau.com/css/interactive-guide-to-flexbox/)

[Flexbox Cheatsheet](https://codepen.io/kdankov/pen/QWoVyZJ) - интерактивен cheat sheet.

[CSS Flexbox Tutorial - Learn the right way - YouTube - FollowAndrew](https://www.youtube.com/watch?v=w9lsR2tvkvQ) 

[Font Awesome](https://fontawesome.com/) - **Font Awesome** is the Internet's icon library and toolkit, used by millions of designers, developers, and content creators.
