using BulgarianTraditionsAndCustoms.Models;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Data
{
    public class DbSeeder
    {
        public static async Task SeedRegionsAsync(IServiceProvider service)
        {
            // Get the database context from the service provider
            using var context = service.GetRequiredService<ApplicationDbContext>();

            // Check if there are any regions already in the database
            if (await context.Regions.AnyAsync())
                return;

            var regions = new List<Region>
            {
                new Region
                {
                    Name = "Северняшка област",
                    Description = "Характерна с богати народни песни и танци, едногласно пеене и весели хора от Северна България."
                },
                new Region
                {
                    Name = "Добруджанска област",
                    Description = "Фолклор с приклекнали движения, силна връзка със земята и специфични танци и песни."
                },
                new Region
                {
                    Name = "Шопска област",
                    Description = "Захарактеризира се с енергични танци, кукерски традиции и богата музикална култура."
                },
                new Region
                {
                    Name = "Пиринска област",
                    Description = "Югозападен регион с характерни пирински хора и танци, силна музикална традиция."
                },
                new Region
                {
                    Name = "Родопска област",
                    Description = "Родопски фолклор с бавни, безмензурни песни и танци, известни със своя мистичен дух."
                },
                new Region
                {
                    Name = "Тракийска област",
                    Description = "Област с енергични и ритмични хора, разнообразни обичаи и богат музикален репертоар."
                },
                new Region
                {
                    Name = "Странджанска област",
                    Description = "Югоизточен регион, известен със специфични обреди, танци и ритуали, включително нестинарство."
                },
                new Region
                {
                    Name = "Черноморски регион",
                    Description = "Културно разнообразие от традиции по Черноморието, смес от северни и южни влияния."
                },
                new Region
                {
                    Name = "Средногорие и Балкана",
                    Description = "Преходна област с традиции от Балкана и Средногорието, богата на обичаи и горски фестивали."
                }
            };

            await context.Regions.AddRangeAsync(regions);
            await context.SaveChangesAsync();
        }
    }
}
