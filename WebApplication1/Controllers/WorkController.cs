using Messageboard.Security;
using System.Web.Mvc;

namespace Messageboard.Controllers
{
    public class Work : Controller
    {
        //work1,限制權限Admin能進入此ActionResult,非則導入Web.config預設路徑
        //[CustomAuthorize(Roles = "Admin")]
        public ActionResult Work1()
        {
            return View();
        }
        //work2,限制權限admin,teacher能進入此actionResult,非則導入Web.config預設路徑
        [CustomAuthorize(Roles = "Admin,Teacher")]
        public ActionResult Work2()
        {
            return View();
        }
        //work2,限制權限admin,teacher,student能進入此actionresult,非則導入Web.config預設路徑
        [CustomAuthorize(Roles = "Admin,Teacher,Student")]
        public ActionResult Work3()
        {
            return View();
        }
    }
}