using System.ComponentModel.DataAnnotations;

namespace BulgarianTraditionsAndCustoms.Enums
{
    public enum TraditionType
    {
        [Display(Name = "Зимен")]
        Winter = 1,

        [Display(Name = "Летен")]
        Summer = 2,

        [Display(Name = "Пролетен")]
        Spring = 3,

        [Display(Name = "Есенен")]
        Autumn = 4,

        [Display(Name = "Религиозен")]
        Religious = 5,

        [Display(Name = "Семеен")]
        Family = 6,

        [Display(Name = "Календарен")]
        Calendar = 7,

        [Display(Name = "Трудов")]
        Labor = 8,

        [Display(Name = "Фолклорен")]
        Folklore = 9,

        [Display(Name = "Национален")]
        National = 10,

        [Display(Name = "Лечебен")]
        Healing = 11
    }

}
