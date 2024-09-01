namespace News_Site.Services.Interfaces
{
    public interface IFileService
    {
        public Task<string> Upload(IFormFile file);
        public bool DeletePhysicalFile(string path);
    }
}
