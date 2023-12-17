using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IStorageService
    {
        Task UploadFileBlobAsync(Stream content, string path, string company, string subFolder = "");
        Task<Stream> DownloadFileBlobAsync(string path, string company, string subFolder = "");
        Task<string> GetBlobPath();
    }
}
