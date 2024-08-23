# General
## What is HTML
Hypertext Markup Language е език, който описва съдържание. Той е основата за създаването на web страници, всички браузъри отварят и четат HTML, взимат информацията в документа и ни я презентират. Както Word чете docx файлове, така браузърите четат HTML. Всеки сайт е набор от HTML файлове, ако има 3000 страници, това означава че има 3000 HTLM файла.

Език за описване на семантична структура - параграф, заглавие и тн. 

HTML има тагове, чрез които описваме съдържанието.

Browser-a е софтуер, който си говори със сървъра чрез HTTP протокол - казва искам този адрес и сървъра връща информацията под формата на HTML, след което браузъра го разчита и ни го презентира.
## HTML Tags
![](Pasted%20image%2020240823185250.png)

Таговете са ключови думи, обградени със скоби, като един таг има начало и край. Имаме отварящ и затварящ таг, като има и самостоятелни тагове, без затварящ.
Може да имаме и вградени тагове:

```
<header>
   <h1>Welcome</h1>
</header>   
```
### `<main></main>`
![](Pasted%20image%2020240823190451.png)

Трябва да имаме само един main tag и той държи основния content на нашата страница.
### `<aside></aside>`
![](Pasted%20image%2020240823190540.png)

Използва се когато имаме sidebar, който може да съдържа линкове или друга допълнителна информация.
### `<footer></footer>`
![](Pasted%20image%2020240823191655.png)

Може да е footer за целия сайт или нещо друго.
### `<section></section>`
![](Pasted%20image%2020240823191821.png)

Ползва се, ако искаме да отделим част от съдържанието
### `<article></article>`
![](Pasted%20image%2020240823191957.png)

Ползва се, ако искаме да опишем дадена статия.
### `<figure></figure>`

![](Pasted%20image%2020240823192512.png)

Специален таг, който описва допълнителна информация за картинки.
## Sections and Articles
![](Pasted%20image%2020240823192111.png)
## HTML Versions
В началото на всеки документ, трябва да слагаме `<!DOCTYPE html>`. Това казва на браузъра че версията на HTML е 5 и че ние поемаме ангажимент за валидността на този код. Ако го махнем браузъра работи в режим в който ни чете HTML-a и се опитва да го оправи. Това е от преди много време, когато HTML е бил пълен с грешки и браузърите са опитвали да ги оправят.
## Common HTML Tags
### Headings and Paragraphs
![](Pasted%20image%2020240823194830.png)
### Hyperlinks
![](Pasted%20image%2020240823194857.png)
### Images
![](Pasted%20image%2020240823195012.png)
### Ordered Lists
![](Pasted%20image%2020240823195126.png)
### Unordered Lists
![](Pasted%20image%2020240823195503.png)
### Definition Lists
![](Pasted%20image%2020240823195615.png)
## HTML Tag Attributes
![](Pasted%20image%2020240823211619.png)

Чрез атрибутите, имаме възможност да добавяме допълнителна информация към определен таг.
Имаме име на атрибута и неговата стойност - key value pair. Името е ключа, който ни позволява да стигнем до информацията. 
Има универсални атрибути, които може да се сложат навсякъде, но има и атрибути, които работят само на определени тагове.
Винаги се пишат с малки букви, а техните стойности са в двойни или единични кавички. Кавичките трябва да са еднакви при отварянето и затварянето.
## HTML Metadata Section
![](Pasted%20image%2020240823212213.png)
## Metadata Section
![](Pasted%20image%2020240823212946.png)
## Indentation & Code formatting
Indentation-a е много важен, за да знаем бързо и лесно, къде се намираме в кода. Ползва се предимно Tab който е равен на 4 space-a.
Всеки екип работи по различен стандарт, някои предпочитат да ползват само spaces, докато други използват Tab за да изместят с един таб навътре, всеки вложен tag.
# Misc
## Web
Състои се от CSS, HTML и JavaScript, където CSS е визията, HTML е съдържанието, a JavaScript е behavior-a.
Реално без HTML, нищо друго няма смисъл. Идеята е че използваме елементи, които ги подреждаме, след което ги стилизираме с CSS и ако искаме допълнителни функционалности, може да ползваме и JS.

# ChatGPT
## Difference between Tab and 4 Spaces
Using a tab and four spaces can look similar but are not the same. A tab is a single, adjustable-width character, while four spaces are four fixed-width characters. 
Tabs are more flexible but can cause alignment issues across different editors. 
Spaces ensure consistent indentation but take up more characters. The choice between tabs and spaces often depends on project style guides.

# Bookmarks 

[Lorem Ipsum - All the facts - Lipsum generator](https://www.lipsum.com/) - генериране на random текст за тестови цели.

Course completion: 01.01.2024