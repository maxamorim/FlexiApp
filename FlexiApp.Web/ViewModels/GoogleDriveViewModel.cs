using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlexiApp.Web.ViewModels
{
    public class GoogleDriveViewModel
    {
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string ClientSecret { get; set; }
        [Required]
        public string DownloadFolder { get; set; }
        [Required]
        public string UploadFolder { get; set; }
        public string FileString { get; set; }
    }
}