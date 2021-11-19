using Core_CRUD.Infrastructure.Repositories.Interface;
using Core_CRUD.Models.DTOs;
using Core_CRUD.Models.Entities.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _appuserRepository;

        public AppUserController(IAppUserRepository appUserRepository)
        {
            this._appuserRepository = appUserRepository;
        }

        #region Create AppUser
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                _appuserRepository.Create(appUser);
                return View();
            }
            else
            {
                return View(model);
            }
        }

        #endregion

        #region List
        public IActionResult List()
        {
            return View(_appuserRepository.GetByDefaults(x => x.Status != Status.Passive));
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            AppUser appUser = _appuserRepository.GetByDefault(x => x.Id == id);
            _appuserRepository.Delete(appUser);
            return RedirectToAction("List");
        }
        #endregion

        #region Update AppUser
        public IActionResult Update (int id)
        {
            AppUser appUser = _appuserRepository.GetByDefault(x => x.Id == id);
            UpdateAppUserDTO model = new UpdateAppUserDTO();
            model.Id = appUser.Id;
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            return View(model);
        }

        [HttpPost]

        public IActionResult Update(UpdateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = _appuserRepository.GetByDefault(x => x.Id == model.Id);
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                _appuserRepository.Update(appUser);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        #endregion
    }
}
