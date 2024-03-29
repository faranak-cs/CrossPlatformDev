// Author: Faran Ahmad Khan
// Author Email: L00179451@atu.ie

using EquityX.Maui.ViewModels;
using EquityX.Maui.Views.Funds;

namespace EquityX.Maui.Views;
public partial class HomePage : ContentPage
{
    // CREATE OBJECT OF USER CLASS
    private Models.User User = HomePageViewModel.GetUserById(0);
    public HomePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var user = HomePageViewModel.GetUserById(User.Id);
        CurrentUser.Text = "Hi, " + user.Name;
        AvailableFunds.Text = "$" + user.Funds.ToString();
        TotalSum.Text = "$" + PortfolioPageViewModel.GetTotalSum().ToString();
    }

    // ADD BUTTON
    private async void btnAddFunds_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AddFunds)}?id={User.Id}");
    }

    // WITHDRAW BUTTON
    private async void btnWithdrawFunds_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(WithdrawFunds)}?id={User.Id}");

    }

    // GO TO PORTFOLIO PAGE
    private void imgPortfolio_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(PortfolioPage));
    }

    // GO TO SUMMARY PAGE
    private void imgSummary_Tapped(object sender, TappedEventArgs e)
    {
        PortfolioPageViewModel.UpdateSummary();
        Shell.Current.GoToAsync(nameof(SummaryPage));
    }

    // GO TO STOCKS PAGE
    private void imgStocks_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(StocksPage));
    }

    // GO TO CRYPTO PAGE
    private void imgCrypto_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(CryptoPage));
    }

    // GO TO MARKET PAGE
    private void imgMarket_Tapped(object sender, TappedEventArgs e)
    {

        Shell.Current.GoToAsync(nameof(MarketPage));
    }
}