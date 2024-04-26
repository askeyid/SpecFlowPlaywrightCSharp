using SpecFlowPlaywrightCSharp.Drivers;
using SpecFlowPlaywrightCSharp.Pages;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPlaywrightCSharp.StepDefinitions
{
    [Binding]
    public sealed class EAAppTestSteps
    {
        private readonly Driver _driver;
        private readonly LoginPage _loginPage;

        public EAAppTestSteps(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Page.GotoAsync("http://www.eaapp.somee.com");
        }

        [Given(@"I click login link")]
        [Obsolete]
        public async Task GivenIClickLoginLink()
        {
            await _loginPage.ClickLogin();
        }

        [Given(@"I enter following login details")]
        public async Task GivenIEnterFollowingLoginDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _loginPage.Login((string)data.UserName, (string)data.Password);
        }

        [Then(@"I see Employee Lists")]
        public async Task ThenISeeEmployeeLists()
        {
            var isExist = await _loginPage.IsEmployeeDetailsExists();
            isExist.Should().Be(false);
        }

    }
}
