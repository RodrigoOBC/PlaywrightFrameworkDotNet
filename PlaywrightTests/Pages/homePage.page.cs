using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly string _url;
        private readonly string _titlePage;
        private readonly ILocator _SearchField;
        private readonly ILocator _SearchButton;



        public HomePage(IPage page)
        {
            _page = page;
            _url = "http://www.automationpractice.pl/index.php";
            _titlePage = "My Shop";
            _SearchField = _page.Locator("[placeholder=\"Search\"]");
            _SearchButton = _page.Locator("[name=\"submit_search\"]");

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

        public ILocator GetProductsTarget(string product)
        {
            ILocator ProductsTargetElement = _page.GetByRole(AriaRole.Link, new() { Name = product });
            return ProductsTargetElement;
        }

        public async Task<ILocator> SearchProduct(string product)
        {
            await _SearchField.FillAsync(product);
            await _SearchButton.ClickAsync();
            ILocator productLink = GetProductsTarget(product);
            return productLink;
        }
    }
}