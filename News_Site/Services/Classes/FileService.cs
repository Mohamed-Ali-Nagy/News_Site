using News_Site.Services.Interfaces;

namespace News_Site.Services.Classes
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool DeletePhysicalFile(string path)
        {
            if(path == null)
            {
                return false;
            }
            path = path.Replace("/", Path.DirectorySeparatorChar.ToString())
               .Replace("\\", Path.DirectorySeparatorChar.ToString());
            var directoryPath =Path.Combine( _webHostEnvironment.WebRootPath , path);
           
            if (File.Exists(directoryPath))
            {
                File.Delete(directoryPath);
                return true;
            }
            return false;
        }
        public async Task<string> Upload(IFormFile file)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"Images");
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string path = Path.Combine(uploadPath, fileName);

            using (FileStream fileStream = File.Create(path))
            {
                await file.CopyToAsync(fileStream);
                return $"Images/{fileName}";
            }
        }
    }
}

