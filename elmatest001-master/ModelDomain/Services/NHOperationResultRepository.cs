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
    public class NHOperationResultRepository : IOperationResultRepository
    {
        private CalcContext db { get; set; }

        public OperationResult Create()
        {
            using (var db = new CalcContext())
            {
                return db.OperationResult.Create();
            }

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

        public Operations FindOperByName(string name)
        {
            var operation = new Operations();
            using (var db = new CalcContext())
            {
                operation = db.Operations.AsNoTracking().FirstOrDefault(o => o.Name == name);
            }
            return operation;
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
            using (var db = new CalcContext())
            {
                db.Entry<OperationResult>(operResult).State = operResult.Id == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}