# General

![](Pasted%20image%2020240922091551.png)

Формите се използват основно, за да може ние като потребители, да пратим информация до сървъра или да получим информация от нашите клиенти.
## Attributes

![](Pasted%20image%2020240922092110.png)

По какъв начин да пратим информацията към сървъра. Приема две стойности - `GET` и `POST`:
### POST Method
![](Pasted%20image%2020240922092410.png)

Информацията се изпраща като част от `POST` заявката, която е скрита визуално и тези данни не се виждат от browser-a. Потребителя си въвежда данните, натиска submit и те се изпращат като скрити данни спрямо адресната лента към сървъра, но могат да се видят в dev tools.
### GET Method
![](Pasted%20image%2020240922092742.png)

Когато имаме `GET`, заявката е част от самия URL в query параметрите. Това ги прави видими в адресната лента на браузъра и лесни за проследяване. Затова `GET` не се използва за изпращане на чувствителна информация (като пароли).
## HTML Tags
### `<label>`
![](Pasted%20image%2020240922101510.png)

![](Pasted%20image%2020240922105623.png)

Позволява ни да кажем, за какво се отнася дадено поле, нещо като заглавие за полето. 
### `<input>`
![](Pasted%20image%2020240922111713.png)

Тагът `<input>` в HTML се използва за създаване на интерактивни елементи, които позволяват на потребителите да въвеждат данни. Той може да приема различни **типове** в зависимост от нуждите на формуляра.
### `<Textarea>`
![](Pasted%20image%2020240922111859.png)

**`<textarea>`** е елемент в HTML, който позволява на потребителите да въвеждат **много редове текст**.
Специфичен случай на input type text, когато искаме да добавим текст, но искаме той да е повече от един ред.
`<input>`  полетата са просто един таг, който не се затваря, докато `textaread` има отварящ и затварящ таг и вътре между двата елемента, може да си добавим content, който да се показва.
### `<select>` & `<option>`
![](Pasted%20image%2020240922112544.png)

Списък от опции, който се постига, чрез `<select>` тага и в него трябва да сложим `<option>` тагове.
### `<button>`
![](Pasted%20image%2020240922112821.png)

Използва се за най-различни цели, които може да се контролират с java script.
### `<fieldset>` & `<legend>`
![](Pasted%20image%2020240922113419.png)

Това са семантични тагове, които ни позволяват да групираме група от полета, в някаква семантична структура.
## Key Value Pairs
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Demo</title> 
</head>

<body>
    <form action="#" method="get">
        <label for="">Search</label>
        <input type="text" name="q" id="search">
        <input type="text" name="priority" id="priority">
        <input type="submit" value="Search">
    </form>
</body>
</html>
```

Може да добавяме колкото искаме input полета, в които да добавяме информация, която ще бъде пратена към сървъра като тип данни KVP. 
Key е името на полето а Value е стойността, която ние записваме или потребителя ни праща, като в общия случай е текстова информация или картинка / файл, които наричаме binary информация.
# Misc

# ChatGPT
## Forms
Forms in HTML are structures used to collect user input, such as text fields, checkboxes, radio buttons, or drop-down menus. They allow users to submit data, which can then be sent to a server for processing. Forms are created using the `<form>` element and include various input elements for gathering data.

Key parts of an HTML form:

- **`<form>`**: Defines the start of a form. It can include attributes like `action` (URL where the data will be sent) and `method` (HTTP method to use, such as GET or POST).
- **`<input>`**: Used for various types of user input like text (`<input type="text">`), password, checkbox, radio, etc.
- **`<textarea>`**: Provides a multi-line text input field.
- **`<select>`**: Creates a drop-down list for selecting options.
- **`<button>` or `<input type="submit">`**: Used to submit the form data to the server.

Example of a simple form:

```html
<form action="/submit" method="POST">
  <label for="name">Name:</label>
  <input type="text" id="name" name="name">
  
  <label for="email">Email:</label>
  <input type="email" id="email" name="email">
  
  <button type="submit">Submit</button>
