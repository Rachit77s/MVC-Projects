using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Security
{
    public abstract class BasePage : WebViewPage
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                //Access current user details, we only want to read the value.
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }

    //Generic Model Class
    public abstract class BasePage<TModel> : WebViewPage<TModel>
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }
}