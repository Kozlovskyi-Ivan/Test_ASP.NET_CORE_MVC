using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using PresentationLayer;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager dataManager;
        private DirectoryService directoryService;
        private MaterialService materialService;

        public ServicesManager(DataManager dataManager)
        {
            this.dataManager = dataManager;
            directoryService = new DirectoryService(dataManager);
            materialService = new MaterialService(dataManager);
        }
        public DirectoryService Directorys { get { return directoryService; } }
        public MaterialService Materials { get { return materialService; } }
    }
}
