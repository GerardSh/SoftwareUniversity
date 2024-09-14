# General
The Flexible Box Module - това е система от пропъртита, които описват логически как ние да разпределяме пространство на елементи, в 2D среда. Все едно да вземем лист хартия и да искаме да нарисуваме кутийки с най-различни размери. Чрез flexbox, много ефективно може да разделим пространството на листа. С други думи - това е система, която ни позволява да разпределим пространството на страницата. Занимава се с layout-a, кое колко да е голямо, позицията на елементите и тн. Може да работи хоризонтално и вертикално.
## The Flex Model
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909111017.png)

Флекс модела се състои от `flex container` и `flex items`. Може да зададем на даден елемент `diaplay: flex` и след това всички деца на този елемент става items, което ни позволява да им задаваме различни правила.

**Main axis** - основна кордината, която по подразбиране е хоризонтална.
**Cross axis** - основна кордината, която по подразбиране е вертикална.

Flexbox има огромно количество от пропъртита, като в 99% от времето се ползва не повече от 1/3.
## Container Properties
### Display - flex
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909111834.png)

[CSS Flexbox Layout Guide | CSS-Tricks](https://css-tricks.com/snippets/css/a-guide-to-flexbox/) -cheat sheet.
### Flex Direction
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909112250.png)

`flex-direction: row;`
В каква посока работи флекс бокса - хоризонтална от ляво на дясно или обратното,  вертикална от горе надолу или обратното. Може да сменяме посоката и axis-a.
### Flex Wrap
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909112826.png)

По подразбиране, стойността е `nowrap`, което казва, че нашите елементи никога няма да минат на нов ред.
Ако ползваме wrap - това ще позволи на елементите да паднат на нов ред. Може да ги обърнем с `wrap-reverse`. Обръща ги и от долу нагоре и почти никога не се ползва.
### Flex Flow
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909113151.png)
### Justify Content
Ползва се за изравняване по хоризонтала.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909115134.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909115325.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909115304.png)

Може да сложим и space-evenly, което ще изравни разстоянията навсякъде, включително и началото и края, а не както при space-around.
### Align Items
Ползва се за изравняване по вертикала.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909115716.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909115854.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909120238.png)

baseline - подрежда елементите по текста вътре, няма да гледа техния height.
### Align Content
Има значение, само когато имаме повече от един ред - `flex-wrap: wrap`. 
Ползва се много рядко.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121020.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121308.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121458.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121639.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121702.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121721.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909121748.png)
## Children Properties
### Order
Може да подреждаме елементите както искаме. Source и визуалния order може да се различават.
Може да преместим всеки един от елементите, където искаме.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909132723.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909132924.png)
### Flex Grow
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909133048.png)

Контролираме логически елементите. По подразбиране, флекс бокс оразмерява кутийките спрямо съдържанието им. Може да кажем на даден елемент да порасне, ако има свободно пространство.
### Flex Shrink
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909133444.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909133650.png)

Контролираме дали позволяваме на елемента да се смали.
Това и предишното пропърти, се ползват много често в комбинация с Flex Basis.
### Flex Basis
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909133709.png)

Би трябвало да замени width, когато казваме размери, предимно по хоризонтала.
### Flex
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909134106.png)

Бърз и удобен начин, да посочим и трите пропъртита, които казват на един елемент, колко да е голям.
### Align Self
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909135031.png)

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240909135049.png)

Ползва се много рядко.
## Centering Elements Vertically and Horizontally with Flexbox
Чрез flex, много лесно може да се позиционира даден child елемент в центъра на parent елемент.

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Baseline Example</title>
    <style>
        
        body {
            height: 500px;
            display: flex;
            border: 1px solid black;
        }
        
        div {
            border: 1px solid black;
            max-width: 500px;
            margin: auto;     
        }
        
    </style>
</head>
<body>
    
    <div>
        <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Numquam est atque inventore earum, sit pariatur cumque nihil repellat, esse maiores deleniti perferendis, enim iste amet? Cupiditate minus optio reiciendis est.</p>
    </div>
    
</body>
</html>
```

`margin: auto` работи, само ако parent елемента има зададена височина и е `display: flex`, иначе би подравнил child елемента, само по хоризонтала. Ако не искаме да ограничим височината на parent елемента, може да ползваме `vh` - view port-a в комбинация с `min-height`.

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Baseline Example</title>
    <style>
        
        body {
            display: flex;
            border: 1px solid black;
            min-height: 100vh;
        }
        
        div {
            border: 1px solid black;
            max-width: 500px;
            margin: auto;     
        }
        
    </style>
</head>
<body>
    
    <div>
        <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Numquam est atque inventore earum, sit pariatur cumque nihil repellat, esse maiores deleniti perferendis, enim iste amet? Cupiditate minus optio reiciendis est.</p>
    </div>
    
</body>
</html>
```

