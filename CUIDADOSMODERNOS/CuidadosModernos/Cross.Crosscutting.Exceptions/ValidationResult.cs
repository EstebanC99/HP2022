using System;

namespace Cross.Crosscutting.Exceptions
{
    public class ValidationResult
    {
        public Guid ID { get; set; }

        public String Message { get; set; }

        public ValidationResult()
        {

        }

        public ValidationResult(string message)
            : this()
        {
            this.ID = Guid.NewGuid();
            this.Message = message;
        }

    }
}
