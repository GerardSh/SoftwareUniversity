# Action Selectors
| **Attribute**                    | **Description**                                                                                  |
| -------------------------------- | ------------------------------------------------------------------------------------------------ |
| **[ActionName(string name)]**    | Allows the method to be called under a different name in the routing system.                     |
| **[AcceptVerbs]**                | Specifies which HTTP methods (GET, POST, PUT, etc.) can access the given action.                 |
| **[HttpGet]**                    | Indicates that the method handles **GET** requests (default).                                    |
| **[HttpPost]**                   | Indicates that the method handles **POST** requests – used when submitting a form.               |
| **[HttpDelete]**                 | Allows the method to handle **DELETE** requests – often used for deleting resources.             |
| **[HttpOptions]**                | Allows the method to respond to **OPTIONS** requests, commonly used for configuring CORS.        |
| **[NonAction]**                  | Indicates that the method is **not an action**, even though it is `public`, and won't be routed. |
| **[RequireHttps]**               | Forces access to the method only through HTTPS, providing security.                              |
| **[Authorize]**                  | Requires the user to be authenticated in order to execute the action.                            |
| **[AllowAnonymous]**             | Allows unauthenticated users to access the method (opposite of `[Authorize]`).                   |
| **[ValidateAntiForgeryToken]**   | Protection against CSRF attacks – requires a valid token when submitting a form.                 |
# Validation Attributes
| **Attribute**           | **Description**                                                                   |
| ----------------------- | --------------------------------------------------------------------------------- |
| **[CreditCard]**        | Validates that the property has a valid credit card format.                       |
| **[Compare]**           | Validates that two properties in a model match (e.g., for password confirmation). |
| **[EmailAddress]**      | Validates that the property has a valid email format.                             |
| **[Phone]**             | Validates that the property has a valid telephone format.                         |
| **[Range]**             | Validates that the property value falls within the given range.                   |
| **[RegularExpression]** | Validates that the data matches the specified regular expression.                 |
| **[Required]**          | Makes the property required; value cannot be null.                                |
| **[StringLength]**      | Validates that a string property has at most the given maximum length.            |
| **[Url]**               | Validates that the property has a valid URL format.                               |
# Methods
`RedirectToAction(string actionName, string controllerName = null, object routeValues = null)` – използва се за пренасочване към друг екшън метод в същия или различен контролер след успешна операция, като например изпращане на форма.

`Redirect(string url)` – прави пренасочване към зададен URL (външен или вътрешен).

`RedirectToRoute(string routeName)` – пренасочва към определен маршрут (ако ползваш именувани маршрути).

`View()` – връща View, като търси изглед със същото име като метода.

`View(object model)` – връща View, подавайки му модел (напр. view model или DTO).

`View(string viewName)` – връща изглед с конкретно име.

`View(string viewName, object model)` – връща конкретен изглед с подаден модел.

`PartialView(string viewName, object model)` – връща частичен изглед (partial view), обикновено за AJAX или компоненти.

`Json(object data)` – връща отговор в JSON формат – често използван за API или AJAX заявки.

`BadRequest()` – връща HTTP 400 Bad Request, често при невалидни данни.

`NotFound()` – връща HTTP 404 Not Found, ако нещо не е намерено.

`Ok(object result)` – връща HTTP 200 OK с резултат – често ползвано в Web API.

`NoContent()` – връща HTTP 204 No Content – когато няма какво да се върне, но операцията е успешна.

`Content(string content)` – връща отговор с обикновен текст (например HTML или текстова информация).

`StatusCode(int statusCode)` – връща отговор с конкретен HTTP статус код и по желание – съдържание.

`File(string filePath, string contentType)` – връща файл от сървъра като отговор, като задава типа на съдържанието.

`File(byte[] fileContents, string contentType)` – връща файл с даденото съдържание като масив от байтове.

`File(Stream fileStream, string contentType)` – връща файл от поток (Stream), задавайки типа на съдържанието.

`Challenge(string[] authenticationSchemes)` – предизвиква потребителя да се автентикира с конкретни схеми на автентикация.

`Forbid()` – предотвратява достъпа до даден ресурс за потребителя (например за неупълномощени).

`Created(string location, object value)` – връща HTTP статус 201 (Created), когато е създаден нов ресурс, като задава URL на местоположението и стойността на създадения ресурс.

`Accepted(string location, object value)` – връща HTTP статус 202 (Accepted), когато ресурсът е приет, но не е завършен.
# Tag Helpers
## Form
Help with creating forms and binding model properties.

| Tag Helper           | Example                              | Description                 |
| -------------------- | ------------------------------------ | --------------------------- |
| `asp-for`            | `<input asp-for="Name" />`           | Binds to a model property   |
| `asp-validation-for` | `<span asp-validation-for="Name" />` | Shows validation messages   |
| `asp-action`         | `<form asp-action="Create">`         | Specifies the action method |
| `asp-controller`     | `<form asp-controller="Product">`    | Specifies the controller    |
| `asp-route-{value}`  | `<a asp-route-id="5">`               | Adds route values           |
## Validation
Used for displaying validation messages linked to model properties or entire forms.

|Tag Helper|Example|Description|
|---|---|---|
|`asp-validation-for`|`<span asp-validation-for="Name" class="text-danger" />`|Shows validation message for a specific property|
|`asp-validation-summary`|`<div asp-validation-summary="All" class="text-danger" />`|Displays a list of all validation errors|
|`asp-validation-summary="ModelOnly"`|`<div asp-validation-summary="ModelOnly" />`|Shows only model-level (not field-specific) errors|
|`asp-validation-summary="None"`|`<div asp-validation-summary="None" />`|Prevents rendering a summary|
## Anchor
Generates links.

|Tag Helper|Example|Description|
|---|---|---|
|`asp-controller`|`<a asp-controller="Home" asp-action="Index">`|Builds link to action|
|`asp-area`|`<a asp-area="Admin">`|Targets area route|
## Environment
Conditionally renders content based on environment.

| Tag Helper                            | Example                  | Description                                                                                                                                                                    |
| ------------------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `<environment include="Development">` | Only renders in dev mode | Renders the enclosed content only in specified environments (e.g., Development, Staging, Production). Useful for loading different scripts or styles depending on environment. |
## Cache
Caches rendered HTML.

| Tag Helper | Example                   | Description                                                                              |
| ---------- | ------------------------- | ---------------------------------------------------------------------------------------- |
| `<cache>`  | Wraps content to cache it | Caches the inner content on the server to improve performance and reduce rendering time. |
## Image & Script
Help with linking static assets.

|Tag Helper|Example|Description|
|---|---|---|
|`asp-src-include` / `asp-src-exclude`|`<script asp-src-include="*.js">`|Loads assets dynamically|
## Option & Select
Used for dropdowns.

| Tag Helper  | Example                                                        | Description               |
| ----------- | -------------------------------------------------------------- | ------------------------- |
| `asp-items` | `<select asp-for="CategoryId" asp-items="Model.Categories" />` | Generates `<option>` tags |
## Input, Label & `TextArea`
Used for binding form fields to model properties.

| Tag Helper           | Example                              | Description             |
| -------------------- | ------------------------------------ | ----------------------- |
| `asp-for` (input)    | `<input asp-for="Property" />`       | Binds input to property |
| `asp-for` (label)    | `<label asp-for="Property" />`       | Generates a label       |
| `asp-for` (textarea) | `<textarea asp-for="Description" />` | Multiline text input    |
##  Custom
 We can also **create our own** by inheriting from `TagHelper` and overriding the `Process` or `ProcessAsync` methods.