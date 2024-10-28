# General
## Shortcuts
`Ctrl+K Ctrl+S` - отваря shortcuts editor.

 `! + Enter` - създава темплейт.

`Ctrol + Shift + P` - отваря Command Palette.

`Ctrol + Shift + P => Reindent Lines` - реформатира indentation-а на документа.

`Shift + Alt + F` - форматира файл-a, може да се направи след всеки save да се изпълнява:

- Open the Command Palette
- Search for "Preferences: Open Settings (JSON)"
- Add the following settings:

```
"editor.formatOnSave": true
```

This will ensure that every time you save your file, the code will be automatically formatted.

`Alt + Shift + Mouse select` - може да селектираме няколко реда и ако натиснем `Home` или `End` ще отиде в началото или края на всеки от редовете. Така бързо може да добавим отварящ или затварящ таг.

Selecting Semicolons in Multiple Lines

1. **Using Ctrl (or Cmd on macOS) + D**:
    - Place your cursor over the semicolon in the first line.
    - Press **`Ctrl + D`** (or **`Cmd + D`** on macOS) to select the semicolon.
    - Continue pressing **`Ctrl + D`** (or **`Cmd + D`**) to select additional semicolons in subsequent lines.
    - You can then edit all selected semicolons at once.
2. **Using Alt + Click**:
    - Hold down the **`Alt`** key (or **`Option`** key on macOS).
    - Click on each semicolon in the lines you want to select. This will create a separate cursor for each semicolon.
    - Now you can edit them simultaneously.
3. **Using Box Selection**:
    - If the semicolons are aligned vertically, you can use the **box selection** method:
        - Hold down **`Alt`** (or **`Option`** on macOS) and drag the mouse to create a selection box around the semicolons.
        - You can then type or delete to modify all selected semicolons at once.

`<p> Lorem </p>` ,  ще ни напише dummy text за тестови цели. Може да отидем и на [Lorem Ipsum - All the facts - Lipsum generator](https://www.lipsum.com/) където има повече възможности за генериране на текст

`Ctrl + Shift + Enter` - добавя ред от горе на текущия в който сме.

`Ctrl + Enter` - добавя ред от долу на текущия в който сме.

`Shift + Alt + Down/UpArrow` - копира текущия ред.

`Alt + Z` - активира или деактивира word wrap (прекъсване на текста на нов ред), за да се побере в ширината на редактора, без да се създава хоризонтална scrollbar.

`Ctrl + J` - отваря Integrated Terminal прозорец, където може да се изпълнява JS код с `node` командата - `node <filename>.js`. Тази команда е налична, ако има инсталиран Node.js

`log + 2 x Tab` - изписва `console.log();` *`Tab Completion` трябва да е on за да работи.* 
## Extensions
Live server - рефрешва документа в браузъра автоматично.
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

- CSS-подобни селектори: Например, `div#container>ul.list>li.item*3 + Tab` и получаваме:

```
<div id="container">
    <ul class="list">
        <li class="item"></li>
        <li class="item"></li>
        <li class="item"></li>
    </ul>
</div>
```

`.container + Tab ` = `<div class="container"></div>`

- Автоматично завършване и навигация в кода, което улеснява работата.

Как се използва: Въвеждате съкращения в редактора си и натискаме `Tab` или `Enter`,  за да разширим кода.

Emmet е полезен за бързо генериране на HTML/CSS структури и спестяване на време.
# Misc

# ChatGPT
## Settings Scope
In Visual Studio Code, there are several different scopes for settings, and you can modify them depending on whether you want the changes to apply globally (across all projects) or locally (to a specific project or workspace). Here's the breakdown:

1. **User Settings** 

These settings apply globally to all your projects and workspaces. Changes made here will affect every instance of VS Code you open.
`
2. **Workspace Settings**

These settings are specific to the project or workspace you're currently working in. They **override user settings** within that workspace.

- Ideal for project-specific configurations, such as enforcing specific formatting or indentation styles for team collaboration.
- Settings here are stored in a `.vscode/settings.json` file within the project folder, allowing other team members to use the same settings when they clone the project.

3. **Default Settings**

These are the built-in default settings provided by VS Code. You cannot edit the default settings directly, but you can view them as a reference.

- **How to View:** You can see them by selecting **"Preferences: Open Default Settings"** in the Command Palette.
- Any user or workspace settings you configure will override these defaults.

**Summary:**

- **User Settings**: Global configuration across all workspaces.
- **Workspace Settings**: Specific to the current project or folder and will override user settings for that project.
- **Default Settings**: Built-in settings that serve as the baseline. They can be viewed but not edited directly.

**Best Practices:**

- **Use User Settings** for preferences you want to apply across all your projects (e.g., your preferred tab size or theme).
- **Use Workspace Settings** for project-specific needs (e.g., when collaborating with a team that uses different code formatting rules).

# Bookmarks

[Lorem Ipsum - All the facts - Lipsum generator](https://www.lipsum.com/) - генериране на random текст за тестови цели.