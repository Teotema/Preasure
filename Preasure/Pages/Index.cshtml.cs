using DataTransferObjects;
using DbServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace Preasure.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDynamicDbService _dbServise;
        public List<PresureDto> Presures { get; private set; } = new ();
        public IndexModel(ILogger<IndexModel> logger, IDynamicDbService dbServise)
        {
            _logger = logger;
            _dbServise = dbServise;
        }

        public  void OnGet()
        {
            var p =  _dbServise.GetPresuares();
            p.Wait();
            Presures = p.Result.ToList();
        }
    }
}