Така child елемента ще бъде винаги позициониран в средата на view-porta. Слагаме `min-height` вместо само `height`, защото ако сложим `height: 100vh` то големината на parent елемента ще бъде само размера на екрана и ако съдържанието е по-голямо от този размер, ще прелее извън него.
Вместо `margin: auto` в child елемента, може да ползваме `align-items: center` и `justify-content: center` в parent-а, което пак ще центрира child елемента в средата на екрана. Ако има повече от един child елемент, тогава ще има разлика, кой от двата начина се използва.
# Misc
# Styles Order
Имаме няколко нива на прилагане на CSS стилове:

1. **User agent styles** – това са вградените стилове, които браузърът по подразбиране прилага към елементите (най-ниското ниво).
2. **Нашите стилове (author styles)** – това са стиловете, които разработчикът задава, и те override-ват user agent стиловете.
3. **User setting styles (user styles)** – това са стиловете, зададени от потребителя в настройките на браузъра или чрез персонални стилове, и те могат да override-ват стиловете на разработчика.

Така че, **user styles** имат най-висок приоритет, след тях са **author styles**, и най-накрая са **user agent styles**.
# ChatGPT
## Element Declared as Flex

When You Declare an Element as `display: flex` (Default: `flex-direction: row`):

1. **Flex Container's Size by Default:**
    
    - The container itself will take the size of its content by default, unless constrained by a specific width or height.
2. **Flex Items Inside the Container:**
    
    - **Height of Flex Items:**
        - All the flex items will have the same height, **because of the default `align-items: stretch` property**. This means they will stretch to match the height of the tallest flex item, or to fill the container's height, if the container has a set height.
    - **Width of Flex Items:**
        - Each flex item will take up the width required by its content, unless flex properties like `flex-grow`, `flex-shrink`, or `flex-basis` are applied.
        - In the default row direction (`flex-direction: row`), the width of each item is independent and based on its content. They do **not** stretch in the horizontal direction unless specified.

**Key Points:**

- **Stretching of Height:** By default, flex items stretch in height due to `align-items: stretch`. They all get the same height, which is determined by either the tallest item or the container height.
- **Independent Widths:** The width of each flex item is determined by the content inside each one, so unless modified by flex properties, each item’s width is independent.

**Example:**

```
.container {
  display: flex;
  /* Default: flex-direction: row; */
  height: 300px; /* Fixed height for the container */
}

.container div {
  background: lightblue;
  padding: 10px;
}
```

In this case:

- **Height:** All `<div>` elements will stretch to be 300px in height, since the container has a fixed height and `align-items: stretch` is the default.
- **Width:** Each `<div>` will only be as wide as the content inside it unless additional flex properties are applied.

**Column Direction (`flex-direction: column`):**

If you change the direction to column, the behavior flips:

- **Width of Flex Items:** They will all stretch to the full width of the container.
- **Height of Flex Items:** Each item’s height will depend on its content unless you modify it with flex properties like `flex-grow`.

**Summary:**

- **Flex Container:** By default, it takes the size of its content.
- **Flex Items:**
    - In row direction: They have the same height (due to `align-items: stretch`) and independent widths (based on content).
    - In column direction: They have the same width (due to `align-items: stretch`) and independent heights (based on content).
## Centering Elements Vertically and Horizontally with Flexbox
- **Centering with Flexbox**: Flexbox is indeed a powerful tool for centering elements both horizontally and vertically. By setting the parent container to `display: flex`, you can easily align its child elements.
    
- **`margin: auto` for Horizontal Centering**: When using `display: flex` on a parent container, `margin: auto` on a child element horizontally centers it. For vertical centering, this approach alone is not sufficient.
    
- **Parent Element’s Height**: For vertical centering with Flexbox, the parent element must have a defined height. This can be done using `height`, `min-height`, or viewport units (`vh`).
    
- **`min-height` vs `height`**: Using `min-height: 100vh` ensures that the parent container takes up at least the full height of the viewport but can expand if the content exceeds this height. This prevents content from overflowing and keeps it centered relative to the viewport size.
    
- **Avoiding Overflow**: Setting a fixed `height` may cause overflow issues if the content exceeds the height of the viewport. Using `min-height` ensures that the container can grow with the content while still centering it initially.
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
## Difference between align-content and align-items
The difference between `align-content` and `align-items` in CSS lies in their application and function within Flexbox and Grid layouts:

