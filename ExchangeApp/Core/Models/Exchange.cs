using SQLite;

namespace ExchangeApp.Core.Models;

public class Exchange
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Currencies { get; set; }
}
