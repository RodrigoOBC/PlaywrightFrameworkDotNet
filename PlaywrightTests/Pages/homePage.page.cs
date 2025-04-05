using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class FormPage
    {
        private readonly IPage _page;
        private readonly string _url;
        private readonly string _titlePage;
        private readonly ILocator _SearchField;
        private readonly ILocator _SearchButton;
        private readonly ILocator _NaneField;
        private readonly ILocator _LastNameField;
        private readonly ILocator _EmailField;
        private readonly ILocator _mobileField;
        private readonly ILocator _dateOfBirthField;
        private readonly ILocator _subjectField;
        private readonly ILocator _pictureField;
        private readonly ILocator _currentAddressField;
        private readonly ILocator _stateField;
        private readonly ILocator _cityField;
        private readonly ILocator _submitButton;



        public FormPage(IPage page)
        {
            _page = page;
            _url = "https://demoqa.com/automation-practice-form";
            _titlePage = "Practice Form";
            _NaneField = _page.GetByPlaceholder("First Name");
            _LastNameField = _page.GetByPlaceholder("Last Name");
            _EmailField = _page.GetByPlaceholder("name@example.com");
            _mobileField = _page.GetByPlaceholder("Mobile Number");
            _dateOfBirthField = _page.Locator("[id=\"dateOfBirthInput\"]");
            _subjectField = _page.Locator("[placeholder=\"Search\"]");
            _pictureField = _page.Locator("[placeholder=\"Search\"]");
            _currentAddressField = _page.GetByPlaceholder("Current Address");
            _stateField = _page.Locator("[placeholder=\"Search\"]");
            _cityField = _page.Locator("[placeholder=\"Search\"]");
            _submitButton = _page.GetByRole(AriaRole.Button, new() { Name = "Submit" });

        }

        public async Task NavigateToAsync()
        {
            await _page.GotoAsync(_url);
        }

        public async Task FillFirstNameAsync(string firstName)
        {
            await _NaneField.FillAsync(firstName);
        }

        public async Task FillLastNameAsync(string lastName)
        {
            await _LastNameField.FillAsync(lastName);
        }

        public async Task FillEmailAsync(string email)
        {
            await _EmailField.FillAsync(email);
        }

        public async Task FillMobileAsync(string mobile)
        {
            await _mobileField.FillAsync(mobile);
        }

        public async Task FillDateOfBirthAsync(string dateOfBirth)
        {
            await _dateOfBirthField.FillAsync(dateOfBirth);
        }

        public async Task FillCurrentAddressAsync(string currentAddress)
        {
            await _currentAddressField.FillAsync(currentAddress);
        }

        public async Task ClickSubmitButton()
        {
            await _submitButton.ClickAsync();
        }

        async Task FilledAll(string subject)
        {
            await _subjectField.FillAsync(subject);
        }

    }
}