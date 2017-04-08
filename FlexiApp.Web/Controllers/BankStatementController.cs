using FlexiApp.Infrastructure.Helper;
using System.Web.Mvc;
using FlexiApp.Web.ViewModels;
using FlexiApp.Domain.Models.GoogleDrive;
using FlexiApp.Domain.Models.BankStatement;
using Newtonsoft.Json;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace FlexiApp.Web.Controllers
{
    public class BankStatementController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(GoogleDriveViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var file = new GoogleDrive().DownloadFile(new Credentials()
                    {
                        ClientId = model.ClientId,
                        ProjectId = model.ProjectId,
                        ClientSecret = model.ClientSecret
                    }, model.DownloadFolder, "mimeType='application/json'");

                    var retorno = JsonConvert.DeserializeObject<RootObject>(Encoding.UTF8.GetString(file.ToArray()));
                    var list = new List<RootObject>() { retorno };

                    var csv = new Utils().ListToCSV(list);

                    var filenameCSV = "BankStatement-" + Guid.NewGuid() + ".csv";
                    var fileResponse = new GoogleDrive().UploadFile(new Credentials()
                    {
                        ClientId = model.ClientId,
                        ProjectId = model.ProjectId,
                        ClientSecret = model.ClientSecret
                    }, model.UploadFolder, csv, filenameCSV, "text/csv");
                }
                TempData["alertMessage"] = "<script>alert('Sended with Success!');</script>";
                return View("Index", model);
            }
            catch(Exception ex)
            {
                TempData["alertMessage"] = "<script>alert('Error! Check the fields and try again.');</script>";
                return View("Index", model);
            }
            
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateJson(GoogleDriveViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var retorno2 = JsonConvert.DeserializeObject<RootObject>(model.FileString);
                    var filename = "BankStatement-" + Guid.NewGuid() + ".json";
                    var fileResponse = new GoogleDrive().UploadFile(new Credentials()
                    {
                        ClientId = model.ClientId,
                        ProjectId = model.ProjectId,
                        ClientSecret = model.ClientSecret
                    }, model.UploadFolder, Encoding.UTF8.GetBytes(model.FileString), filename, "application/json");
                }
                TempData["alertMessage"] = "<script>alert('Created with Success!');</script>";
                return View("Index", model);
            }
            catch(Exception ex)
            {
                TempData["alertMessage"] = "<script>alert('Error! Check the fields and try again.');</script>";
                return View("Index", model);
            }
            
            
        }
    }
}