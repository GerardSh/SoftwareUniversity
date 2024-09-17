# General
## What is Responsive Web Design?
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240914133637.png)

Идеята е един сайт, да си променя layout-a според устройството, на което е отворен, като зависи главно от широчината на екрана на устройството.
При desktop, layout-a е най-сложен, защото имаме много повече хоризонтално място за нареждане на елементи.

[Responsive Web Design – A List Apart - Ethan Marcotte](https://alistapart.com/article/responsive-web-design/)

[Responsive design - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS/CSS_layout/Responsive_Design)
## Responsive Web Design - How?
## Media Queries
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240914140456.png)

Чрез стиловете, които пишем чрез CSS, казваме на browser-a как да изглежда нашия сайт. Media query-тата, ни позволяват да питаме разни неща, за устройството в което в момента се отваря нашия сайт. Примерно може да питаме дали размера на екрана е определен размер, дали може да правим hover, какъв е aspect ratio-то и тн. Media queries ни позволяват да задаваме допълнителни правила. Ако устройството отговаря на определено правило, се apply-ва допълнителен CSS. Така може да пишем CSS, който да отговаря за различни устройства. Така нашия сайт се адаптира. 
С други думи, responsive design е да знаем как да си променим layout-a, за да може да се адаптира към различни устройства.

Media query-тата се отнасят главно до размера на **view port-a** (видимата част на екрана на потребителя), а не до размера на специфични елементи като `<body>` или други елементи. Те не предлагат директен начин да се насочат към нещо различно от характеристиките на view port-a, като неговата ширина, височина, резолюция и ориентация. Обикновено трябва да се ползва JavaScript, за да засече размера на елемента и след това динамично да приложи стилове или класове. Вместо JavaScript, може да се ползват container queries директно в CSS, без нужда от JS, но понеже са относително нови, не всички браузъри ги подържат.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240914141528.png)
### Media Types
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240914161121.png)

Примерно може да напишем специални стилове, които се зареждат, когато принтираме нашия сайт.
### Import
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240914161443.png)

Може да import-ваме CSS в друг CSS и там да кажем, за кой точно media type се отнася този CSS.
### Media Features
![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240914163647.png)

Това са възможностите на устройството, за които ние ще казваме - при такива условия, този CSS трябва да бъде зареден.
query-то в screenshot-a казва  - когато имаме екран и width да е поне 600px, по конкретно viewport-a е 600px, стиловете които са вътре в query-то, ще се вземат предвид.
### Logical operators
and - `@media screen and (pointer: fine)` трябва и двете да са верни - да е screen и pointer fine.
not - `@media screen and not (pointer: fine)` трябва да е screen, но не трябва да е pointer fine.
only - `@media only screen and (pointer: fine)` трябва, цялото media query да match-не.
, (comma) - `@media (min-heigth: 680px), only screen and (orientation: portrait)` позволява ни да изреждаме повече от едно query-та, едно след друго. Ако едно от тях върне true, целия израз връща true. Този оператор се държи като OR оператор.

**Examples:**
#### and
Used for combining multiple media features together into a single media query, requiring each chained feature to return true for the query to be true. It is also used for joining media features with media types.

```
@media (min-width: 801px) and (max-width: 1199px) {
    body::before {
        display: block;
        content: 'The viewport width is larger than 800px and smaller than 1200px';
        background: #369;
        color: #fff;
        padding: 1em 1.5em;
        margin-bottom: 2em;
        border-radius: 0.3em;
    }
}
```     
#### not
Used to negate a media query, returning true if the query would otherwise return false. If present in a comma-separated list of queries, it will only negate the specific query to which it is applied.

```
@media not (max-width: 1200px) {
    body::before {
        display: block;
        content: 'The viewport width is larger than 1200px';
        background: #369;
        color: #fff;
        padding: 1em 1.5em;
        margin-bottom: 2em;
        border-radius: 0.3em;
    }
}
```
#### only
Applies a style only if an entire query matches. It is useful for preventing older browsers from applying selected styles. When not using only, older browsers would interpret the query screen and (max-width: 500px) as screen, ignoring the remainder of the query, and applying its styles on all screens.

