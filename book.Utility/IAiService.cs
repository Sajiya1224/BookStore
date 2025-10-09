using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book.Utility
{
    public interface IAiService
    {
        Task<string> GenerateBookSummaryAsync(string bookTitle, string author, string description);
    }
}

