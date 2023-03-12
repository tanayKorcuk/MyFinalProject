using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC//core katmanımızda yaptığımız tüm injectionlar için bir katman olusturduk
{
   public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);

    
    }
}
