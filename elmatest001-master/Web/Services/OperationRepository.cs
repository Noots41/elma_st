using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Services
{
    public class OperationRepository : IOperationRepository
    {
        private CalcContext db { get; set; }

        public Operations Create()
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

        public IEnumerable<Operations> GetAll()
        {
            using (var db = new CalcContext())
                return db.Operations.ToList();
        }

        public Operations Load(int Id)
        {
            using (var db = new CalcContext())
                return db.Operations.FirstOrDefault(o => o.Id == Id);
        }

        public void Update(Operations operResult)
        {
            using (var db = new CalcContext())
            {
                db.Entry<Operations>(operResult).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}