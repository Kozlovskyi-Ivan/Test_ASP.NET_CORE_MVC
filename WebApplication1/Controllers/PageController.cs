using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using PresentationLayer;
using Microsoft.AspNetCore.Mvc;
using static DataLayer.Enums.PageEnums;
using PresentationLayer.Models;

namespace WebApplication1.Controllers
{
    public class PageController : Controller
    {
        DataManager dataManager;
        ServicesManager servicesManager;

        public PageController(DataManager dataManager)
        {
            this.dataManager = dataManager;
            servicesManager = new ServicesManager(dataManager);
        }

        public IActionResult Index(int PageId, PageType pageType)
        {
            PageViewModel viewModel;
            switch (pageType)
            {
                case PageType.Directory:
                    viewModel = servicesManager.Directorys.DirectoryDBToViewModelById(PageId); break;
                case PageType.Material:
                    viewModel = servicesManager.Materials.MaterialDBModelToView(PageId); break;
                default: viewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult PageEditor(int pageId,PageType pageType, int directoryId=0)
        {
            PageEditModel editModel;

            switch (pageType)
            {
                case PageType.Directory:
                    if (pageId != 0) editModel = servicesManager.Directorys.GetDirectoryEdetModel(pageId);
                    else editModel = servicesManager.Directorys.CreateNewDirectoryEditModel();
                            break;
                case PageType.Material:
                    if (pageId != 0) editModel = servicesManager.Materials.GetMaterialEdetModel(pageId);
                    else editModel = servicesManager.Materials.CreateNewMaterialEditModel(directoryId);
                    break;
                default:editModel = null;break;
            }
            ViewBag.PageType = pageType;
            return View(editModel);
        }

        [HttpPost]
        public IActionResult SaveDirectory(DirectoryEditModel model)
        {
            servicesManager.Directorys.SaveDirectoryEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Directory });
        }

        [HttpPost]
        public IActionResult SaveMaterial(MaterialEditModel model)
        {
            servicesManager.Materials.SaveMaterialEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Material });
        }
    }
}