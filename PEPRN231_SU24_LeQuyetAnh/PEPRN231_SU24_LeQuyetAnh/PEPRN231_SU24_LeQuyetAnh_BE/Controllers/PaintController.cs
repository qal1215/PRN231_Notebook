using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEPRN231_SU24_LeQuyetAnh_BE.Helper;
using PEPRN231_SU24_LeQuyetAnh_Library.Models;
using PEPRN231_SU24_LeQuyetAnh_Library.Repo;
using System.Text.RegularExpressions;

namespace PEPRN231_SU24_LeQuyetAnh_BE.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PaintController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public PaintController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Authorize(Roles = "2,3")]
    public async Task<IActionResult> GetPaints([FromQuery] GetPaintsReq req)
    {
        string author = req.PaintingAuthor?.Trim() ?? "";
        int year = req.PublishYear ?? -1;

        var paints = await _unitOfWork
            .WatercolorsPaintingRepo
            .GetQueryable();

        if (author != "")
        {
            paints = paints.Where(p => p.PaintingAuthor!.ToUpper().Contains(author.ToUpper()));
        }

        if (year != -1)
        {
            paints = paints.Where(p => p.PublishYear == year);
        }

        paints = paints.Include(p => p.Style);


        var listPaint = await paints.ToListAsync();

        var result = listPaint
            .Select(p => new GetPaintRes(p.PaintingId, p.PaintingName, p.PaintingDescription, p.PaintingAuthor, p.Price, p.PublishYear, p.CreatedDate, p.StyleId, p.Style?.StyleName));

        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "2,3")]
    public async Task<IActionResult> GetPaint([FromRoute] string id)
    {
        var paint = await _unitOfWork.WatercolorsPaintingRepo.GetByIdAsync(id);

        if (paint is null)
        {
            return NotFound(new { msg = "Paint not found!" });
        }

        paint.Style = await _unitOfWork.StyleRepo.GetByIdAsync(paint.StyleId!);

        return Ok(paint);
    }


    [HttpDelete]
    [Authorize(Roles = "3")]
    public async Task<IActionResult> DeletePaint([FromQuery] string id)
    {
        var paint = await _unitOfWork.WatercolorsPaintingRepo.GetByIdAsync(id);

        if (paint is null)
        {
            return NotFound(new { msg = "Paint not found!" });
        }

        _unitOfWork.WatercolorsPaintingRepo.Delete(paint);
        await _unitOfWork.SaveAsync();

        return Ok(new { msg = "Paint deleted!" });
    }

    [HttpPost]
    [Authorize(Roles = "3")]
    public async Task<IActionResult> AddPaint([FromBody] AddPaintReq paint)
    {
        if (!PaintValidate(paint) || !ModelState.IsValid)
        {
            return BadRequest(new { msg = "Invalid input!" });
        }

        var isExitedStyle = await _unitOfWork.StyleRepo.GetByIdAsync(paint.StyleId);

        if (isExitedStyle is null)
        {
            return BadRequest(new { msg = "StyleId not found!" });
        }

        var newPaint = paint.Adapt<WatercolorsPainting>();
        newPaint.PaintingId = StringHelper.GenerateRandomString();
        newPaint.CreatedDate = DateTime.Now;

        await _unitOfWork.WatercolorsPaintingRepo.InsertAsync(newPaint);
        await _unitOfWork.SaveAsync();

        return Ok(newPaint);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "3")]
    public async Task<IActionResult> UpdatePaint([FromRoute] string id, [FromBody] AddPaintReq paint)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { msg = "Invalid input!" });
        }

        var paintToUpdate = await _unitOfWork.WatercolorsPaintingRepo.GetByIdAsync(id);
        if (paintToUpdate is null)
        {
            return NotFound(new { msg = "Paint not found!" });
        }

        if (!PaintValidate(paint) || !ModelState.IsValid)
        {
            return BadRequest(new { msg = "Invalid input!" });
        }

        var isExitedStyle = await _unitOfWork.StyleRepo.GetByIdAsync(paint.StyleId);

        if (isExitedStyle is null)
        {
            return BadRequest(new { msg = "StyleId not found!" });
        }

        paintToUpdate.PaintingName = paint.PaintingName;
        paintToUpdate.PaintingDescription = paint.PaintingDescription;
        paintToUpdate.PaintingAuthor = paint.PaintingAuthor;
        paintToUpdate.Price = paint.Price;
        paintToUpdate.PublishYear = paint.PublishYear;
        paintToUpdate.StyleId = paint.StyleId;

        await _unitOfWork.SaveAsync();
        return Ok(paintToUpdate);
    }

    private bool PaintValidate(AddPaintReq paint)
    {
        // Value for PaintingName includes a-z, A-Z, space and digit 0-9. Each word of the PaintingName must begin with the capital letter.
        var regex = new Regex(@"^([A-Z][a-z0-9]*\s?)+$");

        if (!regex.IsMatch(paint.PaintingName))
        {
            return false;
        }

        if (paint.PublishYear < 1000)
        {
            return false;
        }

        if (paint.Price < 0)
        {
            return false;
        }

        return true;
    }
}

public record GetPaintsReq(string? PaintingAuthor, int? PublishYear);

public record GetPaintRes(string PaintingId, string? PaintingName, string? PaintingDescription, string? PaintingAuthor, decimal? Price, int? PublishYear, DateTime? CreatedDate, string? StyleId, string? StyleName);

public record AddPaintReq(string PaintingName, string PaintingDescription, string PaintingAuthor, decimal Price, int PublishYear, string StyleId);