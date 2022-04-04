using Microsoft.AspNetCore.Mvc;

namespace IronPdfTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet(Name = "HomeIndex")]
        public IActionResult Index()
        {
            IronPdf.ChromePdfRenderer renderer = new IronPdf.ChromePdfRenderer();
            var pdf = renderer.RenderUrlAsPdf("https://raw.githubusercontent.com/IronPdf/Iron-Pdf-Documentation/master/README.md");
            pdf.SaveAs(Path.Join(Path.GetTempPath(), "test.pdf"));

            return Ok(true);
        }
    }
}
