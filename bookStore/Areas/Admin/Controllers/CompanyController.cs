using book.dataAccess.data;
using book.dataAccess.Repository.IRepository;
using book.Model;
using book.Model.View_model;
using book.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace bookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
  
        }
        public IActionResult Index()
        {
           List<Company> CompanyObj = _unitOfWork.company.GetAll().ToList();
       
           return View(CompanyObj);
        }

        public IActionResult Upsert(int? id)
        {
           
            if(id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyObj = _unitOfWork.company.Get(p => p.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {

                if(companyObj.Id == 0)
                {
                    _unitOfWork.company.Add(companyObj);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.company.Update(companyObj);
                    TempData["success"] = "Company updated successfully";
                }


                _unitOfWork.Save();
                
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View(companyObj);
            }
        }


        #region API CALLS    

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> CompanyObj = _unitOfWork.company.GetAll().ToList();
            return Json(new {data = CompanyObj});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.company.Get(p => p.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
            #endregion
    }
}
