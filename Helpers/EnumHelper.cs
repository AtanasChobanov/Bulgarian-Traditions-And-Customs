using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using BulgarianTraditionsAndCustoms.Enums;

namespace BulgarianTraditionsAndCustoms.Helpers
{
    public static class EnumHelper
    {
        // Returns the display name of an enum value based on its [Display] attribute.
        public static string GetDisplayName(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }

        public static IEnumerable<SelectListItem> GetRegionSelectListItems()
        {
            var enumValues = Enum.GetValues(typeof(Region)).Cast<Region>();
            var items = enumValues.Select(value => new SelectListItem
            {
                Value = ((int)value).ToString(),
                Text = GetDisplayName(value)
            });
            return items;
        }

        public static IEnumerable<SelectListItem> GetTraditionTypeSelectListItems()
        {
            var enumValues = Enum.GetValues(typeof(TraditionType)).Cast<TraditionType>();
            var items = enumValues.Select(value => new SelectListItem
            {
                Value = ((int)value).ToString(),
                Text = GetDisplayName(value)
            });
            return items;
        }
    }

}
