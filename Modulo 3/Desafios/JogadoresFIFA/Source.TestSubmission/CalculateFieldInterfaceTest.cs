using System.Linq;
using System.Reflection;
using Xunit;

namespace Codenation.Challenge
{
    public class CalculateFieldInterfaceTest
    {
        const string INTERFACE_FULL_NAME = "Codenation.Challenge.ICalculateField";
        const string ASSEMBLY_NAME = "Source";    
        const string ADDITION_METHOD = "Addition";
        const string SUBTRACTION_METHOD = "Subtraction";
        const string TOTAL_METHOD = "Total";

        [Fact]
        public void Should_Exists_The_Interface()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var expected = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(expected);
            Assert.True(expected.IsInterface);
        }

        [Fact]
        public void Should_Has_Addition_Method()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(actual);
            var expected = actual.GetMethods().Select(x => x.Name).ToList();
            Assert.Contains(ADDITION_METHOD, expected);
        }

        [Fact]
        public void Should_Has_Right_Signature_For_Addition_Method()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(actual);
            var method = actual.GetMethod(ADDITION_METHOD);
            Assert.NotNull(method);
            Assert.Equal("System.Decimal", method.ReturnType.FullName);
            var parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal("System.Object", parameters[0].ParameterType.FullName);
        }

        [Fact]
        public void Should_Has_Subtration_Method()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(actual);
            var expected = actual.GetMethods().Select(x => x.Name).ToList();
            Assert.Contains(SUBTRACTION_METHOD, expected);
        }

        [Fact]
        public void Should_Has_Right_Signature_For_Subtractio_Method()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(actual);
            var method = actual.GetMethod(SUBTRACTION_METHOD);
            Assert.NotNull(method);
            Assert.Equal("System.Decimal", method.ReturnType.FullName);
            var parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal("System.Object", parameters[0].ParameterType.FullName);
        }

        [Fact]
        public void Should_Has_Total_Method()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(actual);
            var expected = actual.GetMethods().Select(x => x.Name).ToList();
            Assert.Contains(TOTAL_METHOD, expected);
        }

        [Fact]
        public void Should_Has_Right_Signature_For_Total_Method()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(INTERFACE_FULL_NAME);
            Assert.NotNull(actual);
            var method = actual.GetMethod(TOTAL_METHOD);
            Assert.NotNull(method);
            Assert.Equal("System.Decimal", method.ReturnType.FullName);
            var parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal("System.Object", parameters[0].ParameterType.FullName);
        }

    }
}