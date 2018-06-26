namespace CalculatorMvc.Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using static CalculatorMvc.Logs.Logs;

    /// <summary>
    /// Get logs class
    /// </summary>
    public static class GetLogs
    {
        /// <summary>
        /// Get Log method
        /// </summary>
        /// <param name="html">Helper</param>
        /// <returns></returns>
        public static List<MvcHtmlString> GetLog(this HtmlHelper html)
        {
            List<MvcHtmlString> getLog = new List<MvcHtmlString>();

            foreach (var log in LogList)
            {
                getLog.Add(new MvcHtmlString(log));
            }

            return getLog;
        }
    }
}