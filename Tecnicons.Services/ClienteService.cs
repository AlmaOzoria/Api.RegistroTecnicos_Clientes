using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Data.Context;
using Tecnicos.Data.Models;
using Tecnicos.Abstractions;
using Tecnico.Domain.DTO;

namespace Tecnicos.Services;

public class ClienteService(IDbContextFactory<TecnicosContext> DbFactory) : IClienteService
{
    public async Task<bool> Insertar(ClienteDTO clienteDTO)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var clienteEntity = new Clientes
        {
            Nombres = clienteDTO.Nombres,
            WhatsApp = clienteDTO.WhatsApp
        };
        _contexto.Clientes.Add(clienteEntity);
        var result = await _contexto.SaveChangesAsync() > 0;
        clienteDTO.ClientesId = clienteEntity.ClientesId;
        return result;
    }
    public async Task<bool> Existe(int clientesId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Clientes.AnyAsync(t => t.ClientesId == clientesId);

    }
    public async Task<bool> Modificar(ClienteDTO clientes)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        _contexto.Update(clientes);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(ClienteDTO clienteDTO)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var clienteEntity = new Clientes
        {
            ClientesId = clienteDTO.ClientesId,
            Nombres = clienteDTO.Nombres,

        };
        _contexto.Update(clienteEntity);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Clientes
            .Where(t => t.ClientesId == id)
            .ExecuteDeleteAsync() > 0;
    }


    public async Task<List<ClienteDTO>> Listar(Expression<Func<ClienteDTO, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var clientes = await _contexto.Clientes
            .AsNoTracking()
            .Select(c => new ClienteDTO
            {
                ClientesId = c.ClientesId,
                Nombres = c.Nombres,
                WhatsApp = c.WhatsApp,
            })
            .ToListAsync();

        return clientes.AsQueryable().Where(criterio).ToList();
    }



    public async Task<ClienteDTO?> Buscar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var cliente = await _contexto.Clientes
            .AsNoTracking()
            .Where(t => t.ClientesId == id)
            .Select(c => new ClienteDTO
            {
                ClientesId = c.ClientesId,
                Nombres = c.Nombres,
                WhatsApp = c.WhatsApp
            })
            .FirstOrDefaultAsync();
        return cliente;
    }

    public async Task<bool> ExiteNombres(string nombre, int? clienteId = null)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        if (clienteId.HasValue)
        {
            return await _contexto.Clientes.AnyAsync(t => t.Nombres == nombre && t.ClientesId != clienteId);
        }
        else
        {
            return await _contexto.Clientes.AnyAsync(t => t.Nombres == nombre);
        }
    }
}