1. **`align-items`**:
    
    - **Purpose**: Aligns flex or grid items along the cross axis (the perpendicular axis to the main axis).
    - **Applies to**: Individual items inside a flex or grid container.
    - **Effect**: It determines how **each item** is aligned within the flex container or grid along the cross axis (e.g., vertically in a row layout, or horizontally in a column layout).
    - **Example**: If you want all items to be vertically centered within their flex container, you would use `align-items: center;`.
    
2. **`align-content`**:
    
    - **Purpose**: Aligns the flex or grid lines themselves (the entire set of items) along the cross axis.
    - **Applies to**: Only when there are **multiple lines** of items (i.e., when `flex-wrap` is used in Flexbox or when multiple rows/columns exist in a Grid layout).
    - **Effect**: It determines how **the group of lines** is aligned within the container. If the flex items are wrapped onto multiple lines, `align-content` controls the alignment of those lines in the container.
    - **Example**: If you have wrapped lines and want to distribute them evenly along the vertical axis of the container, you would use `align-content: space-between;`.

**Key Distinction:**

- `align-items` controls the alignment of **individual items** within a line.
- `align-content` controls the alignment of **lines of items** within the container.

If there's only one line of items, `align-content` won’t have any effect. When there is **only one row**, `align-items` is the property that controls the vertical alignment of items within that single row. `align-content` won't have any effect in this case because there's no need to align multiple rows—the container has only one.

However, **when there are multiple rows** (due to `flex-wrap: wrap;`), the container's vertical space is divided into sections representing each row. At this point, `align-content` becomes useful because it allows you to control how those **rows as a group** are aligned inside the container.

For example:

- If you have **two rows**, `align-content` can:
    - **`flex-start`**: Push both rows to the top.
    - **`flex-end`**: Push both rows to the bottom.
    - **`center`**: Center the rows in the middle of the container.
    - **`space-between`**: Distribute the rows so the first one is at the top and the second one is at the bottom.
    - **`space-around`** or **`space-evenly`**: Add equal spacing between the rows.

Meanwhile, within each row, `align-items` continues to affect how the **individual items** are aligned within their respective row.

**Summary**

- **One row**: Only `align-items` matters.
- **Two rows**: `align-items` aligns the items in each row, and `align-content` positions the rows relative to the container as a whole.
## Flex Items Behavior
You

Making a tag flex is a fast way to make all child elements inline blocks in a way. If we say direction column then it means all the tags will behave like block elements.

ChatGPT

Yes, you’re on the right track. Here’s a more detailed breakdown:

**Flexbox as an Inline-Block Equivalent**

1. **Flex Container in Row Direction (default):**
    
    - **Flex Items as Inline-Block:** By default, a flex container lays out its children (flex items) in a row direction. If you don't apply `flex-grow`, `flex-shrink`, or `flex-basis`, flex items will behave similarly to inline-block elements. They will be placed next to each other and will only take up as much width as their content requires. The flex container itself can handle the spacing and alignment of these items.
2. **Flex Container in Column Direction:**
    
    - **Flex Items as Block Elements:** When you set `flex-direction: column`, the flex items are laid out in a column, similar to block elements. Each item will be stacked vertically and will take up the full width of the container (unless width is restricted). The height of each item will only be as much as its content unless you specify `height` or use flex properties to manage it.

**Key Points**

- **Inline-Block Behavior:** Flex items in row direction without specific flex properties do resemble inline-block elements in that they flow horizontally and only occupy the space required by their content. However, they also benefit from flexbox alignment properties (`justify-content`, `align-items`, etc.) for more control over their placement.
    
- **Block-Like Behavior in Column Direction:** When you switch to column direction, flex items behave like block elements. They stack vertically and can expand to fill the container’s width, with their height based on their content unless otherwise specified.

**Key Differences**

- **Flexbox (`row` Direction):** Flex items can grow or shrink to fill the available space based on the flex properties applied. This is more flexible than `inline-block`, which does not inherently adapt to changes in container size.
    
- **Flexbox (`column` Direction):** Flex items stack vertically and can expand to fill the available height, offering similar behavior to block elements but with additional control over how space is distributed.

**Summary**

- **Using Flexbox for Inline-Block Layouts:** Setting `display: flex` on a container can indeed provide a quick way to achieve a layout where children behave like inline-block elements, with the added advantage of flexible alignment and spacing control.
    
- **Using Flexbox for Block Layouts:** Switching to `flex-direction: column` allows you to stack elements like block elements, with the ability to manage alignment and spacing more dynamically.

Flexbox offers more powerful and flexible layout options compared to simple inline-block or block styling, allowing for more complex and responsive designs.
## Flex Empty Item Containers
Flexbox behaves differently from block-level elements when it comes to handling empty containers and content overflow. Here’s a clearer explanation of the two scenarios:
1. **Flexbox Behavior:**

