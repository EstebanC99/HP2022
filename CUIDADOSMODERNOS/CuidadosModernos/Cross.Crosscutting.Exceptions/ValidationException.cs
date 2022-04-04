using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cross.Crosscutting.Exceptions
{
    [Serializable]
    public class ValidationException : BaseException
    {
        #region Propiedades
        private const string SIMBOLO_ITEM_VALIDACIONES = "- ";

        protected List<ValidationResult> ValidationResults { get; private set; } = new List<ValidationResult>();

        public override int Type
        {
            get { return ExceptionTypes.ValidationException; }
        }
        #endregion

        #region Contructores
        public ValidationException() : base() { }

        public ValidationException(string message)
            : base(message)
        {

        }

        public ValidationException(string message, string code)
            : base(message, code)
        {

        }

        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        public ValidationException(ValidationResults validationResult)
            : this(GenerateExceptionMessage(validationResult))
        {

        }

        #endregion

        #region Metodos

        public void AddValidationResult(ValidationResult validationResult)
        {
            this.ValidationResults.Add(validationResult);
        }

        public void AddValidationResult(String message)
        {
            this.ValidationResults.Add(new ValidationResult
            {
                ID = Guid.NewGuid(),
                Message = message
            });
        }

        public void Throw()
        {
            if (this.ValidationResults.Any())
            {
                throw new ValidationException(this.GenerateExceptionMessage());
            }
        }

        public void Throw<TException>()
            where TException : BaseException
        {
            if (this.ValidationResults.Any())
            {
                var exception = (TException)Activator.CreateInstance(typeof(TException), this.GenerateExceptionMessage());

                throw exception;
            }
        }

        private string GenerateExceptionMessage()
        {
            string exceptionMessage = String.Empty;

            if (this.ValidationResults.Any())
            {
                var sb = new StringBuilder();

                foreach (var validationResult in this.ValidationResults)
                {
                    sb.Append(SIMBOLO_ITEM_VALIDACIONES);
                    sb.Append(validationResult.Message);
                    sb.Append(Environment.NewLine);
                }

                exceptionMessage = sb.ToString();
            }

            return exceptionMessage;
        }

        private static string GenerateExceptionMessage(ValidationResults validationResults)
        {
            string exceptionMessage = String.Empty;

            if (validationResults != null)
            {
                var sb = new StringBuilder();

                foreach (Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResult validationResult in validationResults)
                {
                    sb.Append(validationResult.Message);
                    sb.Append(Environment.NewLine);
                }

                exceptionMessage = sb.ToString();
            }

            return exceptionMessage;
        }

        [System.Security.SecurityCritical]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion
    }
}