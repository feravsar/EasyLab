using System;

namespace EasyLab.WebApi.Models.Request
{
    public class UpdateDocumentRequest
    {
        public Guid ProjectId { get;  set; }

        public string FileName { get;  set; }

        public string FileContent { get;  set; }
    }
}
