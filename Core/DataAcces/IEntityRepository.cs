//core kadamanı diğer katmanları referans almaz
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.DataAccess.Core
//IEntitiy nin implement ettiği diğer şeyler-kısıtladık

{//bu generc classları kısıtlamamız gerekir aka generic constrain int gibi referans tip gelemsin diye
    public interface IEntityRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//bir filtre de verilmeyebiir anlamda bir kere yazılcak bir kod

        T Get(Expression<Func<T, bool>> filter);// categorye göre getirmeye gereksnimiz yok.

        // void Add(T entitiy);
        public void Add(T entitiy);

        public void Update(T entitiy);

        public void Delete(T entitiy);

        //List<T> GetAllByCategory(int categoryId);
    }
}
