using Lab3.Infra.Models;

namespace Lab3.Infra.Data;

public interface IUnitOfWork : IDisposable
{
    GenericRepository<Category> Categories { get; }
    GenericRepository<Product> Products { get; }
    GenericRepository<Account> Accounts { get; }
    Task<int> SaveAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly Lab3Prn231Context _context;
    private GenericRepository<Category> _categories = null!;
    private GenericRepository<Product> _productes = null!;
    private GenericRepository<Account> _accounts = null!;

    public UnitOfWork(Lab3Prn231Context context)
    {
        _context = context;
    }

    public GenericRepository<Category> Categories
    {
        get
        {
            this._categories ??= new GenericRepository<Category>(_context);
            return _categories;
        }
    }

    public GenericRepository<Product> Products
    {
        get
        {
            this._productes ??= new GenericRepository<Product>(_context);
            return _productes;
        }
    }

    public GenericRepository<Account> Accounts
    {
        get
        {
            this._accounts ??= new GenericRepository<Account>(_context);
            return _accounts;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

