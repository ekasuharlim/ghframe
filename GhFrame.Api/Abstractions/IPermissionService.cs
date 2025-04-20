using GhFrame.Api.Models;

namespace GhFrame.Api.Abstractions;

public interface IPermissionService
{
    Task<IEnumerable<Permission>> GetPermissionsAsync();

    Task<IEnumerable<string>> GetPermissionsForUserAsync(Guid userId);
}