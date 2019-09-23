using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GICMicro.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Serilog.Sinks.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace GICMicro.Controllers
{
    public class CompanyController : Controller
    {
        Models.LmsDbMyHclContext db = new Models.LmsDbMyHclContext();

        ILogger<HomeController> _logger;
        public CompanyController(ILogger<HomeController> logger)
        {

            if (logger != null)
            {
                _logger = logger;
            }
           
            

        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // GET: Company
        public ActionResult Index()
        {
            //   Log.Logger = new LoggerConfiguration()
            //.MinimumLevel
            //.Information()
            // .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200/"))
            // {
            //     AutoRegisterTemplate = true,
            // })
            //.WriteTo.File("log-" + DateTime.Now.Minute.ToString() + ".txt", Serilog.Events.LogEventLevel.Information)

            //.CreateLogger();
            _logger.LogInformation($"List of Company Data retreived on : {DateTime.UtcNow}");

           

            //  AddLogToNLog();
            return View(db.CompanyId.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //public void AddLogToNLog()
        //{

        //    var config = new NLog.Config.LoggingConfiguration();

        //    using (var fluentdTarget = new NLog.Targets.Fluentd())
        //    {
        //        fluentdTarget.Layout = new NLog.Layouts.SimpleLayout("${longdate}|${level}|${callsite}|${logger}|${message}");
        //        config.AddTarget("fluentd", fluentdTarget);
        //        config.LoggingRules.Add(new NLog.Config.LoggingRule("demo", NLog.LogLevel.Debug, fluentdTarget));
        //        var loggerFactory = new LogFactory(config);
        //        var logger = loggerFactory.GetLogger("demo");
        //        logger.Info("Log added for list of Compay Details" + DateTime.Now.ToLongDateString());
        //    }

        // }
        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CompanyId companyID = db.CompanyId.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CompanyId,CustomerCode,CompanyName,ContactName,ContactTitle,Address,City,RegionState,PostalCode,Country,PhoneNumber")] CompanyId companyID)
        {
            if (ModelState.IsValid)
            {
                db.CompanyId.Add(companyID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyID);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return  BadRequest();
            }
            CompanyId companyID = db.CompanyId.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("CompanyID1,CustomerCode,CompanyName,ContactName,ContactTitle,Address,City,RegionState,PostalCode,Country,PhoneNumber")] CompanyId companyID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyID);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CompanyId companyID = db.CompanyId.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyId companyID = db.CompanyId.Find(id);
            db.CompanyId.Remove(companyID);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