```
@media only screen and (min-width: 801px) {
    body::before {
        display: block;
        content: 'The device is using a screen and the viewport width is larger than 800px';
        background: #369;
        color: #fff;
        padding: 1em 1.5em;
        margin-bottom: 2em;
        border-radius: 0.3em;
    }
}
```
#### , (comma)
Commas are used to combine multiple media queries into a single rule. Each query in a comma-separated list is treated separately from the others Thus, if any of the queries in a list is true, the entire media statement returns true. In other words, lists behave like a logical or operator.
#### or
Equivalent to the , operator. Added in Media Queries Level 4.
### Testing Media Queries
Лесен начин да тестваме дали нашите media queries работят - Inspect и след това на device emulation. Може да задаваме конкретна резолюция, също изключва режими като hover, които мобилните устройства нямат.
## Responsive Typography

```
/* Typography */

html {
    font: 11px/1.5 Lato, sans-serif;
}

@media (min-width: 400px) {
    html { font-size: 12px; }
}

@media (min-width: 800px) {
    html { font-size: 14px; }
}

@media (min-width: 1280px) {
    html { font-size: 16px; }
}
```

Когато padding, margin, line height и всичко останало, зависи от base font size-a, защото е сложено в em-ове, променяйки размера на страница, всичко расте заедно. Когато се налага да стане по-малко, за да може да съберем повече текст на един ред, то се променя. Така всичко си работи много добре и за малки и големи екрани. В примера горе, всяко следващо query, override-ва предишното. Винаги сме в посока от 400px нагоре, това се нарича mobile-first. Default стиловете са най-малки, колкото по-голям става екрана, толкова повече добавяме стилове. Алтернативно, може да ползваме max-width, което ще създаде desktop-first подход, където default стиловете са за големи екрани и промените са правят за по-малки екрани. 
Често се смята, че когато се използва "desktop-first" подход (от по-големи към по-малки екрани), може да се наложи да се пише повече код. Това е така, защото първоначалният дизайн и стилове са създадени за по-големи екрани, а след това се добавят допълнителни медийни заявки (`@media`) за по-малки екрани, за да се коригират и адаптират стиловете. В "mobile-first" подхода (от по-малки към по-големи екрани) базовите стилове са за мобилни устройства. Когато екранът става по-голям, добавяме стилове чрез медийни заявки, като по този начин често намаляваме повторенията и сложността на кода. Това обикновено води до по-чист и по-малко излишен CSS код.
# Misc
## Table Creation
```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Table Creation</title>
    <style>
        
        .table{
            text-align: center;
        }

    </style>
</head>
<body>
    
    <table>
        <thead>
            <tr>
                <th>Header 1</th>
                <th>Header 22</th>
                <th>Header 333</th>
            </tr>   
        </thead>
        <tbody>
            <tr>
                <td>Row 1, Col 1</td>
                <td>Row 1, Col 2</td>
                <td>Row 1, Col 3</td>
            </tr>
            <tr>
                <td>Row 2, Col 1</td>
                <td>Row 2, Col 2</td>
                <td>Row 2, Col 3</td>
            </tr>
            <tr>
                <td>Row 3, Col 1</td>
                <td>Row 3, Col 2</td>
                <td>Row 3, Col 3</td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td>Total:</td>
                <td>9 Cols</td>
                <td>Summary Info</td>
            </tr>
            <tr>
                <td colspan="3" class="table">*End of table</td>
            </tr>
        </table>
        
    </body>
    </html>
```

Когато създаваме таблица, първо пишем `<table>`. 
Първия ред на таблица table row - `<tr>`(всичко в table row е един ред), го слагаме в `<thead>`  и вътре изреждаме table header-и - `<th>`, защото става като заглавие на всяка колона. 
Следващите редове ги слагаме в `<tbody>` и в тях изреждаме table data - `<td>`, което дефинира една клетка в таблицата.
По желание, може да сложим и `<tfoot>`, ако искаме да добавим допълнителна информация като последен ред съдържаща - summary / total / note / remark.
Атрибутът `colspan` в HTML се използва, за да позволи на една клетка да се разпростре хоризонтално върху няколко колони. Това е полезно, когато искаме да създадем заглавие или съдържание, което да обхване няколко колони и да създаде по-добра структура и визуален баланс в таблицата.
Атрибутът `rowspan` в HTML се използва за вертикално обединяване на клетки в таблица. С него можем да зададем на една клетка да обхваща няколко реда. Например, ако зададем `rowspan="2"`, клетката ще се простира през два реда. Това е полезно, когато искаме да създадем таблица с комбинирани клетки за по-добра визуална организация на данните.
# ChatGPT
## Key Media Features
In CSS, media features are used within media queries to apply styles based on the characteristics of the user's device or viewport. There are many media features, and they can be broadly categorized into several groups. Here is an overview of the key media features:

