using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tecnico.Domain.DTO;
using Tecnicos.Data.Models;

namespace Tecnicos.Abstractions;

public interface IClienteService
{
    Task<bool> Guardar(ClienteDTO clienteDTO);
    Task<bool> Eliminar(int clienteId);
    Task<ClienteDTO> Buscar(int id);
    Task<List<ClienteDTO>> Listar(Expression<Func<ClienteDTO, bool>> criterio);
    Task<bool> Existe(int clientesId);
    Task<bool> ExiteNombres(string nombre, int? clienteId = null);
}
