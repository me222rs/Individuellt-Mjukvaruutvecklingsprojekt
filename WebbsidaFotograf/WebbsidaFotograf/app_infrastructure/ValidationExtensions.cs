using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebbsidaFotograf.Model;

namespace WebbsidaFotograf.app_infrastructure
{
    public static class ValidationExtensions
    {
        public static bool Validate(this Blog instance, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }

        public static bool ValidateImg(this ImageProps instance, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }

        public static bool ValidateTags(this BlogTags instance, out ICollection<ValidationResult> validationResultsTags)
        {
            var validationContext = new ValidationContext(instance);
            validationResultsTags = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResultsTags, true);
        }
    }
}