**1. Viewport and Display Properties**

- **`width`**: The width of the viewport.
- **`height`**: The height of the viewport.
- **`aspect-ratio`**: The ratio of the viewport's width to its height.
- **`min-width`** / **`max-width`**: The minimum and maximum width of the viewport.
- **`min-height`** / **`max-height`**: The minimum and maximum height of the viewport.
- **`orientation`**: The orientation of the viewport, either `portrait` or `landscape`.

**2. Resolution and Display Density**

- **`resolution`**: The resolution of the output device in terms of pixels per inch (PPI) or dots per inch (DPI).
- **`min-resolution`** / **`max-resolution`**: The minimum and maximum resolution of the output device.
- **`device-pixel-ratio`**: The ratio between the device resolution in physical pixels and the resolution in CSS pixels (similar to `resolution` but usually used for high-DPI displays).

**3. Color and Display Capabilities**

- **`color`**: The number of bits per color component of the output device.
- **`min-color`** / **`max-color`**: The minimum and maximum color depth.
- **`color-index`**: The number of entries in the color lookup table of the output device.
- **`min-color-index`** / **`max-color-index`**: The minimum and maximum color index.
- **`monochrome`**: The number of bits per pixel in a monochrome frame buffer.
- **`min-monochrome`** / **`max-monochrome`**: The minimum and maximum monochrome capability of the device.

**4. Interaction and Input**

- **`pointer`**: Indicates the quality of the pointing device (e.g., `none`, `coarse`, `fine`).
- **`hover`**: Indicates if the primary pointing device can hover over elements (`none` or `hover`).
- **`any-pointer`**: Similar to `pointer` but applies if any pointing device can interact.
- **`any-hover`**: Similar to `hover` but applies if any pointing device can hover.

**5. Media Type-Related**

- **`scan`**: Indicates the scanning process (`progressive` or `interlace`) for devices like TVs.
- **`grid`**: Indicates if the output device is grid-based (e.g., `grid: 1` for grid devices).

**6. Environment and Accessibility**

- **`prefers-color-scheme`**: Indicates if the user prefers a light or dark color scheme (`light` or `dark`).
- **`prefers-reduced-motion`**: Indicates if the user prefers reduced motion on the page (`reduce` or `no-preference`).
- **`prefers-contrast`**: Indicates if the user prefers high or low contrast (`more`, `less`, `no-preference`).
- **`inverted-colors`**: Indicates if the colors are inverted (`inverted` or `none`).
- **`forced-colors`**: Indicates if the user has enabled a forced color mode (`active` or `none`).

**7. Speech and Aural Properties**

- **`speech`**: Used for speech synthesizers (e.g., `voice` or `speech`).

These media features allow developers to craft responsive designs that adapt to a variety of devices and user preferences.
## `<meta name="viewport">`
The `<meta name="viewport">` tag is used to control the layout and scaling of the webpage on different devices, particularly mobile devices. It instructs the browser on how to adjust the page's dimensions and scaling to fit the screen of the device being used. Here's a breakdown of its components:

**Structure and Attributes**

`<meta name="viewport" content="width=device-width, initial-scale=1.0">`

- **`name="viewport"`:** This specifies that the meta tag is setting the viewport properties for the page.
    
- **`content` attribute:** This is where you define the viewport settings. In this example, it contains two settings:
    
    1. **`width=device-width`:**
        - This sets the width of the viewport to the width of the device.
        - Essentially, it makes the viewport width equal to the screen width of the device (e.g., 375px on an iPhone).
        - Without this setting, mobile browsers often render pages at a default width (typically around 980px) and then scale them down to fit the screen, which can result in an undesired zoomed-out view.
    2. **`initial-scale=1.0`:**
        - This sets the initial zoom level when the page is first loaded.
        - A value of `1.0` means no zoom; the page will display at its actual size, matching the device's width.
        - For example, if the device's screen is 400px wide, the viewport will initially render the page at 400px wide without any scaling.

**Why It's Important**

- **Responsive Design:** This tag is crucial for responsive web design. It ensures that the page scales correctly on different devices, providing an optimal viewing experience.
    
- **Mobile-Friendliness:** Without this meta tag, mobile browsers might not display the page properly, forcing users to zoom in and out manually to read content or interact with the page.

**Example in Context**

`<meta name="viewport" content="width=device-width, initial-scale=1.0">`

- With this tag, a website will fit the screen width of the device (e.g., a smartphone or tablet) exactly, and the content will be rendered at the correct size without being zoomed in or out by default.

