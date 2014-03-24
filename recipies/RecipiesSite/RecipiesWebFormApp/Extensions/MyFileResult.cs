using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting.Processing;

namespace RecipiesWebFormApp.Extensions
{
    public class MyFileResult : ActionResult
    {
        private readonly RenderingResult result;

        public MyFileResult(RenderingResult result)
        {
            this.result = result;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.RequestContext.HttpContext.Response;
            response.Clear();
            response.ContentType = result.MimeType;
            response.BinaryWrite(result.DocumentBytes);
            response.End();
        }
    }
}