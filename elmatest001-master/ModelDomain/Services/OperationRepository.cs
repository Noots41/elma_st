using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Services;

namespace Services
{
    public class OperationRepository : IOperationRepository
    {
        private CalcContext db { get; set; }

        public Operation Create()
        {
            using (var db = new CalcContext())
            {
                return db.Operations.Create();
            }
                
        }

        public bool Delete(int Id)
        {
            using (var db = new CalcContext())
            {
                var item = Load(Id);
                if (item == null)
                    return false;

                db.Operations.Remove(item);
                db.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Operation> GetAll()
        {
            using (var db = new CalcContext())
                return db.Operations.ToList();
        }

        public Operation Load(int Id)
        {
            using (var db = new CalcContext())
                return db.Operations.FirstOrDefault(o => o.Id == Id);
        }

        public void Update(Operation operResult)
        {
            using (var db = new CalcContext())
            {
                db.Entry<Operation>(operResult).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}