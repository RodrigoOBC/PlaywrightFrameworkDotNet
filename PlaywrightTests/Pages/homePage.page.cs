using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly string _url;
        private readonly string _titlePage ;
        private readonly ILocator _SearchField ;
        private readonly ILocator _SearchButton;
        private readonly string[] _ProductsTarget;



        public HomePage(IPage page)
        {
            _page = page;
            _url = "http://www.automationpractice.pl/index.php";
            _titlePage = "My Shop";
            _SearchField = _page.Locator("[placeholder=\"Search\"]");
            _SearchButton = _page.Locator("[name=\"submit_search\"]");
            _ProductsTarget = new string[] { "Faded Short Sleeve T-shirts", "Printed Dress"};
            
        }

        public async Task NavigateToAsync()
        {
            await _page.GotoAsync(_url);
        }

        public async Task ClickSearchBox()
        {
            await _SearchField.ClickAsync();
        }

        public async Task ClickSearchButton()
        {
            await _SearchButton.ClickAsync();
        }
    }
}