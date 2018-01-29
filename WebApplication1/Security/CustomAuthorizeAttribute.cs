using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models;
using WebApplication1.Security;

namespace Messageboard.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        //宣告db資料庫
        private MessageboardEntities1 db = new MessageboardEntities1();

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //判斷string.IsNullorEmpty(SessionPersister.Username),使用者登入帳號是否為空
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                //是,導入登入頁面
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Accounts", action = "Login" }));
            }
            else
            {
                //否,進入判斷身分權限是否足夠

                //customPrinCiopal,自定義身分資料
                CustomPrincipal customPrincipal = new CustomPrincipal(db.Account.FirstOrDefault(x => x.Username == SessionPersister.Username));
                //判斷roles是否有權限使用
                if (!customPrincipal.IsInRole(Roles))
                {
                    //無則導入不具權限頁面
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Accounts", action = "AccessDenied" }));
                }
            }
        }
    }
}