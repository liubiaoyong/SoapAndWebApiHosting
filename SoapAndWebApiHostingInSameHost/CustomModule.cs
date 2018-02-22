using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoapAndWebApiHostingInSameHost
{
    public class CustomModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            
        }
    }
}