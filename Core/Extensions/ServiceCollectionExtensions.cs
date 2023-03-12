﻿using Core.Utilities.IoC;
using Core.Utilities.IOS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) 
            {
              foreach (var module in modules)
            {
            module.Load(serviceCollection);
            }
         return ServiceTool.Create(serviceCollection);//startupda gecici olarak bu satırı yazmamız yeterli olmuştu şimdi istediğmiz servisi injekte edebiliyoruz.
        
            }

        
 }

}
