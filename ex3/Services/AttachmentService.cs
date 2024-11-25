using ex3.Models;
using ex3.Repository;
using System.Data;

namespace ex3.Services
{
    public class AttachmentService:IAttachmentService
    {
            private readonly IAttachmentRepository _attachmentsRepository;

            public AttachmentService(IAttachmentRepository attachmentsRepository)
            {
                _attachmentsRepository = attachmentsRepository;
            }
            public DataTable CreateAttachment(string attachmentName, string attachmentPath)
            {
                return _attachmentsRepository.CreateAttachment(attachmentName, attachmentPath);
            }
            public bool CreateAt(AttachmentWithTask model)
            {
                return _attachmentsRepository.ProcessTransaction(model.Attachment, model.Task);
            }
        }
}
