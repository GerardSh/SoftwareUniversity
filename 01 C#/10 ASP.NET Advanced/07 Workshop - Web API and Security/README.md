You want to add input fields dynamically without JavaScript using MVC.

Important:
Purely without JavaScript, dynamic UI changes on the client side are not possible, because HTML and Razor run on the server and generate a static page.

To add inputs dynamically without JS, you have to submit the form back to the server and render the page again with more input fields, i.e., a postback approach.


✅ Step 1: Create a Controller

```csharp
using Microsoft.AspNetCore.Mvc;

public class InputController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var model = new InputViewModel();

        // Ensure at least one input exists on first load
        if (model.Inputs.Count == 0)
            model.Inputs.Add(string.Empty);

        return View(model);
    }

    [HttpPost]
    public IActionResult AddInput(InputViewModel model)
    {
        model.Inputs.Add(string.Empty); // Add new empty input
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Submit(InputViewModel model)
    {
        // Process submitted inputs (model.Inputs contains the values)
        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }
}
```

✅ Step 2: Create the View Model

```csharp
using System.Collections.Generic;

public class InputViewModel
{
    public List<string> Inputs { get; set; } = new List<string>();
}
```

✅ Step 3: Create the View – Views/Input/Index.cshtml

```html
@model InputViewModel

<form asp-action="AddInput" method="post">
    @for (int i = 0; i < Model.Inputs.Count; i++)
    {
        <input type="text" name="Inputs[@i]" value="@Model.Inputs[i]" />
        <br />
    }

    <button type="submit">Add Input</button>
</form>

<form asp-action="Submit" method="post">
    @for (int i = 0; i < Model.Inputs.Count; i++)
    {
        <input type="hidden" name="Inputs[@i]" value="@Model.Inputs[i]" />
    }

    <button type="submit">Submit</button>
</form>
```

📝 Note: Two separate forms are used—one for Add Input, one for Submit. You could also merge them using asp-route or JavaScript to manage handlers.

✅ Step 4: Create a View – Views/Input/Success.cshtml

```html
<h2>Submission successful!</h2>
```

✅ Summary
Feature	Razor Pages	MVC (Controllers + Views)
Page lifecycle	OnGet, OnPost... handlers	Actions like Index, AddInput
Model binding	[BindProperty]	Action parameter InputViewModel model
Routing	Page-based (/PageName)	Controller-based (/Controller/Action)