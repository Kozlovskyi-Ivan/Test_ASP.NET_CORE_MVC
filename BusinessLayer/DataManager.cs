using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        private IDirectorysRepository directorysRepository;
        private IMaterialsRepository materialsRepository;

        public DataManager(IDirectorysRepository directorysRepository, IMaterialsRepository materialsRepository)
        {
            this.directorysRepository = directorysRepository;
            this.materialsRepository = materialsRepository;
        }

        public IDirectorysRepository Directorys { get { return directorysRepository; } }
        public IMaterialsRepository Materials { get { return materialsRepository; } }
    }
}