- **Empty Flex Items**: Flexbox will shrink empty items that would otherwise extend beyond the container's borders. Even if you set a large `width` or other styles for the flex item, if there's no content inside, the flex item will adjust (shrink) to fit within the flex container based on its flex rules, such as `flex-grow`, `flex-shrink`, and `flex-basis`. This makes it very space-efficient.
    
- **Overflow with Content**: Flexbox allows an item to grow or shrink based on the content inside. If the content inside the item is too large (like long text), the flex item will expand and, if necessary, overflow the flex container. This happens when `flex-shrink` is set to `0` or when the content is too large to fit, and the container can't compress further.

```
<div class="flex-container">
    <div class="flex-item">Short</div>
    <div class="flex-item">This is a long string of text that causes overflow</div>
</div>
```

Here, the second item will grow, and if it’s too large, it will overflow the flex container, but this only happens if there’s actual content to cause the overflow.

2. **Block-Level Behavior:**

- **Empty Block Elements**: Block elements generally expand to their full width by default, whether they contain content or not. If you set a large `width` on a block-level element, its borders will extend to the defined width, even if it is empty.
    
- **Overflow with Content**: When a block-level element contains content that exceeds the width of its container, it will overflow naturally without shrinking. Block-level elements do not have the same dynamic shrinking behavior as flex items. Overflow happens whether the content is small or large, and no automatic adjustments are made.

**Key Differences:**

- **Flex items are dynamic**: They grow or shrink based on content and the space available within the flex container. An empty flex item will shrink to avoid wasting space.
- **Block elements are static**: They maintain their defined width even when empty, and they will overflow the container when the content exceeds the container’s width.

**Inline Elements Behaving Like Block Elements in Flex Containers**
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
## Flex Grow
Let’s break down how `flex-grow` works in Flexbox. This property determines how much a flex item will grow relative to the other flex items inside the same container when there's extra space available.

**How `flex-grow` Works:**

- **`flex-grow`** is a unitless number (often referred to as a "growth factor").
- It defines the proportion of the available space (after taking into account `padding`, `border`, and `margin`) that the flex item should take up **in relation to the other flex items**.
- The higher the `flex-grow` value, the more space the item will occupy in comparison to other flex items in the container.

**Example:**

```
.flex-item {
    flex-grow: 1; /* Default grow factor */
}
```

- If all items inside a flex container have `flex-grow: 1`, then all items will grow equally and divide any extra space evenly.
- If one item has a `flex-grow` value higher than the others, it will take up a larger portion of the available space.

**Let's break it down with a simple scenario:**

Imagine you have a flex container with 3 items inside, and the container has more space than the total of the items' width (or height if the flex direction is set to `column`).

```
<div class="flex-container">
  <div class="flex-item" style="flex-grow: 1;">Item 1</div>
  <div class="flex-item" style="flex-grow: 2;">Item 2</div>
  <div class="flex-item" style="flex-grow: 3;">Item 3</div>
</div>
```

**In this case:**

- **Item 1**: `flex-grow: 1`
- **Item 2**: `flex-grow: 2`
- **Item 3**: `flex-grow: 3`

Here’s how it works:

1. **Total available space** is calculated after accounting for all fixed dimensions (widths, margins, etc.).
2. **Sum of the grow factors**: 1 (Item 1) + 2 (Item 2) + 3 (Item 3) = 6.
3. Now, Flexbox takes the available space and divides it into 6 equal parts (because the total grow factor is 6).
4. **Item 1** gets 1 part (1/6th) of the available space.
5. **Item 2** gets 2 parts (2/6th) of the available space.
6. **Item 3** gets 3 parts (3/6th) of the available space.

So, **Item 3** will be twice the width of **Item 1**, and **Item 2** will be in between, growing proportionally based on their `flex-grow` values.

**Important Points to Remember:**

- The `flex-grow` property only applies if there is extra space to distribute. If the content of the items already fills up the flex container, `flex-grow` won’t have any effect.
- The value is relative, so `flex-grow: 2` doesn't mean twice the size of the item, it means "grow twice as fast" as other items that have `flex-grow: 1`.

**Visual Example:**

- If you have a 600px wide flex container and 3 items:
    - Item 1 (`flex-grow: 1`)
    - Item 2 (`flex-grow: 2`)
    - Item 3 (`flex-grow: 3`)

If the total content inside the items uses only 300px, that leaves 300px of extra space. Flexbox will distribute this space proportionally based on the `flex-grow` values:

- **Item 1** gets 1/6 of the extra space: 50px.
- **Item 2** gets 2/6 of the extra space: 100px.
- **Item 3** gets 3/6 of the extra space: 150px.

So, after distributing the extra space, the final widths of the items will be:

