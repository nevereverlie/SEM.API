using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEM.API.Models;
using SEM.API.Data;

namespace SEM.API.Data.Seed
{
    public class Seed
    {
        public static async Task SeedCompanies(DataContext context)
        {
            if (await context.Companies.AnyAsync()) return;

            var companyData = await System.IO.File.ReadAllTextAsync("Data/Seed/CompanySeedData.json");
            var companies = JsonSerializer.Deserialize<List<Company>>(companyData);

            foreach (var company in companies)
            {
                context.Companies.Add(company);
            }

            await context.SaveChangesAsync();
        }
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/Seed/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserEmail = user.UserEmail.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));

                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
        public static async Task SeedDepartments(DataContext context)
        {
            if (await context.Departments.AnyAsync()) return;

            var depData = await System.IO.File.ReadAllTextAsync("Data/Seed/DepartmentSeedData.json");
            var deps = JsonSerializer.Deserialize<List<Department>>(depData);

            foreach (var dep in deps)
            {
                context.Departments.Add(dep);
            }

            await context.SaveChangesAsync();
        }
        
        public static async Task SeedWeekDays(DataContext context)
        {
            if (await context.WeekDays.AnyAsync()) return;

            var dayData = await System.IO.File.ReadAllTextAsync("Data/Seed/WeekDaySeedData.json");
            var days = JsonSerializer.Deserialize<List<WeekDay>>(dayData);

            foreach (var day in days)
            {
                context.WeekDays.Add(day);
            }

            await context.SaveChangesAsync();
        }
    }
}