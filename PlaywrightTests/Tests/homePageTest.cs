using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

using PlaywrightTests.Pages;

namespace PlaywrightTests;

[TestClass]
public class FormPageTest : PageTest
{
    [DataTestMethod]
    [Description("Search for different products and verify results.")]
    public async Task Search_WithValidProducts_Sucessfull()
    {
        var formPage = new FormPage(Page);
        await formPage.NavigateToAsync();
        await formPage.ClickSubmitButton();
    }
}