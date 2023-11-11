using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExchangeApp.Core.Models;
using ExchangeApp.Core.Services;
using FmgLib.HttpClientHelper;

namespace ExchangeApp.ViewModels;

public partial class ExchangesViewModel : ObservableObject
{
    private readonly IExchangeService _exchangeService;

    public ExchangesViewModel(IExchangeService exchangeService)
    {
        _exchangeService = exchangeService;
        LoadingExchanges();
    }

    [ObservableProperty]
    private Tarih_Date _data;

    //[RelayCommand]
    public async Task LoadingExchanges()
    {
        var exchange = _exchangeService.GetExchangeList()?.FirstOrDefault(x => x.Date.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"));

        if (exchange is null)
        {
            var tarihDate = await HttpClientHelper.SendAsync<Tarih_Date>("https://www.tcmb.gov.tr/kurlar/today.xml", HttpMethod.Get);
            tarihDate.TryParseToXml(out string xmlStr);
            exchange = new()
            {
                Date = DateTime.Now,
                Currencies = xmlStr
            };

            _exchangeService.AddExchange(exchange);
        }

        Data = GetCurrencies(exchange);
    }

    public Tarih_Date GetCurrencies(Exchange exchange)
    {
        if (exchange.Currencies.TryParseFromXml(out Tarih_Date exchangesList))
            return exchangesList;

        return exchangesList;
    }
}
