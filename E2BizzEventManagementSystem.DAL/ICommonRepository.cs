using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2BizzEventManagementSystem.DAL
{
    public  interface ICommonRepository<T>
    {
        List<T> GetAll();
        T GetDetails(int id);
        void Insert(T item);
        void Update(int id, T item);
        void Delete(T item);
        //Commit
        int SaveChanges();
    }
}
