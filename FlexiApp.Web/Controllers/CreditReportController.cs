using FlexiApp.Domain.Models.CreditReport;
using FlexiApp.Domain.Models.GoogleDrive;
using FlexiApp.Infrastructure.Helper;
using FlexiApp.Web.ViewModels;
using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;


namespace FlexiApp.Web.Controllers
{
    public class CreditReportController : Controller
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
        [ValidateInput(false)]
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
                    }, model.DownloadFolder, "mimeType='text/xml'");

                    XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                    var filename = "CreditReport-" + Guid.NewGuid() + ".csv";

                    MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(file.ToArray())));
                    Envelope resultingMessage = (Envelope)serializer.Deserialize(memStream);

                    var csv = new Utils().XMLObjectToCSV(resultingMessage);

                    var filenameCSV = "CreditReport-" + Guid.NewGuid() + ".csv";
                    var fileResponse = new GoogleDrive().UploadFile(new Credentials()
                    {
                        ClientId = model.ClientId,
                        ProjectId = model.ProjectId,
                        ClientSecret = model.ClientSecret
                    }, model.UploadFolder, csv, filename, "text/csv");
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
        public ActionResult CreateXml(GoogleDriveViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                    var filename = "CreditReport-" + Guid.NewGuid() + ".xml";
                    var fileResponse = new GoogleDrive().UploadFile(new Credentials()
                    {
                        ClientId = model.ClientId,
                        ProjectId = model.ProjectId,
                        ClientSecret = model.ClientSecret
                    }, model.UploadFolder, Encoding.UTF8.GetBytes(model.FileString), filename, "text/xml");
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