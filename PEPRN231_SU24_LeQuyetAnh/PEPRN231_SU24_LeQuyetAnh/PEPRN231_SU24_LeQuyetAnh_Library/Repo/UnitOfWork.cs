using PEPRN231_SU24_LeQuyetAnh_Library.Data;
using PEPRN231_SU24_LeQuyetAnh_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEPRN231_SU24_LeQuyetAnh_Library.Repo;
public class UnitOfWork : IDisposable
{
    private WatercolorsPainting2024DbContext context = new WatercolorsPainting2024DbContext();
    private GenericRepo<Style> styleRepo;
    private GenericRepo<UserAccount> userAccountRepo;
    private GenericRepo<WatercolorsPainting> watercolorsPaintingRepo;

    public GenericRepo<Style> StyleRepo
    {
        get
        {
            if (styleRepo == null)
            {
                styleRepo = new GenericRepo<Style>(context);
            }
            return styleRepo;
        }
    }

    public GenericRepo<UserAccount> UserAccountRepo
    {
        get
        {
            if (userAccountRepo == null)
            {
                userAccountRepo = new GenericRepo<UserAccount>(context);
            }
            return userAccountRepo;
        }
    }

    public GenericRepo<WatercolorsPainting> WatercolorsPaintingRepo
    {
        get
        {
            if (watercolorsPaintingRepo == null)
            {
                watercolorsPaintingRepo = new GenericRepo<WatercolorsPainting>(context);
            }
            return watercolorsPaintingRepo;
        }
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}