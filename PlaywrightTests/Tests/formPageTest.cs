using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.IO;

using PlaywrightTests.Pages;

namespace PlaywrightTests;

[TestClass]
public class FormPageTest : PageTest
{
    [DataTestMethod]
    [DataRow("joão", "ninguem", "joao@teste.com", "2020555999", "28 Dec 1996", "Male", "street new", "Computer Science", "Uttar Pradesh", "Agra", "../../../temp/Bruce_Wayne_06.jpg")]
    [DataRow("Joana", "ninguem", "joana@teste.com", "2020555999", "28 Dec 1996", "Female", "street new", "Maths", "Uttar Pradesh", "Agra", "../../../temp/Bruce_Wayne_06.jpg")]
    [Description("Search for different products and verify results.")]
    public async Task Submit_WithValidDatas_Sucessfull(string firstName, string lastName, string email, string mobile, string date, string gender, string currentAddress, string subject, string state, string city, string filePath)
    {
        var formPage = new FormPage(Page);
        await formPage.NavigateToAsync();
        await formPage.CompleteForm(firstName, lastName, email, mobile, date, gender, currentAddress, subject, state, city, filePath);
        await formPage.ClickSubmitButton();
        await formPage.ValidateTable(firstName, lastName, email, mobile, date, gender, currentAddress, subject, state, city, filePath);
        



    }

    [DataTestMethod]
    [DataRow("", "ninguem", "joao@teste.com", "2656-55-7044", "28 Dec 1996", "", "street new", "Computer Science", "Uttar Pradesh", "Agra", "../../../temp/Bruce_Wayne_06.jpg")]
    // [DataRow("", "", "joana@teste.com", "", "28 Dec 1996", "", "street new", "Maths", "Uttar Pradesh", "Agra", "../../../temp/Bruce_Wayne_06.jpg")]
    [Description("Search for different products and verify results.")]
    public async Task Submit_WithoutRequiredFields_NoSucessfull(string firstName, string lastName, string email, string mobile, string date, string gender, string currentAddress, string subject, string state, string city, string filePath)
    {
        var formPage = new FormPage(Page);
        await formPage.NavigateToAsync();
        await formPage.CompleteForm(firstName, lastName, email, mobile, date, gender, currentAddress, subject, state, city, filePath);
        await formPage.ClickSubmitButton();
        await formPage.ValidateRequiredFieldsBehave(firstName, lastName, mobile, gender);
        



    }
}