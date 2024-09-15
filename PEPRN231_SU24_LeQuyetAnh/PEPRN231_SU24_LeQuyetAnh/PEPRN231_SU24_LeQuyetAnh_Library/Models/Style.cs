using System;
using System.Collections.Generic;

namespace PEPRN231_SU24_LeQuyetAnh_Library.Models;

public partial class Style
{
    public string StyleId { get; set; } = null!;

    public string StyleName { get; set; } = null!;

    public string StyleDescription { get; set; } = null!;

    public string? OriginalCountry { get; set; }
}
