using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cross.Tests
{
    public abstract class TestClassBase<TTarget>
    {
        protected TTarget Target
        {
            get;
            set;
        }

        protected TestClassBase()
        {

        }

        #region Test Initialize

        [TestInitialize]
        public void Init()
        {
            this.InitializeTest();
        }

        protected virtual void InitializeTest()
        {

        }

        #endregion
    }
}
