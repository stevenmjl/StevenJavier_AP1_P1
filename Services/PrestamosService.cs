using Microsoft.EntityFrameworkCore;
using StevenJavier_AP1_P1.DAL;
using StevenJavier_AP1_P1.Models;
using System.Linq.Expressions;

namespace StevenJavier_AP1_P1.Services;

public class PrestamosService
{
    private readonly Contexto _contexto;
    public PrestamosService(Contexto contexto)
    {
        _contexto = contexto;
    }
    private async Task<bool> Existe(int prestamosId)
    {
        return await _contexto.Prestamos
            .AnyAsync(p => p.PrestamosId == prestamosId);
    }
    public async Task<bool> Guardar(Prestamos prestamo)
    {
        if (!await Existe(prestamo.PrestamosId))
            return await Insertar(prestamo);
        else
            return await Modificar(prestamo);

    }
    private async Task<bool> Insertar(Prestamos prestamo)
    {
        _contexto.Prestamos.Add(prestamo);
        return await _contexto
            .SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Prestamos prestamo)
    {
        _contexto.Update(prestamo);
        return await _contexto
            .SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminar(int prestamoId)
    {
        var prestamo = await _contexto.Prestamos
            .Where(p => p.PrestamosId == prestamoId)
            .ExecuteDeleteAsync();
        return prestamo > 0;
    }
    public async Task<Prestamos?> BuscarId(int prestamoId)
    {
        return await _contexto.Prestamos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrestamosId == prestamoId);
    }
    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        return await _contexto.Prestamos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task<int> UltimoId()
    {
        var ultimoPrestamo = await _contexto.Prestamos
            .OrderByDescending(p => p.PrestamosId)
            .FirstOrDefaultAsync();
        return ultimoPrestamo != null ? ultimoPrestamo.PrestamosId : 0;
    }
    public void DesvincularLocal(int prestamoId)
    {
        var local = _contexto.Set<Prestamos>().Local.FirstOrDefault(entry => entry
        .PrestamosId == prestamoId);
        if (local != null)
        {
            _contexto.Entry(local).State = EntityState.Detached;
        }
    }
}