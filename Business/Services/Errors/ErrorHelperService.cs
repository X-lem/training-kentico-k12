﻿using System;
using System.Web.Mvc;

using CMS.EventLog;
using CMS.SiteProvider;

namespace Business.Services.Errors
{
    public class ErrorHelperService : BaseService, IErrorHelperService
    {
        public int UnprocessableStatusCode => 422;

        public HttpStatusCodeResult HandleException(string source, string eventCode, Exception exception, int statusCode = 500)
        {
            LogException(source, eventCode, exception);

            return new HttpStatusCodeResult(statusCode);
        }

        public void LogException(string source, string eventCode, Exception exception) =>
            EventLogProvider.LogException(source, eventCode, exception, SiteContext.CurrentSiteID);
    }
}