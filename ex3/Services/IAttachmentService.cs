using ex3.Models;
using System.Data;

namespace ex3.Services
{
    public interface IAttachmentService
    {
          DataTable CreateAttachment(string attachmentName, string attachmentPath);
          bool CreateAt(AttachmentWithTask model);

    }
}
