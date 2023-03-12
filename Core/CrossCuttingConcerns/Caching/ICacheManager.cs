using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
 public interface ICacheManager
    {

        T Get<T>(string key);

        object Get(string key);
        
        void Add(string key, object value, int duraition);//cache içinde obje olucak ne kadar duracagını da biz belirliycez

        bool IsAdd(string key);

        void Remove(string key);//cachede ne kadar süre kalacağı

        void RemoveByPattern(string pattern);//isminde categoryleri ucur gibi
    
    
    }
}
