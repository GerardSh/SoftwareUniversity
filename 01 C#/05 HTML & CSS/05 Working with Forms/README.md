forms

Forms in HTML are structures used to collect user input, such as text fields, checkboxes, radio buttons, or drop-down menus. They allow users to submit data, which can then be sent to a server for processing. Forms are created using the `<form>` element and include various input elements for gathering data.

Key parts of an HTML form:
- **`<form>`**: Defines the start of a form. It can include attributes like `action` (URL where the data will be sent) and `method` (HTTP method to use, such as GET or POST).
- **`<input>`**: Used for various types of user input like text (`<input type="text">`), password, checkbox, radio, etc.
- **`<textarea>`**: Provides a multi-line text input field.
- **`<select>`**: Creates a drop-down list for selecting options.
- **`<button>` or `<input type="submit">`**: Used to submit the form data to the server.

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

This form collects a name and email and sends it to the `/submit` endpoint using the POST method.