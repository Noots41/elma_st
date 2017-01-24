using System.Linq;
using System.Web.Mvc;
using Calc;
using Web.Models;
using System.Diagnostics;
using Services;
using DomainModel.Helpers;
using Models;

namespace Web.Controllers
{
    public class CalcController : Controller
    {
        private IOperationResultRepository repository { get; set; }

        public CalcController()
        {
            repository = new NHOperationResultRepository();
        }

        // GET: Calc
        public ActionResult Index()
        {
            var opers = CalcService.GetInstance().Calculator.GetOperationNames().Select(o => new SelectListItem() { Text = o, Value = o });
            ViewBag.Operations = opers;
            return View(new OperationModel());
        }

        public ActionResult Execute(OperationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = CalcService.GetInstance().Calculator.Execute(model.Name, model.GetParameters());

            stopWatch.Stop();

            var operResult = repository.Create();

            operResult.ArgumentCount = model.GetParameters().Count();
            operResult.Arguments = string.Join(",", model.GetParameters());

           
            //operResult.OperationId = repository.FindOperByName(model.Name).Id;
            operResult.Operation = repository.FindOperByName(model.Name);
            //operResult.Users = repository.GetDefault();
            operResult.Result = result.ToString();
            operResult.ExetTimeMs = stopWatch.ElapsedMilliseconds;

            using (var session = NHibernateHelper.OpenSession())
            {
                operResult.Users = session.Get<Users>(1);
            }


                repository.Update(operResult);

            ViewData.Model = $"result = {result}";
            return View();
        }
    }
}

