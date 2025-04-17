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
`RedirectToAction(string actionName, string controllerName = null, object routeValues = null)` – използва се за пренасочване към друга екшън метод в същия или различен контролер след успешна операция, като например изпращане на форма.