**Additional Options**

You can further customize the viewport behavior with more properties:

- **`maximum-scale`**: Specifies the maximum zoom level (e.g., `maximum-scale=2.0`).
- **`minimum-scale`**: Specifies the minimum zoom level.
- **`user-scalable`**: Controls whether the user can manually zoom (`yes` or `no`).

`<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">`

This example prevents the user from zooming in or out on the page.

**You said:**

What happens if the page is 1000px wide but the device screen is 400px wide?

**ChatGPT said:**

If the webpage is designed to be 1000px wide but is viewed on a device with a screen width of 400px, the behavior depends on whether the viewport meta tag is included and how the page's CSS is set up. Let's explore the different scenarios:

**1. Without the Viewport Meta Tag**

If the `<meta name="viewport">` tag is not included in the HTML, the mobile browser will typically render the page at a default viewport width, usually around 980px, and then scale it down to fit the screen.

- **Result:** The page will appear zoomed out on the device. Text and images will look smaller because the browser tries to fit the entire 1000px-wide page into the 400px-wide screen. Users will likely have to zoom in manually to read content or interact with elements.

**2. With the Viewport Meta Tag (`width=device-width, initial-scale=1.0`)**

If you include the viewport meta tag like this:

`<meta name="viewport" content="width=device-width, initial-scale=1.0">`

- **Result:** The page will adapt to the device's screen width (400px in this case). This means:
    - The content will be scaled to fit the screen width.
    - Instead of shrinking the entire 1000px-wide layout to fit into 400px, the browser will render the content at a scale that matches the screen's width.
    - Elements on the page will wrap or stack if CSS media queries are used to create a responsive design.
    - If no responsive design is used (e.g., using fixed-width elements), horizontal scrolling may be introduced to view the entire content.

**3. Responsive Design with CSS Media Queries**

To provide the best user experience on different screen sizes, you should use responsive design techniques in your CSS. Media queries can adjust the layout based on the viewport width.

```
/* Base styles for wider screens */
.container {
    width: 1000px;
}

/* Adjust layout for smaller screens */
@media (max-width: 600px) {
    .container {
        width: 100%; /* Scale container to fit smaller screens */
    }
}
```

- **Result:** On a device with a 400px-wide screen, the container's width will adjust to `100%`, fitting the screen without horizontal scrolling. The layout will become more user-friendly on smaller devices.

**Summary**

- **Without the viewport meta tag:** The page will appear zoomed out, making content smaller and harder to interact with.
- **With the viewport meta tag:** The page will scale to fit the device's screen width, but if the page isn't designed responsively, it might cause horizontal scrolling.
- **With responsive design:** The layout adjusts to fit various screen sizes, providing an optimal viewing experience on all devices.
## Base Styles and Media Queries
**Base Styles:**

- Default CSS rules applied to elements universally.
- Set the general appearance and layout of the website.
- Example: `body { background-color: aqua; }`

**Media Queries:**

- Conditional CSS rules applied based on viewport characteristics (e.g., screen width).
- Override base styles when specified conditions are met.
- Example: `@media (max-width: 600px) { body { background-color: green; } }`

**Interaction:**

- Media queries evaluate conditions and apply styles accordingly.
- Media query styles override base styles if the conditions are met and the media query rules have equal or higher specificity.
- Typically, media queries are placed after base styles in the CSS file to ensure proper application and overriding of styles.

**Example:**

```
/* Base Styles */
body {
    background-color: aqua;
}

/* Media Query */
@media (max-width: 600px) {
    body {
        background-color: green;
    }
}
```

- **Screen Width > 600px:** `background-color: aqua;`
- **Screen Width ≤ 600px:** `background-color: green;`

It’s important for media queries to be placed **after** base styles in the CSS file for the following reasons:

1. **CSS Cascade Order:** CSS applies rules based on their order in the stylesheet. Rules that appear later can override earlier rules if they have the same specificity. Placing media queries after base styles ensures that media query rules can override base styles when the conditions are met.
    
2. **Responsive Design:** To ensure that styles adapt correctly to different viewport sizes, media queries need to modify or override base styles. If media queries come before base styles, the base styles would override them, making the media queries ineffective.

**Example:**

```
/* Base Styles */
body {
    background-color: aqua;
}

/* Media Query (should come after base styles) */
@media (max-width: 600px) {
    body {
        background-color: green;
    }
}
```

- **Screen Width > 600px:** `background-color: aqua;`
- **Screen Width ≤ 600px:** `background-color: green;` (media query overrides base style)

