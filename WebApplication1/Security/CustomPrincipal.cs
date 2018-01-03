using System.Linq;
using System.Security.Principal;
using WebApplication1.Models;

namespace Messageboard.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account account;
        //宣告account變數
        public CustomPrincipal(Account account)
        {
            //將帳號資料存入customprincipal的account
            this.account = account;
            //將username存入customprincipital的identity
            this.Identity = new GenericIdentity(account.Username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            //role規則已"，"排入陣列
            var roles = role.Split(new char[] { ',' });
            //any()判斷是否包含任何項目
            return roles.Any(x => this.account.Role.Contains(x));
        }
    }
}