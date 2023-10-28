using Microsoft.AspNetCore.Http;

namespace DataTransferObjets.Dto
{
    public class ImagesDto
    {
        public IFormFileCollection Files { get; set; }
        public string UpLoadPath { get; set; }
    }
}
