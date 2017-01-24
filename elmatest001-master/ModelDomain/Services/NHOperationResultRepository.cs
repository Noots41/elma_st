using DomainModel.Helpers;
using Models;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services
{
    public class NHOperationResultRepository : 
        IOperationResultRepository
    {
        private CalcContext db { get; set; }

        public OperationResult Create()
        {
            return new OperationResult() { Id = 0 };
        }

        public bool Delete(int Id)
        {
            using (var db = new CalcContext())
            {
                var item = Load(Id);
                if (item == null)
                    return false;

                db.OperationResult.Remove(item);
                db.SaveChanges();
                return true;
            }
        }

        public Operation FindOperByName(string name)
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(Operation));
                criteria.Add(Restrictions.Eq("Name", name));
                criteria.SetMaxResults(1);
                return criteria.List<Operation>().FirstOrDefault();
            }
        }

        public Users GetDefault()
        {

            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(Users));
                criteria.Add(Restrictions.Eq("Id", 1));
                criteria.SetMaxResults(1);
                return criteria.List<Users>().FirstOrDefault();
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            var operations = new List<OperationResult>();
            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(OperationResult));
                //criteria.Add(Restrictions.Ge("Id", 3));
                operations = criteria.List<OperationResult>().ToList();
            }
            return operations;
        }

        public OperationResult Load(int Id)
        {
            using (var db = new CalcContext())
                return db.OperationResult.FirstOrDefault(o => o.Id == Id);
        }

        public void Update(OperationResult operResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(operResult);
                    }
                    catch (Exception e)
                    {
                        //вывод е в лог
                        transaction.Rollback();
                        throw;
                    }
                    transaction.Commit();
                }

            }
        }
    }
}