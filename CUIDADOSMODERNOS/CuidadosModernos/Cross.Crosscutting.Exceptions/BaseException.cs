using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Cross.Crosscutting.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        public virtual bool IsHandled { get; } = true;

        public string Code { get; set; }

        public abstract int Type { get; }

        protected BaseException() { }

        protected BaseException(string message)
            : this(message, null)
        {

        }

        protected BaseException(string message, string code) 
            : base(message)
        {
            this.Code = code;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Code = info.GetString("Code");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            Contract.EndContractBlock();
            base.GetObjectData(info, context);
            info.AddValue("Code", this.Code, typeof(string));
        }
    }
}
