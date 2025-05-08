using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GhFrame.Api.Models;
using GhFrame.Api.Abstractions.Services;
using GhFrame.Api.Abstractions.Repositories;
using GhFrame.Api.Models.Domain;

namespace GhFrame.Api.Data;

public static class DatabaseSeeder
{
    public static async Task SeedDatabaseAsync(this IApplicationBuilder app, IConfiguration configuration)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        if (!await roleManager.Roles.AnyAsync())
        {
            foreach (var role in ApplicationRoles.All())
            {
                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = role
                });
            }

            await dbContext.Permissions.AddRangeAsync(Permissions.All().Select(p => Permission.Create(p)));

            await dbContext.SaveChangesAsync();

            var adminRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrator);

            if (adminRole is null)
            {
                return;
            }

            var permissions = await dbContext.Permissions.ToListAsync();

            adminRole.AddPermissions(permissions);
            await roleManager.UpdateAsync(adminRole);
            
            var adminUser = ApplicationUser.Create();
            await userManager.SetEmailAsync(adminUser, configuration["Admin:Email"]);
            await userManager.SetUserNameAsync(adminUser, configuration["Admin:Username"]);
            await userManager.CreateAsync(adminUser, configuration["Admin:Password"]!);
            await userManager.AddToRoleAsync(adminUser, ApplicationRoles.Administrator);            
        }

        if(!await dbContext.Warehouses.AnyAsync()) {
            Warehouse[] seedWareHouses = {
                new Warehouse {
                    Id = "GD001",
                    Name = "Gudang Pusat"
                },
                new Warehouse {
                    Id = "GD002",
                    Name = "Gudang Toko"
                },
            };
            dbContext.Warehouses.AddRange(seedWareHouses);

            InventoryItem[] inventoryItems = {
                new InventoryItem{
                    Id = "IT001",
                    WarehouseId = "GD001",
                    Name = "Barang 1",
                    Quantity = 1,
                    ItemGroupName = "Group 1"
                },
                new InventoryItem{
                    Id = "IT002",
                    WarehouseId = "GD001",
                    Name = "Barang 2",
                    Quantity = 10,
                    ItemGroupName = "Group 1"
                },
                new InventoryItem{
                    Id = "IT003",
                    WarehouseId = "GD001",
                    Name = "Barang 3",
                    Quantity = 5,
                    ItemGroupName = "Group 1"
                },
                new InventoryItem{
                    Id = "IT004",
                    WarehouseId = "GD002",
                    Name = "Samsung A1",
                    Quantity = 1,
                    ItemGroupName = "Group 2"
                },
            };
            dbContext.InventoryItems.AddRange(inventoryItems);
            dbContext.SaveChanges();
        }

    }
}