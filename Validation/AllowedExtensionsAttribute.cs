using System.ComponentModel.DataAnnotations;

namespace BulgarianTraditionsAndCustoms.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                // Take extension of the file and check if it's in the allowed extensions
                var extension = Path.GetExtension(file.FileName);
                if (extension != null && _extensions.Contains(extension.ToLower()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if (value == null)
            {
                // If no file is uploaded, consider it valid (optional)
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        public string GetErrorMessage()
        {
            return $"Този тип файл не е позволен! Позволените типове са: {string.Join(", ", _extensions)}";
        }
    }
}
