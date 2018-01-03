using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Security
{
    public static class SessionPersister
    {
        //預設值
        static string usernameSesstionvar = "username";

        public static string Username
        {
            get
            {
                //判斷當前資料是否為空
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[SessionPersister.usernameSesstionvar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSesstionvar] = value;
            }
        }
    }
}