- **Item 1**: initial width + 50px.
- **Item 2**: initial width + 100px.
- **Item 3**: initial width + 150px.

**Summarizing:**

- **`flex-grow: 0`**: The item will not grow at all (default).
- **`flex-grow: 1`**: The item will grow to take up any remaining space equally with other flex items.
- **`flex-grow: n`**: The item will grow proportionally to the other items based on the value of `n`.
## Flex Shrink
The `flex-shrink` property in Flexbox controls how flex items shrink relative to each other when there isn't enough space in the flex container. It's used to determine how items should reduce in size if the container is too small to fit all items at their initial sizes.

**Basic Syntax**

```
.flex-item { flex-shrink: <number>; }
```

- **`<number>`**: This value determines how much the item will shrink relative to other items. The default value is `1`.

**How `flex-shrink` Works**

1. **Initial Sizes**:
    
    - Flex items are sized according to their initial widths (or heights, in case of a column layout) and any specified `flex-basis`.
2. **Determine Available Space**:
    
    - The flex container calculates how much space is available by subtracting the total width of the flex items (including margins and paddings) from the width of the container.
3. **Calculate Shrinkage**:
    
    - If the total width of the flex items exceeds the width of the flex container, the items will shrink to fit within the container.
    - The `flex-shrink` property determines how much each item will shrink relative to other items.

**Example**

Given the following setup:

```
<div class="flex-container">
  <div class="flex-item" style="flex-shrink: 1;">Item 1</div>
  <div class="flex-item" style="flex-shrink: 2;">Item 2</div>
  <div class="flex-item" style="flex-shrink: 1;">Item 3</div>
</div>
```

And CSS:

```
.flex-container {
  display: flex;
  width: 400px;
}

.flex-item {
  flex-basis: 200px; /* Initial size of each item */
  border: 1px solid #000;
}
```

**How It Works**

1. **Initial Sizes**:
    
    - Each item has an initial size of `200px` (as specified by `flex-basis`), so the total initial width is `600px` (3 items * 200px).
2. **Available Space**:
    
    - The container width is `400px`, so the items need to shrink by `200px` (`600px - 400px`).
3. **Apply `flex-shrink`**:
    
    - **Item 1** and **Item 3** have `flex-shrink: 1`, meaning they will shrink equally.
    - **Item 2** has `flex-shrink: 2`, meaning it will shrink twice as much as Item 1 and Item 3.
4. **Distribution of Shrinkage**:
    
    - Total shrink factor = `1 (Item 1) + 2 (Item 2) + 1 (Item 3) = 4`
    - Available space to shrink = `200px`
    - **Item 1** and **Item 3** will each shrink by `(1 / 4) * 200px = 50px`
    - **Item 2** will shrink by `(2 / 4) * 200px = 100px`

**Resulting Sizes**

- **Item 1**: `200px (initial) - 50px (shrinkage) = 150px`
- **Item 2**: `200px (initial) - 100px (shrinkage) = 100px`
- **Item 3**: `200px (initial) - 50px (shrinkage) = 150px`

**Key Points**

- **Default Value**: `flex-shrink` is `1` by default, which means items will shrink equally if necessary.
- **Higher Values**: Items with a higher `flex-shrink` value will shrink more compared to items with a lower value.
- **Zero Value**: Setting `flex-shrink: 0` means the item will not shrink, and overflow will occur if the total width of the items exceeds the container’s width.
## Understanding `flex-basis` vs `width` in Flexbox

1. **`flex-basis`**: Defines the initial size of a flex item before any `flex-grow` or `flex-shrink` adjustments. It is used to set the size of the item along the main axis in the flex container's direction. The dimension affected by `flex-basis` changes based on the `flex-direction` property.
    
2. **`width`**: Sets a fixed size for the flex item. It is always applied along the main axis regardless of the `flex-direction`.

**Example:**

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Flexbox Width vs Flex-Basis</title>
    <style>
        .flex-container {
            display: flex;
            border: 2px solid blue;
            width: 600px; /* Container width is fixed */
            flex-direction: column; /* Flex direction is column */
        }
        
        .flex-item {
            flex-grow: 1; /* Items grow to fill available space */
            flex-shrink: 1; /* Items shrink if necessary */
        }

        /* Using flex-basis */
        .flex-item-basis {
            flex-basis: 200px; /* Initial height of 200px */
        }

        /* Using width */
        .flex-item-width {
            width: 200px; /* Fixed width of 200px */
        }
    </style>
