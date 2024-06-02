﻿namespace Lab3.API.Models;

public class PaginationResponse<TModel> where TModel : class
{
    public IEnumerable<TModel> Items { get; set; } = new List<TModel>();
    public int Total { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
