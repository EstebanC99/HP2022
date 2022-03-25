using Cross.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Business.Domain.TestUnit
{
    [TestClass]
    public class AggregateTest : TestClassBase<Aggregate<int>>
    {
        [TestClass]
        public class ElConstructor : AggregateTest
        {
            [TestMethod]
            public void Inicializa_una_instancia_no_nula()
            {
                // Arrange

                // Action
                this.Target = new ConcreteAggregate();

                // Assert
                Assert.IsNotNull(this.Target);
            }

            [TestMethod]
            public void Inicializa_una_instancia_con_el_ID_pasado_por_parametro()
            {
                // Arrange
                var id = 1;

                // Action
                this.Target = new ConcreteAggregate(id);

                // Assert
                Assert.AreEqual(id, this.Target.ID);
            }
        }

        [TestClass]
        public class ElMetodo_IsTransient : AggregateTest
        {
            [TestMethod]
            public void Retorna_true_si_la_entidad_no_esta_persistido()
            {
                // Arrange
                this.Target = new ConcreteAggregate();

                // Action
                var resultado = this.Target.IsTransient();

                // Assert
                Assert.IsTrue(resultado);
            }

            [TestMethod]
            public void Retorna_false_si_la_entidad_esta_persistido()
            {
                // Arrange
                this.Target = new ConcreteAggregate(1);

                // Action
                var resultado = this.Target.IsTransient();

                // Assert
                Assert.IsFalse(resultado);
            }
        }

        internal class ConcreteAggregate : Aggregate<int>
        {
            internal ConcreteAggregate()
            {

            }

            internal ConcreteAggregate(int ID)
                : base(ID)
            {

            }
        }

    }
}
