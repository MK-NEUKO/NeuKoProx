using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NeuKoProx.Pages.Error
{
    public class _502Model : PageModel
    {
        public new int StatusCode { get; set; }

        public void OnGet(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
