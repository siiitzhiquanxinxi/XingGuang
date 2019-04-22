using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DTcms.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            string url = Request.Url.ToString();
            url = Request.ServerVariables["URL"];
            if (!url.ToLower().Contains("login") && url.ToLower().Contains("aspx"))
            {
                string rId = "";
                try
                {
                    rId = Session["dt_session_admin_info"].ToString();
                }
                catch (Exception exs)
                {
                    rId = null;
                    this.Response.Redirect("~/admin/login.aspx");
                }
                if (rId == null || rId == "")
                {
                    this.Response.Redirect("~/admin/login.aspx");
                }
            }
        }
    }
}