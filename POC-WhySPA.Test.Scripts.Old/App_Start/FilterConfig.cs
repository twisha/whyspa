﻿using System.Web.Mvc;

namespace POC_WhySPA.Test.Scripts
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}