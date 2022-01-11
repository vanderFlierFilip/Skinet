using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Infrastructure.Data
{
    public class FileManager : IFileManager
    {
        private string _filePath;
        private string _filePathForWeb;
        public FileManager(IConfiguration config)
        {
            _filePath = config["Path:ImagesUpload"];
            _filePathForWeb = config["Path:ImagesReturn"];

        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            try
            {
                var save_path = Path.Combine(_filePath);

                var fileName = file.FileName;


                using (var stream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                     await file.CopyToAsync(stream);
                }

                return $"{_filePathForWeb}/{fileName}";
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error";
            }
        }
    }
}
