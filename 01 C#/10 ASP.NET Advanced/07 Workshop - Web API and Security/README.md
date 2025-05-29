you want to add input fields dynamically without JavaScript on a Razor Page.

Important:
Purely without JavaScript, dynamic UI changes on the client side are not possible, because HTML and Razor run on the server and generate a static page.

To add inputs dynamically without JS, you have to submit the form back to the server and render the page again with more input fields, i.e., a postback approach.

How to do it in Razor Pages (without JavaScript):
You can do this with a form submit (postback), and on each submit, you add one more input to the model, then render the form again with the increased number of inputs.

Example:
Step 1: Create a model property to hold the list of inputs
In your Razor Page model (C#):

```csharp
public class MyPageModel : PageModel
{
    [BindProperty]
    public List<string> Inputs { get; set; } = new List<string>();

    public void OnGet()
    {
        // On first load, start with one input
        if (Inputs.Count == 0)
            Inputs.Add(string.Empty);
    }

    public IActionResult OnPostAddInput()
    {
        // Add a new empty input on each postback
        Inputs.Add(string.Empty);
        return Page();
    }

    public IActionResult OnPostSubmit()
    {
        // Handle final form submission here
        // Inputs list contains all inputs submitted
        return RedirectToPage("Success");
    }
}
```
Step 2: In your Razor Page (.cshtml):

```html
<form method="post">
    @for (int i = 0; i < Model.Inputs.Count; i++)
    {
        <input type="text" name="Inputs[@i]" value="@Model.Inputs[i]" />
        <br />
    }

    <button type="submit" asp-page-handler="AddInput">Add Input</button>
    <button type="submit" asp-page-handler="Submit">Submit</button>
</form>
```

Explanation:
You start with a list of inputs in the model.

The page renders all inputs from the list.

When the Add Input button is clicked, it triggers the OnPostAddInput handler.

That handler adds a new empty string to the list, so next render has one more input field.

You re-render the form with the new inputs count.

When you click Submit, the OnPostSubmit handler processes all inputs.

Summary:
With JavaScript	Without JavaScript (Postback)
Instant client-side add	Submit form, server adds input, re-render page
Smooth UX	Page reload after every add
No server postbacks	Requires postbacks