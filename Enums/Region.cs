using System.ComponentModel.DataAnnotations;

namespace BulgarianTraditionsAndCustoms.Enums
{
    public enum Region
    {
        [Display(Name = "Цяла България")]
        All = 0,

        [Display(Name = "Северняшка област")]
        Severnyashka = 1,

        [Display(Name = "Добруджанска област")]
        Dobrudzha = 2,

        [Display(Name = "Шопска област")]
        Shopska = 3,

        [Display(Name = "Пиринска област")]
        Pirinska = 4,

        [Display(Name = "Родопска област")]
        Rodopska = 5,

        [Display(Name = "Тракийска област")]
        Trakiiska = 6,

        [Display(Name = "Странджанска област")]
        Strandzhanska = 7,

        [Display(Name = "Черноморски регион")]
        BlackSea = 8,

        [Display(Name = "Средногорие и Балкана")]
        SrednogorieBalkan = 9
    }

}
