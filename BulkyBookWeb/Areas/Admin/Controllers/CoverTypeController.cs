using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        // CREATE
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // EDIT
        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "Cover Type not found";
                return NotFound();
            }
            /*var categoryFromDb = _db.Categories.Find(id);*/
            var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            /*var categoryFromDb = _db.Categories.SingleOrDefault(u => u.Id == id);*/

            return View(coverTypeFromDbFirst);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type  updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE
        // GET
        public IActionResult Delete(int? id)
        {
            //var categoryFromDb = _db.Categories.Find(id);

            var categoryFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                TempData["error"] = "Cover Type not found";
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
