using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Interfaces
{
    public interface IFileService
    {
        public Task<string> UploadImg(IFormFile file, string folderName);
        public Task DeleteImg(string path);


    }
}