This ordering ensures that the media query can properly apply styles for different conditions, without being overridden by base styles.
## Media Queries as Conditional Selectors
**You said:**

Can we describe media queries as conditional rules that apply styles to specific elements based on certain conditions? If the specified conditions are met, the styles within the media query are applied to the targeted elements.

**ChatGPT said:**

Yes, that's a good way to describe media queries!

**Media Queries** can be thought of as "conditional selectors" because they apply styles to elements based on specific conditions related to the viewport or device characteristics.

**How They Work:**

1. **Condition:** Media queries include conditions such as viewport width, screen resolution, or device orientation.
    
    - Example: `@media (max-width: 600px)` checks if the viewport width is 600px or less.
    
2. **Selector and Styles:** Inside a media query, you define styles that should be applied if the condition is met.
    
```
@media (max-width: 600px) {
    body {
        background-color: green;
    }
}
```

- Here, if the viewport width is 600px or less, the `background-color: green;` style is applied to the `body` element.

**Summary:**

- **Media Queries** are conditional in that they only apply their styles if certain conditions are true.
- **Selectors** inside media queries specify which elements the styles should be applied to.

In CSS the media features are always specified within parentheses `()`. In essence, media queries extend the concept of selectors by adding conditional logic, allowing for responsive design that adapts to different environments and device characteristics. 
## Media Type and Media Features
**You said:**

The media type like a filter, and the media feature like a condition? If the condition is met, the styles will be applied to the devices that match the media type filter, right?

**ChatGPT said:**

Yes, that's a good way to think about it:

- **Media Type**: Acts like a filter that specifies the type of device or environment the styles should apply to. For example, `screen` filters the styles to apply only to screen devices, while `print` filters them to apply only when printing.
    
- **Media Feature**: Acts as a condition that determines when the styles should be applied based on specific characteristics of the device or viewport. For example, `(min-width: 500px)` is a condition that checks if the viewport width is at least 500px.
    
**How It Works:**

1. **Filter (Media Type)**:
    
    - Specifies which types of devices or media the query applies to.
    - If omitted, the media query applies to all media types.
2. **Condition (Media Feature)**:
    
    - Defines the criteria that must be met for the styles to be applied.
    - For example, `(min-width: 500px)` specifies that the viewport must be at least 500px wide.

**Example Breakdown:**

```
@media screen and (min-width: 500px) {
    /* Styles here are applied to screen devices */
    /* if and only if the viewport width is at least 500px */
}
```

- **Filter**: `screen` — This restricts the media query to screen devices.
- **Condition**: `(min-width: 500px)` — This applies the styles only if the viewport width is at least 500px.

**Summary:**

- **Media Type**: Filters which types of devices the styles apply to (e.g., `screen`, `print`).
- **Media Feature**: Specifies the conditions under which the styles should be applied (e.g., `min-width`, `orientation`).

When both the media type filter and the media feature condition are met, the styles defined within the media query are applied to the device.
## @import
**You said:**

Is the `@import` rule used to include styles from an external CSS file conditionally based on media queries, such that if the specified media type and conditions are met, all the styles found in the imported external CSS file are applied?

**ChatGPT said:**

Yes, that's correct. Here's a more detailed explanation:

**@import**` Rule with Media Queries:

1. **Purpose**:
    
    - The `@import` rule is used to include and apply external CSS files into your main stylesheet.
    - When used with media queries, it conditionally applies the styles from the imported CSS file based on specific conditions and media types.
2. **How It Works**:
    
    - **Media Type**: Specifies which type of device or media the imported CSS should apply to (e.g., `screen`, `print`).
    - **Media Feature**: Defines the conditions (e.g., viewport width, orientation) under which the styles in the imported CSS file will be applied.
3. **Example**:

```
/* Main stylesheet */

