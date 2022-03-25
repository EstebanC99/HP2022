using Cross.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cross.Business.Domain.TestUnit
{
    [TestClass]
    public class EntityTest : TestClassBase<Entity>
    {
        [TestClass]
        public class ElConstructor : EntityTest
        {
            [TestMethod]
            public void Inicializa_una_instancia_no_nula()
            {
                // Arrange

                // Action
                this.Target = new ConcreteEntity();

                // Assert
                Assert.IsNotNull(this.Target);
            }

            [TestMethod]
            public void inicializa_una_instancia_con_el_ID_pasado_como_parametro()
            {
                // Arrange
                int id = 1;

                // Action
                this.Target = new ConcreteEntity(id);

                // Assert
                Assert.AreEqual(id, this.Target.ID);
            }
        }

        [TestClass]
        public class ElMetodo_Equals : EntityTest
        {
            [TestMethod]
            public void Retoran_false_si_las_dos_entidades_son_de_diferente_tipo()
            {
                // Arrange
                this.Target = new ConcreteEntity(1);
                var entidadDiferente = new List<ConcreteEntity>();

                // Action
                var resultado = this.Target.Equals(entidadDiferente);

                // Assert
                Assert.IsFalse(resultado);
            }

            [TestMethod]
            public void Dos_entidades_son_iguales_si_sus_IDs_son_iguales()
            {
                // Arrange
                this.Target = new ConcreteEntity(1);
                var entidadIgual = new ConcreteEntity(1);

                // Action
                var resultado = this.Target.Equals(entidadIgual);

                // Assert
                Assert.IsTrue(resultado);
            }

            [TestMethod]
            public void Dos_entidades_son_distintas_si_sus_IDs_son_distintos()
            {
                // Arrange
                this.Target = new ConcreteEntity(1);
                var entidadIgual = new ConcreteEntity(2);

                // Action
                var resultado = this.Target.Equals(entidadIgual);

                // Assert
                Assert.IsFalse(resultado);
            }
        }

        [TestClass]
        public class ElMetodo_GetHashCode : EntityTest
        {
            [TestMethod]
            public void El_HashCode_de_la_entidad_se_obtiene_del_ID()
            {
                // Arrange
                int id = 1;
                this.Target = new ConcreteEntity(id);

                // Action
                var hashCode = this.Target.GetHashCode();

                // Assert
                Assert.AreEqual(hashCode, id.GetHashCode());
            }
        }

        [TestClass]
        public class ElMetodo_IsTransient : EntityTest
        {
            [TestMethod]
            public void Si_la_entidad_no_esta_persistida_se_retorna_True()
            {
                // Arrange
                this.Target = new ConcreteEntity();

                // Action
                var resultado = this.Target.IsTransient();

                // Assert
                Assert.IsTrue(resultado);
            }

            [TestMethod]
            public void Si_la_entidad_esta_persistida_se_retorna_False()
            {
                // Arrange
                this.Target = new ConcreteEntity(1);

                // Action
                var resultado = this.Target.IsTransient();

                // Assert
                Assert.IsFalse(resultado);
            }
        }

        internal class ConcreteEntity : Entity
        {
            internal ConcreteEntity()
            {

            }

            internal ConcreteEntity(int ID)
                : base(ID)
            {

            }
        }
    }


    
}