</form>
```

This form collects a name and email and sends it to the `/submit` endpoint using the POST method.

The `<form>` tag in HTML is essential for creating interactive web applications. Here’s a detailed explanation of its purpose and usage:

**Purpose of the `<form>` Tag**

1. **Data Submission**: The primary purpose of a form is to collect user input and send it to a server for processing. This can include data like text entries, selections, and file uploads.
    
2. **User Interaction**: Forms enable users to interact with the website, such as signing up for newsletters, logging in, submitting feedback, or making purchases.
    
3. **Structured Data Collection**: Forms help organize data input by grouping related fields together, making it easier to manage user input.
    

**Key Attributes of the `<form>` Tag**

- **action**: Specifies the URL where the form data will be sent when submitted. This could be a server-side script that processes the data.
    
- **method**: Defines the HTTP method to be used when sending data. The most common methods are:
    
    - `GET`: Appends form data to the URL as query parameters. Suitable for non-sensitive data.
    - `POST`: Sends form data in the body of the request. Used for sensitive data or when creating/updating resources.
- **enctype**: Specifies how the form data should be encoded when submitted. Important when uploading files. Common values include:
    
    - `application/x-www-form-urlencoded` (default)
    - `multipart/form-data` (for file uploads)
    - `text/plain`
- **target**: Defines where to display the response received after submitting the form (e.g., in a new tab or within the same frame).

**Common Form Elements**

Forms can contain various input elements, such as:

- **Text fields**: `<input type="text">`
- **Password fields**: `<input type="password">`
- **Checkboxes**: `<input type="checkbox">`
- **Radio buttons**: `<input type="radio">`
- **Dropdown lists**: `<select>`
- **Text areas**: `<textarea>`
- **File uploads**: `<input type="file">`
- **Buttons**: `<button>` or `<input type="submit">`

**Example of a Basic Form**

```html
<form action="https://www.example.com/submit" method="post">
    <label for="username">Username:</label>
    <input type="text" name="username" id="username" required>
    
    <label for="password">Password:</label>
    <input type="password" name="password" id="password" required>
    
    <input type="submit" value="Login">
</form>
```

**When to Use Forms**

- **User Registrations**: When collecting user information for account creation.
- **Logins**: For user authentication.
- **Search Queries**: To allow users to search content on the site.
- **Feedback and Contact Forms**: To receive user messages or inquiries.
- **Order Forms**: In e-commerce applications for placing orders.

**Conclusion**

Forms are a fundamental part of web applications, allowing for user interaction and data collection. Understanding how to properly use the `<form>` tag and its associated elements is essential for creating effective web experiences. Forms are typically not necessary for **static websites** because static sites are primarily composed of fixed content that doesn't change based on user input.
## GET / POST Methods
**GET** and **POST** are considered **HTTP methods** (or **verbs**). They define how data is sent from a client (usually a browser) to a server as part of an HTTP request.

**Key HTTP Methods:**

- **GET**:
    
    - Used to **request** data from a server.
    - The data is typically sent as part of the URL (query parameters).
    - GET requests are **idempotent** (repeated requests have the same effect as a single request) and **safe** (they don't modify the server's state).
    - The data is visible in the URL, so it's not suitable for sensitive information.
- **POST**:
    
    - Used to **send data** to the server, typically for creating or updating resources.
    - Data is sent in the **body** of the request, not in the URL.
    - POST is not idempotent and can change the state of the server (e.g., submitting a form that creates a new record in a database).

**Other HTTP Methods:**

- **PUT**: Similar to `POST`, but often used to update a resource entirely.
- **DELETE**: Used to delete a resource on the server.
- **PATCH**: Used to partially update a resource.
- **HEAD**, **OPTIONS**, **TRACE**: These methods are used for other purposes like fetching headers, checking available methods, etc.

In summary, GET and POST are two of the most common HTTP methods used for client-server communication.
## Name - attribute
In the context of HTML forms, the `name` attribute acts like a **variable name** for the data being sent.

**How It Works:**

- When you submit a form, the data from the input fields is sent as key-value pairs to the server.
- The `name` attribute defines the **key** (or variable name), and the value entered in the input field is the **value**.

**Example:**

In your form:

```html
<input type="text" name="q" id="search">
```

- `name="q"` is the variable name (key).
- If a user types "example" into this input and submits the form, the data sent to the server would be:

```css
q=example
```

So, `q` acts as a variable name that holds the user's input value when the form is submitted. The server can then use this variable name to access and process the corresponding value.
## For - attribute
The `for` attribute in HTML forms is used with the `<label>` element to associate it with a specific form control (like an input field). This association enhances accessibility and usability for users.

**How It Works:**

- The `for` attribute should match the `id` of the corresponding input element. When the label is clicked, it focuses on the associated input field, making it easier for users to select the input.

**Example:**

```html
<form>
    <label for="username">Username:</label>
    <input type="text" id="username" name="username">
</form>
```

**Benefits:**

1. **Accessibility**: Screen readers can identify the relationship between the label and the input, improving navigation for users with disabilities.
2. **Improved Usability**: Clicking the label automatically focuses on the associated input, making forms easier to fill out, especially on touch devices.

In summary, the `for` attribute is crucial for enhancing the functionality and accessibility of forms by linking labels to their corresponding input fields.
## Key-Value Pairs (KVP) in HTML Forms

**Input Fields and KVP**: When we create an HTML form with several `<input>` fields, each field represents a key (Key), which is defined by the `name` attribute of the field, and a value (Value), which is entered by the user. When the form is submitted, these keys and values are sent to the server as part of the request (either in the URL for `GET` requests or in the body for `POST` requests).

**Example**:

```html
    <form action="#" method="get">
        <label for="">Search</label>
        <input type="text" name="q" id="search">
        <input type="text" name="priority" id="priority">
        <input type="submit" value="Search">
    </form>