</head>
<body>
    <h2>Using Flex-Basis</h2>
    <div class="flex-container">
        <div class="flex-item flex-item-basis">Item 1</div>
        <div class="flex-item flex-item-basis">Item 2</div>
        <div class="flex-item flex-item-basis">Item 3</div>
    </div>

    <h2>Using Width</h2>
    <div class="flex-container">
        <div class="flex-item flex-item-width">Item 1</div>
        <div class="flex-item flex-item-width">Item 2</div>
        <div class="flex-item flex-item-width">Item 3</div>
    </div>
</body>
</html>
```

**Explanation**

- **`flex-basis`**: Defines the initial size of each flex item along the main axis, which is vertical in this case due to `flex-direction: column`. Here, `flex-basis: 200px` sets the initial height of each item to 200px. Items will grow or shrink to fit the container's height.
    
- **`width`**: Sets a fixed width for each flex item, which affects the size along the main axis. With `flex-direction: column`, the `width` property does not impact the height of items. Each item has a fixed width of 200px, but height adjustments are controlled by `flex-grow` and `flex-shrink`.

**Summary**

- **`flex-basis`** affects the dimension along the main axis based on the current `flex-direction`. In this example, it controls the height because the flex direction is column.
- **`width`** sets a fixed size along the main axis, and in a column layout, it will be the width of the items, not their height.
## `align-self: baseline`
When you use `align-self` on a flex item, it overrides the `align-items` value for that specific item. 
- **Purpose**: Aligns the baseline of a flex item with the baseline of other items that also use `align-self: baseline`. The baseline is typically the line upon which text sits.
    
- **Behavior**:
    
    - **When Multiple Items Use `align-self: baseline`**: The baselines of these items will align with each other.
    - **When No Other Items Use `align-self: baseline`**: The item aligns its baseline relative to the container's cross-axis.
- **Effect of Font Size and Padding**:
    
    - Items with different font sizes or padding will have their text baselines aligned according to their relative baseline positions.

**Example with CSS and HTML**

Here’s a concise example demonstrating how `align-self: baseline` works:

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Align-Self Baseline Example</title>
    <style>
        .flex-container {
            display: flex;
            border: 2px solid blue;
            width: 600px;
            height: 200px;
            flex-direction: row; /* Row direction */
            align-items: flex-start; /* Default alignment */
        }
        
        .flex-item {
            border: 2px solid #000;
            background: #eee;
            padding: 10px;
        }

        .align-self-baseline .flex-item:nth-child(1) {
            font-size: 20px;
            align-self: baseline;
        }

        .align-self-baseline .flex-item:nth-child(2) {
            font-size: 25px;
            align-self: baseline;
        }

        .align-self-baseline .flex-item:nth-child(3) {
            font-size: 30px;
            align-self: baseline;
        }

        .align-self-baseline .flex-item:nth-child(4) {
            padding: 30px;
            align-self: baseline;
        }

        .align-self-baseline .flex-item:nth-child(5) {
            align-self: baseline;
        }
    </style>
</head>
<body>
    <h2>Align-Self: Baseline Example</h2>
    <div class="flex-container align-self-baseline">
        <div class="flex-item">Item 1</div>
        <div class="flex-item">Item 2</div>
        <div class="flex-item">Item 3</div>
        <div class="flex-item">Item 4</div>
        <div class="flex-item">Item 5</div>
    </div>
</body>
</html>
```

**Explanation of the Example**

- **Flex Container**: The flex container is set to `display: flex` with `flex-direction: row` and `align-items: flex-start`.
    
- **Flex Items**:
    
    - **Items 1 to 5**: All items use `align-self: baseline`.
    - **Different Font Sizes**: Items have different font sizes, so their baselines will align according to their respective text baselines.
    - **Padding**: Item 4 has extra padding, which affects its visual alignment, but the baseline alignment is still respected.

In this example, you’ll see that all items with `align-self: baseline` align their baselines with each other, even if they have different font sizes and padding.

**first / last baseline**
`baseline` (shorthand for `first baseline`) aligns flex items based on the first line of text in each item, while `last baseline` aligns items based on the last line of text. If an item is aligned to `first baseline`, it will not align with other items using `last baseline`, since they are based on different baselines within the text.
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
## Line Box and Baseline Relation
the baseline is not necessarily at the bottom of the line box. Here's how they relate:

**Line Box**

- **Definition**: The line box is the container for inline-level elements within a block of text. It stretches to accommodate the height of the tallest element or the line-height of the text.
- **Height**: The height of the line box is determined by the tallest element within it. This includes any inline elements and their line-height.

**Baseline**

- **Definition**: The baseline is a horizontal line upon which most text characters sit. It is the reference point for aligning text and inline-level elements.
- **Position**: The baseline is generally above the bottom of the line box, not at the bottom. It is where the bottom of the text characters align.

**Relationship**

