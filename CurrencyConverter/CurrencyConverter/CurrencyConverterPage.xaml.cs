using Newtonsoft.Json;

namespace CurrencyConverter;

public partial class CurrencyConverterPage : ContentPage
{
    private string currencyfrom;
    private string currencyto;
    List<Currency> CurrencyList = new List<Currency>()
    {
        new Currency(){Name = "US Dollar", Code = "USD"},
        new Currency { Name = "Euro", Code = "EUR" },
        new Currency { Name = "Japanese Yen", Code = "JPY" },
        new Currency { Name = "British Pound", Code = "GBP" },
        new Currency { Name = "Swiss Franc", Code = "CHF" },
        new Currency { Name = "Canadian Dollar", Code = "CAD" },
        new Currency { Name = "Australian Dollar", Code = "AUD" },
        new Currency { Name = "New Zealand Dollar", Code = "NZD" },
        new Currency { Name = "Chinese Yuan", Code = "CNY" },
        new Currency { Name = "Hong Kong Dollar", Code = "HKD" },
        new Currency { Name = "Singapore Dollar", Code = "SGD" },
        new Currency { Name = "South Korean Won", Code = "KRW" },
        new Currency { Name = "Indian Rupee", Code = "INR" },
        new Currency { Name = "Russian Ruble", Code = "RUB" },
        new Currency { Name = "Brazilian Real", Code = "BRL" },
        new Currency { Name = "Mexican Peso", Code = "MXN" },
        new Currency { Name = "South African Rand", Code = "ZAR" }
    };
    public CurrencyConverterPage()
    {
        InitializeComponent();
        PickerFrom.ItemsSource = CurrencyList;
        PickerTo.ItemsSource = CurrencyList;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("apikey", "PdDWh4uKXNQLZwSANm5Ya0ZEW2SZoZN6");
        var response = await httpClient.GetStringAsync($"https://api.apilayer.com/exchangerates_data/convert?to={currencyto}&from={currencyfrom}&amount={EntAmount.Text}");
        var currencyresult = JsonConvert.DeserializeObject<Root>(response);
        LblResult.Text =  Math.Round(currencyresult.Result,2) + currencyto;
    }

    private void PickerFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = PickerFrom.SelectedItem as Currency;
        currencyfrom = selectedItem.Code;
    }

    private void PickerTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = PickerTo.SelectedItem as Currency;
        currencyto = selectedItem.Code;
    }
}