```

In this example, if a user enters "example" in the search field and "high" in the priority field, the request will look like this (for a `GET` method):

```
?q=example&priority=high
```

Here, `q` and `priority` are the keys (the names of the fields), and the values entered by the user are "example" and "high," respectively.

**Types of Information**: Generally, the values sent are text data (as in this example). However, fields like `<input type="file">` can send binary information (such as images or documents). To send this kind of data, the form needs to use the `enctype="multipart/form-data"` attribute.

**Conclusion**

Yes, we can add as many fields as we want to a form, and the information will be sent to the server as Key-Value Pairs (KVP). The key is the name of the field, and the value is the information entered by the user.

**You said:**

`<input type="submit" value="Search">` what about this example? We don't have a key and the value is not user submitted?

**ChatGPT said:**

Great observation! In the case of the `<input type="submit" value="Search">` field, here's how it differs from typical form input fields:

**Explanation of the Submit Button**

1. **No Key-Value Pair**:
    
    - The submit button itself does **not** create a key-value pair that is sent to the server. Unlike text inputs, checkboxes, or other fields, the submit button’s purpose is simply to trigger the submission of the form.
    - It does not have a `name` attribute, so no data related to the button is sent with the form.
2. **Value Attribute**:
    
    - The `value="Search"` defines the **label** shown on the button. It’s what users see and click, but it doesn’t get sent to the server as part of the form data.
    - This `value` is purely for display, so it doesn't act as a user-submitted value like the data from other form fields (e.g., `input type="text"`).
3. **Purpose of Submit Button**:
    
    - The primary function of the submit button is to **submit the form** and send the data from all other input fields (those that do have keys and values) to the server.
    - Without the submit button, the form won't trigger a submission.

**Can Submit Buttons Send Data?**

- If you **add a `name` attribute** to a submit button, it **can** generate a key-value pair:
    
```html
<input type="submit" name="submitButton" value="Search">
```
    
In this case, when the form is submitted, it will send `submitButton=Search` along with the other form data. This is useful if you have multiple submit buttons in a form and need to know which one was clicked.
    
**Summary**

- The submit button by default doesn’t generate a key-value pair, and its `value` is just a label for the button. However, adding a `name` attribute to the submit button can cause it to send data as a key-value pair along with the rest of the form data.

**You said:**
We can always see the name and the value in the search query of all input tags?

**ChatGPT said:**

In **`GET` requests**, yes, you will always be able to see the **name** and **value** of all input fields in the URL as part of the search query, because `GET` requests append form data to the URL as query parameters.

**How it works:**

When you submit a form using the `GET` method, the data is appended to the URL like this:

```
?name1=value1&name2=value2
```

The **name** comes from the `name` attribute of the input fields, and the **value** is what the user enters.

**Example:**

Given the following form:

```html
<form action="https://www.example.com/search" method="get">
    <input type="text" name="q" value="search term">
    <input type="text" name="category" value="books">
    <input type="submit" value="Submit">
</form>
```

When submitted, the browser will navigate to a URL like:

```
https://www.example.com/search?q=search+term&category=books
```

You can see both the `q` and `category` as keys, with their respective values "search term" and "books."

**Important Points:**

- **Visibility**: Since the query parameters are part of the URL, they are visible to anyone who sees the URL, which is why `GET` is not suitable for sensitive information (e.g., passwords).
- **URL length**: There is a limit to the length of the URL (depending on the browser), so for very large amounts of data, the `POST` method is preferred.

In **`POST` requests**:

- The **name** and **value** pairs are **not visible** in the URL. Instead, the data is sent in the **body** of the HTTP request, making it more suitable for sending sensitive data or large amounts of data.

**You said:**

We can predefine the search value, if we select it manually?

**ChatGPT said:**

Yes, you can **predefine the search value** in an HTML form by manually setting the `value` attribute of the `<input>` field. This allows you to specify a default search term or other values that will appear when the page loads. The user can then submit the form with this predefined value, or they can change it before submitting.

**Example:**

```html
<form action="https://www.example.com/search" method="get">
    <label for="q">Search</label>
    <input type="text" name="q" id="q" value="default search term">
    <input type="submit" value="Submit">
</form>
```

**How it works:**

- In this example, the **`value="default search term"`** is predefined in the `<input>` field. When the page loads, the input box will display "default search term."
- If the user submits the form without changing the input, the URL will look like this:

```
https://www.example.com/search?q=default+search+term
```

- If the user modifies the search term, the updated value will be sent instead.

**Use Cases:**

- **Pre-populating fields**: You can use predefined values to guide the user or provide default options.
- **Preselected options**: When certain input fields should start with a common or suggested value, like a common search query, category, or username, you can predefine them for convenience.

**Summary:**

Yes, you can manually define default values in form fields, and they will be included in the query when the form is submitted. Users can either keep the predefined value or change it before submission.
# Bookmarks 

Completion: 01.01.2024