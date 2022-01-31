using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using E2BizzEventManagementSystem.Model;
using System.Data.Entity.Core.Objects;

namespace E2BizzEventManagementSystem.DAL
{
    public  class CommonRepository<T>:ICommonRepository<T> where T : class
    {
        private readonly  EventManagementEntities  dbContext = null;
        private DbSet<T> table = null;
        public CommonRepository()
        {
            dbContext = new EventManagementEntities();
            table = dbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return table.ToList();
        }
        public T GetDetails(int id)
        {
            return table.Find(id);
        }
        public void Insert(T item)
        {
            table.Add(item);
        }
        public void Update(int id, T item)
        {
            table.Attach(item);
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(T item)
        {
            table.Remove(item);
        }
        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
        public List<GetAllEmployees_Result> GetAllEmployeesSP()
        {
            return dbContext.GetAllEmployees().ToList();
        }
        public GetEmployeeDetails_Result GetEmployeeDetailsSP(int id)
        {         
            return dbContext.GetEmployeeDetails(id).FirstOrDefault();
        }

        public  AuthenticateUser_Result authenticateUser(User user)
        {
            return dbContext.AuthenticateUser(user.Email, user.Password).FirstOrDefault();
        }

    }
}
