﻿using System;
using MiniAbp.Dependency;
using MiniAbp.Logging;
using MiniAbp.Reflection;
using MiniAbp.Route;

namespace MiniAbp
{
    public class YBootstrapper
    {
        public IocManager IocManager { get; private set; }

        public YBootstrapper() : this(IocManager.Instance)
        {
        }

        public YBootstrapper(IocManager iocManager)
        {
            IocManager = iocManager;
        }

        public void Initialize()
        { 
            YAssembly.Initialize();
            IocManager.Initialize();
        }

        public void RegisterRoute(object sender)
        {
            UrlRouting.Instance.HandleApiService(((System.Web.HttpApplication)sender),
                (response, outputJson) =>
                {
                    response.ContentType = "application/json; charset=utf-8";
                    response.Write(outputJson);
                    response.End();
                });
        }

        private void InitializeDiContainer()
        {

        }

        public void HandleException(Exception ex)
        {
            var logger = IocManager.Resolve<ILogger>();
            logger.Fatal("运行时发生未被捕获的异常。", ex);
        }
    }
}