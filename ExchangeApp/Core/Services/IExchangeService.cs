using ExchangeApp.Core.Models;
using System.Linq.Expressions;

namespace ExchangeApp.Core.Services;

public interface IExchangeService
{
    List<Exchange> GetExchangeList();
    List<Exchange> GetExchangeList(Expression<Func<Exchange, bool>> expression);
    Exchange GetExchange(Expression<Func<Exchange, bool>> expression);

    bool AddExchange(Exchange exchange);
    bool UpdateExchange(Exchange exchange);
    bool DeleteExchange(int id);
}
