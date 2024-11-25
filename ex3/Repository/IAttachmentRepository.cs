using ex3.Models;
using System.Data;

namespace ex3.Repository
{
    public interface IAttachmentRepository
    {
           DataTable CreateAttachment(string attachmentName, string attachmentPath);
            public bool ProcessTransaction(Attachment attachment, Models.Tasks task);


    }
}
