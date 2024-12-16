namespace HomePro.Web.ViewModels.ServiceCatalog
{
    public class ImageUploadModel
    {
        public string FileName { get; set; } = string.Empty;
        public byte[] Content { get; set; } = Array.Empty<byte>();
    }
}
