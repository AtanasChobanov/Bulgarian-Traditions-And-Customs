using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        //Свойства, които съдържат информация за страниците
        public int PageIndex { get; private set; } // Номер на текущата страница
        public int TotalPages { get; private set; } // Общ брой страници

        //Конструктор - той е private, защото никога няма да го викаме директно.
        //Той се извиква само от нашия CreateAsync метод.
        private PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            //Изчисляваме общия брой страници. 
            //Ако имаме 11 продукта и 4 на страница, 11 / 4.0 = 2.75. Math.Ceiling го закръгля на 3
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            //Добавяме елементите за текущата страница към самия списък.
            this.AddRange(items);
        }

        //Помощни свойства, които улесняват изгледа (за бутоните "Предишна"/"Следваща")
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        // Фабричен метод "CreateAsync" - ТОВА Е НАЙ-ВАЖНАТА ЧАСТ!
        // Той е единственият начин да се създаде обект от този клас.
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            // Първо, изпълняваме заявка, за да вземем ОБЩИЯ брой на ВСИЧКИ записи (преди страницирането).
            // Това е нужно за изчисляването на TotalPages.
            var count = await source.CountAsync();

            // Сега прилагаме .Skip() и .Take().
            // Това е ефективната част - базата данни ще върне само нужните записи.
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            // Накрая, създаваме и връщаме новата инстанция на PaginatedList,
            // като й подаваме извлечените елементи и изчислените данни за страниците.
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
