using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

using PlaywrightTests.Pages;

namespace PlaywrightTests;

[TestClass]
public class ExampleTest : PageTest
{
    [TestMethod]
    public async Task HasTitle()
    {
        var homePage = new HomePage(Page);
        await homePage.NavigateToAsync();
        await homePage.ClickSearchBox();
    }
}