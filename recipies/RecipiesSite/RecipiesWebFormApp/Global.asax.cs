using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Timers;
using System.Net;
using System.Web.Script.Serialization;
using Kendo.Mvc;
using log4net;
using RecipiesModelNS;
using System.Diagnostics;
using Microsoft.AspNet.SignalR;
using System.Web.Mvc;
using RecipiesWebFormApp.Caching;
using System.Reflection;
using System.Collections.Specialized;
using RecipiesWebFormApp.Controllers.Shared;
using RecipiesWebFormApp.Quartz.ActionsForScheduling;
using RecipiesWebFormApp.Shared;
using System.Text;

namespace RecipiesWebFormApp
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            if (!SiteMapManager.SiteMaps.ContainsKey("sitemap"))
            {
                SiteMapManager.SiteMaps.Register<XmlSiteMap>("sitemap", sitemap =>
                    sitemap.LoadFrom("~/sitemap.sitemap"));
            }

            // Code that runs on application startup
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HubConfiguration hubConfig = new HubConfiguration
            {
                EnableCrossDomain = true,
                EnableDetailedErrors = true
            };
            RouteTable.Routes.MapHubs(hubConfig);

            ActionsForScheduling.StartAll();
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((HttpApplication) sender).Context;
            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                    !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();
            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                int exceptionHttpStatusCode = httpEx.GetHttpCode();
                switch (exceptionHttpStatusCode)
                {
                    case 404:
                        action = "NotFound";
                        break;
                    case 500:
                        action = "InternalServerError";
                        break;
                        // others if any
                }
            }

            //test

            if (IsAjaxRequest())
            {
                Response.Write("Your JSON here");
                //We clear the error
                httpContext.Response.StatusCode = 500;
                Server.ClearError();
                return;
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException) ex).GetHttpCode() : 500;
            //but this is importan. It helps the brousers to display a good error page
            httpContext.Response.StatusCode = 200;

            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController) controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));

#if DEBUG
            return;
#endif
            LogentriesHelper.ApplicationLog.Error("Application_Error", ex);

        }

        //This method checks if we have an AJAX request or not
        private bool IsAjaxRequest()
        {
            //The easy way
            bool isAjaxRequest = (Request["X-Requested-With"] == "XMLHttpRequest")
                                 || ((Request.Headers != null)
                                     && (Request.Headers["X-Requested-With"] == "XMLHttpRequest"));

            //If we are not sure that we have an AJAX request or that we have to return JSON 
            //we fall back to Reflection
            if (!isAjaxRequest)
            {
                try
                {
                    //The controller and action
                    string controllerName = Request.RequestContext.
                        RouteData.Values["controller"].ToString();
                    string actionName = Request.RequestContext.
                        RouteData.Values["action"].ToString();

                    //We create a controller instance
                    DefaultControllerFactory controllerFactory = new DefaultControllerFactory();
                    Controller controller = controllerFactory.CreateController(
                        Request.RequestContext, controllerName) as Controller;

                    //We get the controller actions
                    ReflectedControllerDescriptor controllerDescriptor =
                        new ReflectedControllerDescriptor(controller.GetType());
                    ActionDescriptor[] controllerActions =
                        controllerDescriptor.GetCanonicalActions();

                    //We search for our action
                    foreach (ReflectedActionDescriptor actionDescriptor in controllerActions)
                    {
                        if (actionDescriptor.ActionName.ToUpper().Equals(actionName.ToUpper()))
                        {
                            //If the action returns JsonResult then we have an AJAX request
                            if (actionDescriptor.MethodInfo.ReturnType
                                .Equals(typeof (JsonResult)))
                                return true;
                        }
                    }
                }
                catch
                {
                }
            }

            return isAjaxRequest;
        }

        private const string StopWatchApplicationRequest = "StopWatchApplicationRequest";

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
#if DEBUG
            return;
#endif   
            HttpApplication httpApplication = sender as HttpApplication;
            int httpApplicationHash = httpApplication.GetHashCode();
            StopwatchHelper.StartNewMeasurement(StopWatchApplicationRequest + httpApplicationHash);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
#if DEBUG
            return;
