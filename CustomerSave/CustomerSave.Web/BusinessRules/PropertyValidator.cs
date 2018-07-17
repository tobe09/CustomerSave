using Serenity.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerSave.BusinessRules
{
    public class PropertyValidator
    {
        private static string errorMessage;
        private static string affectedproperty;

        private static ValidationResult ErrorResult()
        {
            return new ValidationResult(errorMessage, new[] { affectedproperty });
        }

        private static ValidationResult SuccessResult()
        {
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateUsername(string username)
        {
            if (username == null || username.Trim().Length < 3)
            {
                errorMessage = "Username should contain 3 or more characters.";
                affectedproperty = "Username";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateName(string name, string nameType)
        {
            if (name == null || name.Trim().Length < 3)
            {
                errorMessage = nameType + " should contain 3 or more characters.";
                affectedproperty = nameType;
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateEmail(string email)
        {
            if (email == null || email.Trim().Length < 5)
            {
                errorMessage = "Email should contain 5 or more characters.";
                affectedproperty = "Email address";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidatePhoneNo(long phoneNo, string numType)
        {
            if (phoneNo < 7000000000 || phoneNo > 10000000000)
            {
                errorMessage = "Please enter a valid phone number. (e.g 08136831102)";
                affectedproperty = numType;
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateAddress(string address)
        {
            if (address == null || address.Trim().Length < 8)
            {
                errorMessage = "Please enter a valid address.";
                affectedproperty = "Address";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateString(string value, string valueType)
        {
            if (value == null || value.Trim().Length == 0)
            {
                errorMessage = valueType + " is empty.";
                affectedproperty = valueType;
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateAmount(decimal amount)
        {
            if (amount <= 0 || amount > 1000000)
            {
                if (amount <= 00) errorMessage = "Amount is invalid.";
                else errorMessage = "Amount is too large.";
                affectedproperty = "Amount";
                return ErrorResult();
            }

            return SuccessResult();
        }


        public static void Validate<T>(Func<T, ValidationResult> func, T valueToValidate)
        {
            var result = func(valueToValidate);
            if (result != ValidationResult.Success)
            {
                string propertyName = "";
                var enumerator = result.MemberNames.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    propertyName = enumerator.Current;
                }

                throw new ValidationError(propertyName, result.ErrorMessage);
            }
        }

        public static void Validate<T>(Func<T, string, ValidationResult> func, T valueToValidate, string propName)
        {
            var result = func(valueToValidate, propName);

            if (result != ValidationResult.Success)
            {
                string propertyName = "";
                var enumerator = result.MemberNames.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    propertyName = enumerator.Current;
                }

                throw new ValidationError(propertyName, result.ErrorMessage);
            }
        }
    }
}
