using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;
using BusinessLayer;
using PresentationLayer.Models;
using PresentationLayer;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext context;
        //private IDirectorysRepository dirRep;
        private DataManager dataManager;
        private ServicesManager servicesManager;
        public HomeController(/*EFDBContext context, IDirectorysRepository dirRep,*/ DataManager dataManager)
        {
            //this.context = context;
            //this.dirRep = dirRep;
            this.dataManager = dataManager;
            servicesManager = new ServicesManager(dataManager);
        }

        public IActionResult Index()
        {
            HelloModel helloModel = new HelloModel() { HelloMassage = "Hi man!" };
            //List<Directory> dirs = context.Directory.Include(x=>x.Materials).ToList();
            //List<Directory> dirs = dirRep.GetAllDirectorys().ToList();
            //List<Directory> dirs = dataManager.Directorys.GetAllDirectorys(true).ToList();
            List<DirectoryViewModel> dirs = servicesManager.Directorys.GetDirectoryesList();
            return View(dirs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
