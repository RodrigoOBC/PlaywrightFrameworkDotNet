using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

using PlaywrightTests.Pages;

namespace PlaywrightTests;

[TestClass]
public class HomePageTest : PageTest
{
    [DataTestMethod]
    [DataRow("Faded Short Sleeve T-shirts")]
    [DataRow("Blouse")]
    [DataRow("Printed Dress")]
    [Description("Search for different products and verify results.")]
    public async Task Search_WithValidProducts_Sucessfull(string product)
    {
        var homePage = new HomePage(Page);
        await homePage.NavigateToAsync();
        await homePage.ClickSearchBox();
        var productElement =  await homePage.SearchProduct(product);
        await Expect(productElement).Not.ToHaveCountAsync(0);
    }
}