/* Import external CSS with media query conditions */
@import url("desktop-styles.css") screen and (min-width: 1024px);
@import url("mobile-styles.css") screen and (max-width: 1024px);
```

- **`desktop-styles.css`**: This file's styles will be applied if the viewport width is at least 1024px and the media type is `screen`.
- **`mobile-styles.css`**: This file's styles will be applied if the viewport width is 1024px or less and the media type is `screen`.

**Summary:**

- **When Importing**: The `@import` rule is used within a CSS file to include additional styles from external CSS files.
- **Conditions**: The media query conditions (media type and features) specified with `@import` determine when and where the styles from the imported files should be applied.
- **Outcome**: If the conditions specified are met (e.g., viewport width and media type), then the styles defined in the imported CSS file will be applied to the document.

This method is useful for organizing CSS into modular files and applying styles conditionally based on the device characteristics.

The difference between using `@import` with media queries and writing standard `@media` queries directly in a CSS file is in how and where the styles are applied:

- **`@import` with Media Queries**: Imports styles from external CSS files based on media query conditions. The selectors and styles in the imported files are applied if the conditions are met.
- **Standard `@media` Queries**: Defines styles directly within the media query block based on the conditions specified. You write the selectors and styles inside the `@media` block.

Both methods allow for conditional styling, but `@import` is useful for modularizing CSS into separate files, while standard `@media` queries allow you to include styles directly in the main stylesheet.
## Using Commas to List Media Types in CSS

In CSS media queries, you can list different media types separated by commas to apply styles based on multiple conditions. When using commas, each media type or condition acts as a separate "OR" clause. If **any** of the conditions is true, the styles within the media query are applied.

**Important Points:**

- **One Type Per Query**: Each media query (separated by commas) can contain **only one** media type. For example, you can use `screen`, `print`, or `speech` in a single media query, but not more than one type in the same query.
- **Commas as "OR"**: When you separate media queries with commas, it means the styles will apply if **any** of the conditions are met.

**Syntax Example**

```
@media (min-width: 800px), speech and (orientation: landscape) {
    /* Styles to be applied */
}
```

- **`(min-width: 800px)`**: Applies to devices with a viewport width of 800px or more.
- **`speech and (orientation: landscape)`**: Applies to speech devices (e.g., screen readers) **only** when in landscape orientation.
- **How It Works**: The styles will apply if the viewport width is at least 800px **or** if the device is a speech media type in landscape orientation.

**Correct Usage:**

Each condition in a media query should include **only one media type**:

```
@media screen, print {
    /* Correct: This applies styles to both screen and print media types */
    /* Styles go here */
}
```

**How Commas Work:**

- When using commas, you can list multiple media types and conditions separately.
- Example:

```
@media screen and (max-width: 500px), print and (min-width: 1000px) {
    /* Styles to be applied */
}
```

- **`screen and (max-width: 500px)`**: Applies if the device is a screen and the viewport width is 500px or less.
- **`print and (min-width: 1000px)`**: Applies if the device is a print media type and the viewport width is 1000px or more.

**Summary:**

- You can list media queries separated by commas.
- Each media query should contain only one media type (e.g., `screen`, `print`).
- If **any** of the media queries' conditions are true, the styles are applied.

## Importing Font from Google Fonts
To import for example the Lato font from Google Fonts into your website, follow these brief steps:

1. **Go to Google Fonts**:
    
    - Visit [Google Fonts](https://fonts.google.com/).
2. **Search for Lato**:
    
    - Type "Lato" in the search bar and select it from the list of fonts.
3. **Select Styles**:
    
    - Choose the font weights and styles you want to use (e.g., Regular 400, Bold 700).
4. **Copy the Embed Code**:
    
    - Click the “+ Select this style” button for the styles you chose.
    - Click on the “Use” or “Embed” tab on the right side.
    - Copy the `<link>` tag provided under the “Embed” section.
5. **Add the Embed Code to Your HTML**:
    
- Paste the copied `<link>` tag inside the `<head>` section of your HTML document.

```
<link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700&display=swap" rel="stylesheet">
```

6. **Use the Font in Your CSS**:
    
    - Apply the font to your elements using CSS:

```
body {
    font-family: 'Lato', sans-serif;
}
```

**Summary**

- **Select** Lato on Google Fonts.
- **Copy** the provided `<link>` tag.
- **Paste** it into your HTML `<head>`.
- **Apply** the font using CSS.

This will import the Lato font into your project and allow you to use it throughout your styles.

**You said:**

What is the difference between `<link>` and `<import>`?

**ChatGPT said:**

Both the `<link>` and `@import` methods are used to include external CSS files in your project, but they have different uses and implications, especially for importing fonts.

**1. Using `<link>` Tag**

**How It Works:**

- **HTML Method**: Place the `<link>` tag in the `<head>` section of your HTML document.
- **Example**:

```
<link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700&display=swap" rel="stylesheet">
```

**Advantages:**

- **Performance**: The browser starts loading the font as soon as it encounters the `<link>` tag, which can lead to faster rendering of fonts.
- **Priority**: CSS files linked this way are downloaded before the page is fully rendered, ensuring that styles are applied as soon as possible.

**Use Case:**

- **Recommended** for importing Google Fonts or any external CSS files, as it’s more efficient and aligns better with modern best practices.

**2. Using `@import` Rule**

**How It Works:**

- **CSS Method**: Use `@import` inside your CSS files.
- **Example**:

```
@import url('https://fonts.googleapis.com/css2?family=Lato:wght@400;700&display=swap');
```

**Advantages:**

- **Convenience**: Useful for importing stylesheets within other CSS files, especially if you need to combine or conditionally apply styles.

**Disadvantages:**

- **Performance**: Importing CSS files with `@import` can lead to additional HTTP requests and delays in loading, which might negatively affect page load times.
- **Order**: Stylesheets loaded with `@import` can cause issues with CSS specificity and loading order.

**Use Case:**

- **Less Preferred** for importing fonts directly due to performance concerns. It’s more often used for including additional CSS files within a stylesheet.

**Summary:**

- **`<link>` Tag**: Preferred for importing external resources like fonts because it provides better performance and more immediate application of styles.
- **`@import` Rule**: Can be used within CSS files for including additional CSS files but is less efficient for importing fonts directly.

**Recommendation**: Use the `<link>` tag to import Google Fonts into your HTML `<head>`. This method ensures better performance and is the standard practice for including external stylesheets and fonts.

**How Font Import Works:**

1. **Specifying Font Weights in Import Statement:**
    
    - When you import a font, you specify which weights and styles are included. For example:
        
```
<link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;500&display=swap" rel="stylesheet">
```
        
        This import statement includes only weights of 400 (Regular) and 500 (Medium). Weights like 600 (Semi-Bold) are not included.
2. **Using Weights in CSS:**
    
    - You can use only the weights specified in the import statement. If you try to use a weight that was not included, the browser will not have that specific weight available and will typically fallback to the nearest available weight or default to the browser’s fallback font.
    - For example:
        
```
body {
    font-family: 'Lato', sans-serif;
    font-weight: 600; /* This weight is not available */
}
```

**Summary**

- **Available Weights:** Only the weights specified in the import statement can be used in your CSS.
- **Fallback:** If you try to use a weight that wasn’t imported, the browser will fall back to the nearest available weight or a default font.

To use a weight of 600, you would need to include it in the import statement like this:

```
<link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;500;600&display=swap" rel="stylesheet">
```

This ensures that the 600 weight is available for use in your CSS.
## ### Media Queries and `em` Units

**1. Standard `em` Units:**

- **Relative to Parent**: In regular CSS, `em` units are relative to the font size of the current element's parent. If a parent element has a font size of `16px`, `1em` will be `16px`, `2em` will be `32px`, and so on.
- **Inheritance**: The value of `em` units can change depending on the font size of the parent elements.

**2. `em` Units in Media Queries:**

- **Relative to Root Font Size**: In media queries, `em` units are relative to the root element’s (`<html>`) font size, not the parent element’s font size. The root font size is typically `16px` by default unless explicitly changed.
- **Consistent Interpretation**: Regardless of the font size set on elements like `<body>`, media queries will interpret `em` based on the root font size. For instance, if `<html>` is set to `16px`, then `1em` in a media query equals `16px`.

**3. Common Issues:**

- **Unexpected Behavior**: If the root font size is not explicitly set, `em` units in media queries may default to `16px`, leading to unexpected behavior if you're expecting them to be relative to a different size.
- **Browser Variations**: Different browsers or environments might handle `em` units in media queries differently, especially if there's an override or conflict.

**4. Troubleshooting Tips:**

- **Set Root Font Size**: Explicitly set the font size of the root element (`<html>`) to ensure consistent behavior:
    
```
html {
    font-size: 14px; /* or another desired size */
}
```
    
- **Use `px` for Clarity**: For testing purposes, use `px` units in media queries to avoid confusion:
    
```
@media (min-width: 420px) {
    /* Styles here */
}
```
    
- **Check Browser and Settings**: Verify that browser settings and CSS are not overriding the expected behavior of `em` units.

By understanding that `em` units in media queries are tied to the root font size and not the local context, you can better manage and predict responsive design behavior.
## Flex Items Width Calculation
In a flex container with a horizontal layout (`flex-direction: row`), the width of each flex item is influenced by its content. Here’s how the width is determined:

1. **Content-Based Width:** By default, flex items will grow to fit their content. If an item contains a long word that cannot break (like a long string without spaces), the item will expand to accommodate this word. This can cause the item to become wider than other items in the container.
    
2. **Longest Word:** When flex items have different content lengths, the item with the longest word will typically determine the minimum width required to contain that word. If the container does not have constraints (like a `max-width`), it will expand to fit the longest word.
    
3. **Flexbox Default Behavior:** By default, flex items will try to stay on a single line (`flex-wrap: nowrap`) and will not wrap to the next line. This means the width of the flex container itself may increase to accommodate the longest word among the items.
    
4. **Overflow:** If the combined width of the flex items exceeds the width of the flex container or viewport, the container will overflow horizontally unless styles like `overflow: hidden;` or `overflow-x: auto;` are applied.

In summary, in a flex container laid out in a row, the width of each flex item is primarily determined by its content, and the container can expand to accommodate the widest item, especially when there's a long, unbreakable word.
## Data Attribute
The `data-*` attributes in HTML are a way to store custom data in HTML elements. They are useful for adding extra information to elements without affecting their appearance or functionality. Here’s a detailed overview:

**Syntax**

- **Attribute Name**: The attribute name starts with `data-`, followed by a name of your choice. For example: `data-user-id`, `data-product-name`, etc.
- **Attribute Value**: The value assigned to the attribute can be any string. It’s often used to store information that JavaScript can later access.

html

```
<div data-user-id="12345" data-product-name="Laptop"></div>
```

**Purpose**

1. **Storing Extra Data**: You can use `data-*` attributes to store data that can be used by JavaScript. This is useful for passing additional information between HTML and JavaScript without embedding it directly in your HTML code or using complex class names or IDs.
    
2. **Customization and Flexibility**: They provide a way to store information in HTML elements that can be easily retrieved and manipulated with JavaScript.
    
3. **Non-Intrusive**: Using `data-*` attributes does not affect the rendering of the page, and they are purely for storing and retrieving data.

**Accessing Data Attributes with JavaScript**

You can access `data-*` attributes using the `dataset` property in JavaScript.

**Example**

html

```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Data Attribute Example</title>
</head>
<body>
    <div id="myElement" data-user-id="12345" data-product-name="Laptop"></div>

    <script>
        // Accessing data attributes
        var element = document.getElementById('myElement');
        var userId = element.dataset.userId; // "12345"
        var productName = element.dataset.productName; // "Laptop"

        console.log(userId); // Outputs: 12345
        console.log(productName); // Outputs: Laptop
    </script>
