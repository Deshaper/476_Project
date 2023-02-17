using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVC476.Controllers;

public class Mytest : Controller
{
    // 
    // GET: /Mytest/Index
    // equal to /Mytest, because index() is defualt path
    // controller = Mytest. action = index,

    //app.MapControllerRoute(
   // name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");

    //Use the "View" that connect to this controller
    // return ActionResult and IActionResult 's class
    // The defualt controller did not point to a specific url
    // Then itll turn to the default page, which is 
    // Views/Mytest/Index.cshtml
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name, int numtime=1)
    {
        // HtmlEnconder.Default.Encoder use to prevent mean input
        ///Mytest/Welcome?name=Jay&numtime=4
        // return HtmlEncoder.Default.Encode($"Hello {name}, your numtime is {numtime}");
        ViewData["name"] = "Hello" + name;
        ViewData["numtime"] = numtime;
        return View();
    }
}
