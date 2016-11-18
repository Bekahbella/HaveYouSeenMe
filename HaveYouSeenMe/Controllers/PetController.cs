using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaveYouSeenMe.Models.Business;
using HaveYouSeenMe.Models;
using System.IO;


namespace HaveYouSeenMe.Controllers
{
    public class PetController : Controller
    {
        private IRepository _repository;
        // GET: Pet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPhoto()
        {
            var name = (string)RouteData.Values["id"];//reads query string parameter we are passing in
            ViewBag.Photo = string.Format("/Content/Uploads/thumbnail_{0}.jpg", name); //format string as path to image

            return PartialView();
        }

    //public ActionResult Display()
    //    {
    //        var name = (string)RouteData.Values["id"]; //data we are giving it to search for
    //        var model = PetManagement.GetByName(name); //calling pet management class

    //        if (model == null)
    //        {
    //            return RedirectToAction("NotFound"); //will redirect to action result Not found

    //        }
    //        return View(model);
    //    }
        public FileResult DownloadPetPicture()
        {
            var name = (string)RouteData.Values["id"];
            var picture = "/Content/Uploads/" + name + ".jpg"; //reference to path where files is located
            var contentType = "image/jpg"; //creating a reference to file name
            //var fileName = name + ".jpg"; //creating reference to file name to save as
            return File(picture, contentType); //expects 3 variables from above currently have fileName commented out

        }

        public ActionResult PictureUpload() //corresponds with PictureUpload View Get Method
        {
            return View();
        }

        [HttpPost]//view is a post 
        [ValidateAntiForgeryToken]
        public ActionResult PictureUpload(PictureModel model) //handles upload of photo
        {
            if(model.PictureFile.ContentType != "image/jpeg" && model.PictureFile.ContentType != "image/png") //checking content type
            {
                return View();
            }
            if (model.PictureFile.ContentLength > 0) //checking content file length
            {
                var fileName = Path.GetFileName(model.PictureFile.FileName);
                var filePath = Server.MapPath("/Content/Uploads");
                string savedFileName = Path.Combine(filePath, fileName);
                model.PictureFile.SaveAs(savedFileName);
                var pm = new PetManagement();
                pm.CreateThumbnail(fileName, filePath, 100, 100, true);

                ViewBag.UploadResult = "Success";
            }
            return View(model);

        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult NotFoundError()
        {
            return HttpNotFound("Nothing here...");
        }
        public HttpStatusCodeResult CustomError()
        {
            return new HttpStatusCodeResult(500, "CustomError");
        }

        public ActionResult DisplayHttpNotFound()
        {
            var name = (string)RouteData.Values["id"];
            var pm = new PetManagement(_repository);
            var model = pm.GetByName(name);

            if (model == null)
            {
                return HttpNotFound("Pet not found.....");

            }
            return View(model);
        }
    }
}