</body>
</html>
```

**Key Points**

- **Naming Convention**: The name of the data attribute should be written in lowercase with hyphens (e.g., `data-user-id`). When accessed via JavaScript, hyphens are converted to camelCase (e.g., `dataset.userId`).
- **Data Types**: Data attributes store data as strings. If you need to store other data types (like numbers or arrays), you’ll need to convert them to and from strings in JavaScript.
- **Not for Styling**: Data attributes are not meant for styling elements. For styling, you should use CSS classes and IDs.

**Limitations**

- **No Special Behavior**: `data-*` attributes don’t have any special behavior or default functionality. They are simply a means of attaching custom data to elements.
- **No Direct Use in CSS**: You cannot style elements based on `data-*` attributes directly in CSS (although you can use them in selectors with certain CSS-in-JS libraries).

`data-*` attributes offer a flexible and unobtrusive way to store and retrieve custom data associated with HTML elements.
# Bookmarks 

[Responsive Web Design – A List Apart - Ethan Marcotte](https://alistapart.com/article/responsive-web-design/)

[Responsive design - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS/CSS_layout/Responsive_Design)

[Beginner's guide to media queries - Learn web development | MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS/CSS_layout/Media_queries)

[Using media queries - CSS: Cascading Style Sheets | MDN](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_media_queries/Using_media_queries)

[Dribbble - Discover the World’s Top Designers & Creative Professionals](https://dribbble.com/) - excellent for layout design ideas. While Dribbble doesn't provide the code, you can use the visual designs as a reference and inspiration to recreate layouts in HTML and CSS yourself. It's a common practice for developers to take design concepts from Dribbble and use them as a basis for their projects, translating the visual ideas into functional web pages or applications.

[Backing Track](https://backingtrack.gg/) - music content, specifically focusing on backing tracks and stream-safe music. It has a presence on YouTube under the name "Backing Track," where it offers music that can be used for various purposes, including live streams and other content creation needs. This music is likely tailored to be copyright-safe, meaning content creators can use it without risking copyright infringement issues.

Completion: 15.09.2024