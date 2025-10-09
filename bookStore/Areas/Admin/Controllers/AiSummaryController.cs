using book.dataAccess.Repository.IRepository;
using book.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AiSummaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAiService _aiService;
        private readonly ILogger<AiSummaryController> _logger;

        public AiSummaryController(
            IUnitOfWork unitOfWork,
            IAiService aiService,
            ILogger<AiSummaryController> logger)
        {
            _unitOfWork = unitOfWork;
            _aiService = aiService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateForProduct(int productId)
        {
            var product = _unitOfWork.product.Get(u => u.Id == productId);
            
            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.AiSummary))
            {
                TempData["info"] = "Product already has an AI summary. Regenerating...";
            }

            _logger.LogInformation("Generating AI summary for product {ProductId}: {ProductTitle}", product.Id, product.Title);

            var summary = await _aiService.GenerateBookSummaryAsync(
                product.Title,
                product.Author,
                product.Description);

            product.AiSummary = summary;
            _unitOfWork.product.Update(product);
            _unitOfWork.Save();

            _logger.LogInformation("AI summary generated successfully for product {ProductId}", product.Id);

            TempData["success"] = $"AI summary generated successfully for '{product.Title}'";
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> GenerateForAll()
        {
            var products = _unitOfWork.product.GetAll();
            int count = 0;
            int errors = 0;

            foreach (var product in products)
            {
                try
                {
                    // Generate if missing, or if a previous attempt stored an error placeholder
                    var needsGeneration = string.IsNullOrWhiteSpace(product.AiSummary)
                        || product.AiSummary.StartsWith("Unable to generate", StringComparison.OrdinalIgnoreCase)
                        || product.AiSummary.StartsWith("Error generating", StringComparison.OrdinalIgnoreCase);

                    if (needsGeneration)
                    {
                        _logger.LogInformation("Generating AI summary for product {ProductId}: {ProductTitle}", product.Id, product.Title);

                        var summary = await _aiService.GenerateBookSummaryAsync(
                            product.Title,
                            product.Author,
                            product.Description);

                        if (!string.IsNullOrWhiteSpace(summary))
                        {
                            product.AiSummary = summary;
                            _unitOfWork.product.Update(product);
                            count++;
                        }
                        else
                        {
                            // Store error message when generation fails
                            product.AiSummary = "Unable to generate AI summary. Please try again later.";
                            _unitOfWork.product.Update(product);
                            errors++;
                        }

                        await Task.Delay(1000);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error generating summary for product {ProductId}", product.Id);
                    errors++;
                }
            }

            _unitOfWork.Save();

            if (errors > 0)
            {
                TempData["warning"] = $"Generated {count} AI summaries. {errors} failed.";
            }
            else
            {
                TempData["success"] = $"Successfully generated AI summaries for {count} products";
            }

            return RedirectToAction("Index", "Product");
        }
    }
}

