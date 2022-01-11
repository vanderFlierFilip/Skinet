using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Infrastructure.Data
{
    public interface IFileManager
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}
