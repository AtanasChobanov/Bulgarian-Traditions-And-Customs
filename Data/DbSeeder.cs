using BulgarianTraditionsAndCustoms.Models;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Data
{
    public class DbSeeder
    {
        public static async Task SeedAllAsync(IServiceProvider service)
        {
            using var context = service.GetRequiredService<ApplicationDbContext>();

            await SeedRegionsAsync(context);
            await SeedTraditionTypesAsync(context);
        }

        private static async Task SeedRegionsAsync(ApplicationDbContext context)
        {
            // Check if there are any regions already in the database
            if (await context.Regions.AnyAsync())
            {
                return;
            }

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

        private static async Task SeedTraditionTypesAsync(ApplicationDbContext context)
        {
            // Check if there are any tradition types already in the database
            if (await context.TraditionTypes.AnyAsync())
            {
                return;
            }

            var traditionTypes = new List<TraditionType>
            {
                new TraditionType
                {
                    Name = "Зимен",
                    Description = "Mаскарадни игри, кукерски обреди и практики за прогонване на злите сили и привличане на здраве и плодородие."
                },
                new TraditionType
                {
                    Name = "Летен"
                },
                new TraditionType
                {
                    Name = "Пролетен",
                    Description = "Традиции, свързани със здраве, нов живот и природно възраждане."
                },
                new TraditionType
                {
                    Name = "Религиозен",
                    Description = "Празнични и обредни практики, свързани с православния църковен календар."
                },
                new TraditionType
                {
                    Name = "Семеен",
                },
                new TraditionType
                {
                    Name = "Календарен",
                },
                new TraditionType
                {
                    Name = "Трудов",
                    Description = "Практики и обичаи, свързани с трудовата дейност и аграрния цикъл, например лозарски и полски ритуали, които отразяват животинско-земен принос."
                },
                new TraditionType
                {
                    Name = "Фолклорен",
                    Description = "Народни песни, танци, обичаи и празници, които съхраняват културното фолклорно наследство на определения регион или общност."
                },
                new TraditionType
                {
                    Name = "Национален"
                },
                new TraditionType
                {
                    Name = "Лечебен",
                    Description = "Народни практики и вярвания, насочени към лечение, предпазване от болести и духовно пречистване."
                },
            };

            await context.TraditionTypes.AddRangeAsync(traditionTypes);
            await context.SaveChangesAsync();
        }

    }
}
