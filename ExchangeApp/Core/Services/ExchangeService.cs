using ExchangeApp.Core.Models;
using SQLite;
using System.Linq.Expressions;

namespace ExchangeApp.Core.Services;

public class ExchangeService : IExchangeService
{
    private const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
    private readonly SQLiteConnection _conn;
    private TableQuery<Exchange> _table;

    public ExchangeService(string connStr)
    {
        _conn = new SQLiteConnection(connStr, Flags);
        _conn.CreateTable<Exchange>();
        _table = _conn.Table<Exchange>();
    }

   
    public Exchange GetExchange(Expression<Func<Exchange, bool>> expression)
    {
        return _table.First(expression);
    }

    public List<Exchange> GetExchangeList()
    {
        return _table.ToList();
    }

    public List<Exchange> GetExchangeList(Expression<Func<Exchange, bool>> expression)
    {
        return _table
            .Where(expression)
            .ToList();
    }



    public bool AddExchange(Exchange exchange)
    {
        var result = _conn.Insert(exchange);

        return result == (int)NotifyTableChangedAction.Insert;
    }

    public bool DeleteExchange(int id)
    {
        var model = _table.First(x => x.Id == id);

        if (model is null)
            return false;

        var result = _conn.Delete(model);

        return result == (int)NotifyTableChangedAction.Delete;
    }

    public bool UpdateExchange(Exchange exchange)
    {
        var result = _conn.Update(exchange);

        return result == (int)NotifyTableChangedAction.Update;
    }
}
