using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulgarianTraditionsAndCustoms.Helpers
{
    public class CsvModelBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;
            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Success(new List<T>());
                return Task.CompletedTask;
            }

            var values = value.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var list = new List<T>();

            foreach (var item in values)
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                var convertedValue = (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, item.Trim());
                list.Add(convertedValue);
            }

            bindingContext.Result = ModelBindingResult.Success(list);
            return Task.CompletedTask;
        }
    }

}