- **Alignment**: Inline-level elements are aligned relative to the baseline of the line box. Elements with `vertical-align: baseline` align their baselines with the baseline of the line box.
- **Visual Layout**: The baseline is used to align text and inline elements so that they appear consistently across different lines of text. The actual position of the baseline within the line box depends on the font and the text’s line-height.

**Visual Representation**

Here’s a simplified representation:

```
+--------------------+  <- Top of the line box (determined by the tallest element)
|                    |
|  Text              |
|  with              |
|  different heights |
|                    |
|                    |
| Baseline           |  
+--------------------+  <- Baseline (where text aligns)
|                    |
|                    |
+--------------------+  <- Bottom of the line box (lowest point of the line box)

- Top of the Line Box: This is defined by the tallest inline element in the line.
- Baseline: This is where the baseline of the text aligns, not necessarily at the bottom of the line box.
- Bottom of the Line Box: This is the lowest part of the line box, accommodating any descenders or additional space below the text.
```

- **Line Box Height**: The height of the line box includes all the space from the top to the bottom of the tallest element.
- **Baseline Position**: The baseline is typically found somewhere above the bottom of the line box, where the characters align.

In summary, the baseline is a reference line within the line box where text and inline elements align. It is not positioned at the bottom of the line box but is a crucial alignment point within the vertical space defined by the line box. The position of the baseline is not directly controlled by CSS properties; it is determined by the font metrics and the content of the text. However, you can influence the vertical alignment of elements relative to the baseline using the `vertical-align` property.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240910225614.png)

