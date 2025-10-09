using System;
using System.Threading.Tasks;

namespace book.Utility
{
    public class MockAiService : IAiService
    {
        public Task<string> GenerateBookSummaryAsync(string bookTitle, string author, string description)
        {
            // Generate a mock summary based on the book details
            var summary = $"This captivating book '{bookTitle}' by {author} offers readers an engaging narrative that explores compelling themes. {description.Substring(0, Math.Min(description.Length, 100))}... This work promises to deliver an immersive reading experience that will resonate with audiences seeking quality literature.";
            
            return Task.FromResult(summary);
        }
    }
}
