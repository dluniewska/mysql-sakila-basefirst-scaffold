using System;
using System.Collections.Generic;

namespace mysql_database.sakila;

public partial class SalesByFilmCategory
{
    public string Category { get; set; } = null!;

    public decimal? TotalSales { get; set; }
}