#endif
            HttpApplication httpApplication = sender as HttpApplication;
            int httpApplicationHash = httpApplication.GetHashCode();
            long timeTaken = StopwatchHelper.StopLastMeasurement(StopWatchApplicationRequest + httpApplicationHash);
            string httpApplicationAsString = CreateStringFromHttpApplicationNew(httpApplication);
            string logString = string.Format("Time taken '{0}'. Params: {1}", timeTaken, httpApplicationAsString);

            if (httpApplication.User != null && httpApplication.User.Identity != null &&
                !string.IsNullOrEmpty(httpApplication.User.Identity.Name))
            {
                LogentriesHelper.ApplicationLog.Info(logString);
            }
            else
            {
                LogentriesHelper.ApplicationLog.Debug(logString);
            }
        }

        public string CreateStringFromHttpApplicationNew(HttpApplication httpApplication)
        {
            StopwatchHelper.StartNewMeasurement("test");

            StringBuilder sb = new StringBuilder();

            string formatString = " {0} : {1} ";

            sb.AppendFormat(formatString, "Server.MachineName",
             httpApplication.Server.MachineName);

            sb.AppendFormat(formatString, "User.Identity.Name",
               httpApplication.User.Identity.Name);

            sb.AppendFormat(formatString, "Request.RawUrl",
              httpApplication.Request.RawUrl.ToString());


//            sb.AppendFormat(formatString, "User.Identity.AuthenticationType",
//                httpApplication.User.Identity.AuthenticationType);
//            sb.AppendFormat(formatString, "User.Identity.IsAuthenticated",
//                httpApplication.User.Identity.IsAuthenticated);
//            sb.AppendFormat(formatString, "User.Identity.Name",
//                httpApplication.User.Identity.Name);

//            sb.AppendFormat(formatString, "Request.AnonymousID",
//                httpApplication.Request.AnonymousID);
//            sb.AppendFormat(formatString, "Request.ApplicationPath",
//                httpApplication.Request.ApplicationPath);
//            sb.AppendFormat(formatString, "Request.ApplicationPath",
//                httpApplication.Request.ApplicationPath);
//            sb.AppendFormat(formatString, "Request.AppRelativeCurrentExecutionFilePath",
//                httpApplication.Request.AppRelativeCurrentExecutionFilePath);
//            sb.AppendFormat(formatString, "Request.Browser.Browser",
//                httpApplication.Request.Browser.Browser);
//            sb.AppendFormat(formatString, "Request.ContentLength",
//                httpApplication.Request.ContentLength);
//            sb.AppendFormat(formatString, "Request.ContentType",
//                httpApplication.Request.ContentType);
//            sb.AppendFormat(formatString, "Request.CurrentExecutionFilePath",
//                httpApplication.Request.CurrentExecutionFilePath);
//            sb.AppendFormat(formatString, "Request.CurrentExecutionFilePathExtension",
//                httpApplication.Request.CurrentExecutionFilePathExtension);
//            sb.AppendFormat(formatString, "Request.FilePath",
//                httpApplication.Request.FilePath);
//            sb.AppendFormat(formatString, "Request.HttpMethod",
//                httpApplication.Request.HttpMethod);
//            sb.AppendFormat(formatString, "Request.IsAuthenticated",
//                httpApplication.Request.IsAuthenticated);
//            sb.AppendFormat(formatString, "Request.IsLocal",
//                httpApplication.Request.IsLocal);
//            sb.AppendFormat(formatString, "Request.IsSecureConnection",
//                httpApplication.Request.IsSecureConnection);
//            sb.AppendFormat(formatString, "Request.Path",
//                httpApplication.Request.Path);
//            sb.AppendFormat(formatString, "Request.PathInfo",
//                httpApplication.Request.PathInfo);
//            sb.AppendFormat(formatString, "Request.PhysicalApplicationPath",
//                httpApplication.Request.PhysicalApplicationPath);
//            sb.AppendFormat(formatString, "Request.PhysicalPath",
//                httpApplication.Request.PhysicalPath);
//            sb.AppendFormat(formatString, "Request.RawUrl",
//                httpApplication.Request.RawUrl);
//            sb.AppendFormat(formatString, "Request.RequestType",
//                httpApplication.Request.RequestType);
//            sb.AppendFormat(formatString, "Request.TotalBytes",
//                httpApplication.Request.TotalBytes);
//            if (httpApplication.Request.Url != null)
//            {
//                sb.AppendFormat(formatString, "Request.Url",
//                    httpApplication.Request.Url.ToString());
//            }
//            if (httpApplication.Request.UrlReferrer != null)
//            {
//                sb.AppendFormat(formatString, "Request.UrlReferrer",
//                    httpApplication.Request.UrlReferrer.ToString());
//            }
//            sb.AppendFormat(formatString, "Request.UserAgent",
//                httpApplication.Request.UserAgent);
//            sb.AppendFormat(formatString, "Request.UserHostAddress",
//                httpApplication.Request.UserHostAddress);

//            sb.AppendFormat(formatString, "Response.Buffer",
//              httpApplication.Response.Buffer);
//            sb.AppendFormat(formatString, "Response.BufferOutput",
//             httpApplication.Response.BufferOutput);
//            sb.AppendFormat(formatString, "Response.CacheControl",
//            httpApplication.Response.CacheControl);
//            sb.AppendFormat(formatString, "Response.CacheControl",
//         httpApplication.Response.CacheControl);
//            sb.AppendFormat(formatString, "Response.Charset",
//      httpApplication.Response.Charset);
//            sb.AppendFormat(formatString, "Response.ContentEncoding.EncodingName",
//httpApplication.Response.ContentEncoding.EncodingName);
//            sb.AppendFormat(formatString, "Response.ContentType",
//httpApplication.Response.ContentType);
//            sb.AppendFormat(formatString, "Response.Expires",
//httpApplication.Response.Expires);
//            sb.AppendFormat(formatString, "Response.Response.ExpiresAbsolute",
//httpApplication.Response.ExpiresAbsolute.ToString());
//            sb.AppendFormat(formatString, "Response.HeaderEncoding.EncodingName",
//httpApplication.Response.HeaderEncoding.EncodingName);
//            sb.AppendFormat(formatString, "Response.IsClientConnected",
//httpApplication.Response.IsClientConnected);
//            sb.AppendFormat(formatString, "Response.IsRequestBeingRedirected",
//httpApplication.Response.IsRequestBeingRedirected);
//            sb.AppendFormat(formatString, "Response.RedirectLocation",
//httpApplication.Response.RedirectLocation);
//            sb.AppendFormat(formatString, "Response.Status",
//httpApplication.Response.Status);
//            sb.AppendFormat(formatString, "Response.StatusCode",
//httpApplication.Response.StatusCode);
//            sb.AppendFormat(formatString, "Response.StatusDescription",
//httpApplication.Response.StatusDescription);
//            sb.AppendFormat(formatString, "Response.SubStatusCode",
//httpApplication.Response.SubStatusCode);
//            sb.AppendFormat(formatString, "Response.SupportsAsyncFlush",
//    httpApplication.Response.SupportsAsyncFlush);
//            sb.AppendFormat(formatString, "Response.SuppressContent",
//httpApplication.Response.SuppressContent);
//            sb.AppendFormat(formatString, "Response.SuppressFormsAuthenticationRedirect",
//httpApplication.Response.SuppressFormsAuthenticationRedirect);
//            sb.AppendFormat(formatString, "Response.TrySkipIisCustomErrors",
//httpApplication.Response.TrySkipIisCustomErrors);

//               sb.AppendFormat(formatString, "Server.MachineName",
//httpApplication.Server.MachineName);
//               sb.AppendFormat(formatString, "Server.ScriptTimeout",
// httpApplication.Server.ScriptTimeout);

//            if (Site != null)
//            {
//                sb.AppendFormat(formatString, "Site.Name",
//httpApplication.Site.Name);
//            }
     


            string result = sb.ToString();
            var test = StopwatchHelper.StopLastMeasurement("test");
            return result;
        }

        public string CreateStringFromHttpApplication(HttpApplication httpApplication)
        {
            StopwatchHelper.StartNewMeasurement("test");

            Type type = httpApplication.GetType();
            PropertyInfo[] props = type.GetProperties();

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo mainProp in props)
            {
                if (mainProp.CanRead)
                {
                    sb.AppendLine(mainProp.Name + ": " + mainProp.PropertyType.Name);
                    try
                    {
                        var propValue = mainProp.GetValue(httpApplication);


                        if (propValue != null)
                        {
                            Type subType = propValue.GetType();
                            PropertyInfo[] subProps = subType.GetProperties();
                            foreach (PropertyInfo subProp in subProps)
                            {
                                if (subProp.PropertyType != typeof (string))
                                    // || subProp.PropertyType != typeof(int) || subProp.PropertyType != typeof(double))
                                {
                                    continue;
                                }
                                try
                                {
                                    object subVal = subProp.GetValue(propValue);

                                    if (subVal != null)
                                    {
                                        sb.AppendLine("\t");
                                        sb.AppendFormat("{0} : {1}", subProp.Name, subVal);
                                    }
                                }
                                catch (ApplicationException ex)
                                {
                                    sb.AppendLine("\t");
                                    sb.AppendFormat("{0} : {1}", subProp, ex.Message);
                                }
                            }


                            //sb.AppendLine(propValue.ToString());
                        }
                        else
                        {
                            //sb.AppendLine(string.Empty);
                        }
                    }
                    catch (ApplicationException ex)
                    {
                        sb.AppendLine(ex.Message);
                    }
                }
            }
            string result = sb.ToString();
            var test = StopwatchHelper.StopLastMeasurement("test");
            return result;
        }
    }
}