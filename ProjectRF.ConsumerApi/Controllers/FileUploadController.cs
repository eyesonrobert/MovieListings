using ProjectRF.ConsumerApi.Services;
using ProjectRF.ConsumerApi.UploadRepo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProjectRF.ConsumerApi.Controllers
{
    public class FileUploadController : ApiController
    {
        // asynchronous function 
        [Mime]
        [AllowAnonymous]
        public async Task<FileUploadDetails> Post()
        {
            // file path
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");

            var multiFormDataStreamProvider = new MultiFileUploadProvider(fileuploadPath);

            await Request.Content.ReadAsMultipartAsync(multiFormDataStreamProvider);

            string uploadingFileName = multiFormDataStreamProvider
                .FileData.Select(x => x.LocalFileName).FirstOrDefault();

            return new FileUploadDetails
            {
                FilePath = uploadingFileName,

                FileName = Path.GetFileName(uploadingFileName),

                FileLength = new FileInfo(uploadingFileName).Length,

                FileCreatedTime = DateTime.Now.ToLongDateString()
            };
        }
    }
}