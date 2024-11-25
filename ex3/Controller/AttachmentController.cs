using ex3.Models;
using ex3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;
[Route("api/[controller]")]
[ApiController]
public class AttachmentsController : ControllerBase
{
    private readonly IAttachmentService _attachmentsService;
    public AttachmentsController(IAttachmentService attachmentsService)
    {
        _attachmentsService = attachmentsService;
    }

    [HttpPost("creat")]
    public IActionResult CreateAttachment([FromBody] Attachment a)
    {
        if (a == null || string.IsNullOrEmpty(a.Name) || string.IsNullOrEmpty(a.Path))
        {
            return BadRequest("All fields are required.");
        }

        DataTable result = _attachmentsService.CreateAttachment(a.Name, a.Path);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateAt([FromBody] AttachmentWithTask model)
    {
        if (model == null || model.Attachment == null || model.Task == null)
        {
            return BadRequest("Attachment and Task are required.");
        }

        bool success = _attachmentsService.CreateAt(model);
        if (success)
        {
            return Ok("Transaction completed successfully.");
        }
        return StatusCode(500, "Failed to process transaction.");
    }
}
