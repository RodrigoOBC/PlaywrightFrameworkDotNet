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
            _subjectField = _page.Locator("[id=\"subjectsInput\"]");
            _pictureField = _page.Locator("[placeholder=\"Search\"]");
            _currentAddressField = _page.GetByPlaceholder("Current Address");
            _stateField = _page.GetByText("Select State");
            _cityField = _page.GetByText("Select City");
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
        public async Task SelectGender(string gender)
        {
            var genderRadioButtonawait = _page.GetByText(gender, new() { Exact = true });
            await genderRadioButtonawait.ClickAsync();
            
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

        async Task FilledSubject(string subject)
        {   
            await _subjectField.ClickAsync();
            await _subjectField.FillAsync(subject);
            await _page.PauseAsync();
            await _page.GetByText(subject, new() { Exact = true }).Nth(1).ClickAsync();
        }

        public async Task SelectState(string state)
        {
            await _stateField.ClickAsync();
            await _page.GetByText(state).ClickAsync();
        }
        public async Task SelectCity(string city)
        {
            await _cityField.ClickAsync();
            await _page.GetByText(city,new() { Exact = true }).ClickAsync();
        }
        public async Task UploadPicture(string filePath)
        {
            await _pictureField.SetInputFilesAsync(filePath);
        }

        // public async Task CompleteForm(string firstName, string lastName, string email, string mobile, string dateOfBirth, string currentAddress, string subject, string state, string city, string filePath)
        // {
        //     await FillFirstNameAsync(firstName);
        //     await FillLastNameAsync(lastName);
        //     await FillEmailAsync(email);
        //     await FillMobileAsync(mobile);
        //     await FillDateOfBirthAsync(dateOfBirth);
        //     await FillCurrentAddressAsync(currentAddress);
        //     await FilledAll(subject);
        //     await SelectState(state);
        //     await SelectCity(city);
        //     await UploadPicture(filePath);
        // }
        public async Task CompleteForm(string firstName, string lastName, string email,string mobile,string dateOfBirth, string gender, string currentAddress,string subject, string state, string city)
        {
            await FillFirstNameAsync(firstName);
            await FillLastNameAsync(lastName);
            await FillEmailAsync(email);
            await FillMobileAsync(mobile);
            await FillDateOfBirthAsync(dateOfBirth);
            await SelectGender(gender);
            await FillCurrentAddressAsync(currentAddress);
            await FilledSubject(subject);
            await SelectState(state);
            await SelectCity(city);
            // await UploadPicture(filePath);
        }

    }
}