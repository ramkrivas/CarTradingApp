using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Demo.CarTrade.Repository
{
    public class CarTradeRepository<T> : IRepository<T> where T : class
    {
        private CarTradeContext context;
        private readonly DbSet<T> dbSet;

        public CarTradeRepository()
        {
            context = new CarTradeContext();
            dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() => dbSet.ToList());
        }
        public async Task<T> GetById(object Id)
        {
            return await Task.Run(() => dbSet.Find(Id));
        }
        public T Add(T obj)
        {
            dbSet.Add(obj);
            Save();
            return obj;
        }
        public T Update(T obj)
        {
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            Save();
            return obj;
        }
        public void Delete(object Id)
        {
            T entityToDelete = dbSet.Find(Id);
            Delete(entityToDelete);
        }
        public void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            Save();
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.Write(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                Console.Write(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                Console.Write(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.Write(ex.InnerException);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }
        protected virtual void Dispose(bool disposing)
        {  
            if (disposing) {  
                if (context != null) {  
                    context.Dispose();  
                    context = null;  
                }
            }  
         }  
    }
}