[html - Vertical align not working on inline-block - Stack Overflow](https://stackoverflow.com/questions/35529582/vertical-align-not-working-on-inline-block)

- **Single Inline Element:**
    - When you have a single inline element (such as a single word or piece of text), it forms a **line box**. This line box holds the content (text) within it, and it expands vertically to fit the content inside it.
- **Multiple Inline Elements:**
    - When multiple inline or inline-level elements (such as `<span>`, `<a>`, or even text nodes) are placed within the same containing block, they each create **individual line boxes** for themselves. However, **these individual line boxes are grouped into a single larger line box** that covers all the inline elements on that line.
    - This **larger line box** will adjust its height based on the tallest inline element within it (as you mentioned before).

```
<p>
  <span>Short text</span>
  <img src="image.jpg" alt="Image" style="vertical-align: middle;">
  <span>Another text</span>
</p>
```

- In this case, each `<span>` and the `<img>` create their own **individual line boxes**.
- However, these individual line boxes are wrapped into **one larger line box** for the entire line of content.
- The height of this larger line box is determined by the tallest element on the line (in this case, it could be the image or the tallest text element depending on their respective sizes).
- Vertical alignment (e.g., `vertical-align: middle`) is applied relative to this larger line box.

**Line Box Behavior Recap:**

- A **line box** is essentially the horizontal box that wraps around inline-level content.
- If there is a single inline element, it occupies a single line box.
- When there are multiple inline elements, each has its own individual line box, but together they form one **larger line box** that spans the entire line, and its height is determined by the tallest element inside.

This concept is crucial for understanding how text and inline elements are aligned and how they interact when positioned next to one another.
## Vertical Alignment and Baseline
When text breaks into multiple lines within an inline or inline-block element, the **baseline** of that element is determined by the **last line of text**.

In detail:

- Each line of text in a multi-line inline element has its own baseline.
- The baseline for the whole element, when used in a layout, will be the baseline of the **last line of text**.

For example, if you have a `span` or `div` containing text that wraps onto several lines, the entire element's baseline is aligned according to the baseline of the text in the last line, not the first.

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Baseline Example</title>
    <style>
        .multi-line {
            display: inline-block;
            width: 150px;
            font-size: 16px;
            border: 1px solid black;
            vertical-align: baseline;
        }

        .single-line {
            display: inline-block;
            width: 100px;
            font-size: 16px;
            border: 1px solid red;
            vertical-align: baseline;
        }
    </style>
</head>
<body>

    <span class="multi-line">This is some text that wraps onto multiple lines</span>
    <span class="single-line">Single line</span>

</body>
</html>
```

In this example:

- The `multi-line` span will have its baseline aligned based on the last line of text (which wraps to the next line due to the narrow width).
- The `single-line` span will have its baseline determined by the single line of text.

The result is that the baseline of the `multi-line` span will be lower than that of the `single-line` span because it is based on the last line of wrapped text.
## Inline Elements Vertical Alignment
1. **Baselines of Elements**:
    
    - Every inline-level or inline-block element has its own baseline, which typically corresponds to the bottom of the text inside the element. For elements with text that wraps over multiple lines, the baseline is determined by the last line of text.
    - When multiple elements are placed within the same line, their individual baselines are considered for vertical alignment, influencing how elements are positioned relative to each other within the line box.
    - Other elements, such as images or inline-block elements with no text, can have their baseline defined differently (e.g., by the bottom margin edge in the case of images).
1. **Vertical Alignment and Line Box Behavior**:
    
    - The **line box adjusts its height** based on the tallest element it contains. This tallest element establishes the height of the line box.
    - **Top, Middle, and Bottom Points**:
        - The top, middle, and bottom points (for `vertical-align: top`, `vertical-align: middle`, and `vertical-align: bottom`) are defined relative to the tallest element in the line. These reference points are the same for all elements because the line box uses the tallest element to establish its boundaries.
        - For example, when aligning an element to the top, all elements within the line will align relative to the top of the line box (which corresponds to the tallest element).
        - The key point here is that the tallest element establishes a sort of reference for alignment for the other elements.
1. **Aligning the Top of One Element with the Bottom of Another**:
    
    - If you attempt to align the **top of a smaller element** with the **bottom of the tallest element** in the line (using, for instance, `vertical-align: top` on one element and `vertical-align: bottom` on another), it **cannot happen**. This is because it would require the smaller element to move **above** the top boundary of the line box, which is not allowed.
    - The line box ensures that all elements stay within its boundaries, so vertical alignment like this is not possible. Instead, elements are kept within the box, and alignment rules are applied accordingly. 
    - The line box maintains its height based on the tallest element, and all vertical alignments occur within those bounds.
1. **Aligning Baselines and Middle Points**:
    
    - You **can align** the **baseline of a smaller element** with the **middle point** of a larger element. This is achievable because the alignment is happening within the line box, respecting its boundaries.
    - Similarly, you can align the **baseline of the smaller element** with the **middle point** of the larger element or align the **middle points of both elements** (`vertical-align: middle` on both). These configurations work because all of this alignment occurs within the borders of the line box, and the elements don’t need to move outside the line box to achieve this alignment.
        - For example:
            - **Baseline-to-middle alignment** means that the smaller element’s baseline will align with the vertical center (middle) of the larger element.
            - **Middle-to-middle alignment** ensures that both elements' vertical centers will align with each other.

**Key Points Recap:**

- **Top, middle, and bottom alignment** are relative to the tallest element in the line box, with all elements sharing these points within the line box.
- **The line box expands** to fit the tallest element, and vertical alignment is applied inside these boundaries.
- **Cross-boundary alignment (like top-to-bottom)** is not possible, as elements cannot leave the line box.
- **Baseline-to-middle** or **middle-to-middle alignment** works because the alignment occurs inside the line box’s boundaries, maintaining the correct visual alignment without breaking layout rules.

This explanation covers the nuances of how vertical alignment functions for inline elements within a line box, ensuring clarity when aligning elements by their baseline or middle points!

[vertical-align - CSS: Cascading Style Sheets | MDN](https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align)
## Outline
The `outline` is a CSS property that draws a line around the outside of an element's border, used to make the element stand out or indicate focus. Unlike borders, outlines don't take up space in the layout, meaning they don't affect the element's size or position. Outlines are typically used for accessibility purposes, such as highlighting links or form elements when they receive focus via keyboard navigation. They can be customized in terms of color, style, and thickness but are not confined to the box model, meaning they can extend beyond the element's boundary.
# Bookmarks 

[CSS Flexbox Layout Guide | CSS-Tricks](https://css-tricks.com/snippets/css/a-guide-to-flexbox/) - cheat sheet.

[Flexbox - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS/CSS_layout/Flexbox)

[An Interactive Guide to Flexbox in CSS • Josh W. Comeau](https://www.joshwcomeau.com/css/interactive-guide-to-flexbox/)

[Flexbox Cheatsheet](https://codepen.io/kdankov/pen/QWoVyZJ) - интерактивен cheat sheet.

[CSS Flexbox Tutorial - Learn the right way - YouTube - FollowAndrew](https://www.youtube.com/watch?v=w9lsR2tvkvQ) 

[Learn flexbox the easy way - YouTube - Kevin Powell](https://www.youtube.com/watch?v=u044iM9xsWU)

[The thing people get wrong about flex-basis - YouTube - Kevin Powell](https://www.youtube.com/watch?v=jx4FtPlDXJg)

[Font Awesome](https://fontawesome.com/) - **Font Awesome** is the Internet's icon library and toolkit, used by millions of designers, developers, and content creators.

[html - Vertical align not working on inline-block - Stack Overflow](https://stackoverflow.com/questions/35529582/vertical-align-not-working-on-inline-block)

[vertical-align - CSS: Cascading Style Sheets | MDN](https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align)


Completion: 13.09.2024