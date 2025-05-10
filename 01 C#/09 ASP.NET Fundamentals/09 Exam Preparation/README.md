# In this folder, you will find solutions to some of the previous exams.

**Steps**

1. Set the connection string.
2. Scaffold the needed Identity pages.
3. Password requirments.
4. Create the entity classes. Avoid using magic numbers - constants should be defined in a separate static class to ensure code quality.
5. Add initial migration.
6. Add Controllers and Models

**Select**

In ASP.NET Core MVC, when posting a form that includes a dropdown (like Genres), the list of items (Model.Genres) is not automatically preserved after a POST. If model validation fails, you must manually reload the dropdown data in the [HttpPost] action before returning the view again — otherwise, the dropdown will be empty or broken.

**Misc**

When we have collections in the View Model of a particular type, we have to make a View Model for it and not use the Entity Model directly.