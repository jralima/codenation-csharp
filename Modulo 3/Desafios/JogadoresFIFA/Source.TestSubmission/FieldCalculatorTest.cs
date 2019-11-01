using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Codenation.Challenge
{
    public class FieldCalculatorTest
    {
        const string CLASS_FULL_NAME = "Codenation.Challenge.FieldCalculator";
        const string INTERFACE_FULL_NAME = "Codenation.Challenge.ICalculateField";
        const string ASSEMBLY_NAME = "Source";
        const string ADDITION_METHOD = "Addition";
        const string SUBTRACTION_METHOD = "Subtraction";
        const string TOTAL_METHOD = "Total";

        private FakeData GetFakeData(decimal add, decimal subtract, decimal attributeless)
        {
            var fake = new FakeData();
            fake.SetAdd(add);
            fake.SetSubtract(subtract);
            fake.SetAttributeless(attributeless);
            return fake;
        }
        private FakeAttributeLessData GetFakeAttributeLessData(decimal add, decimal subtract, decimal attributeless)
        {
            var fake = new FakeAttributeLessData();
            fake.SetAdd(add);
            fake.SetSubtract(subtract);
            fake.SetAttributeless(attributeless);
            return fake;
        }

        private MethodInfo GetImplementationMethod(Type sourceInterface, Type sourceClass, string methodName)
        {
            var actualMap = sourceClass.GetInterfaceMap(sourceInterface);
            var methodIndex = actualMap.InterfaceMethods.ToList().FindIndex(x => x.Name == methodName);            
            return actualMap.TargetMethods[methodIndex];
        }

        [Fact]
        public void Should_Exists_The_Class()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var expected = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(expected);
        }

        [Fact]
        public void Should_Implements_ICalculateField_Interface()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);            
            var actual = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(actual);
            var interfaces = actual.GetInterfaces().Select(x => x.FullName).ToList();
            Assert.Contains(INTERFACE_FULL_NAME, interfaces);
        }

        [Theory]
        [InlineData(10, 20, 10, 10)]
        [InlineData(-20, 0, 10, -20)]
        public void Should_Returns_Addition_When_Calculate_Add_Attribute(
            decimal add, decimal subtract, decimal attributeless, decimal expected)
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);            
            var sourceClass = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(sourceClass);

            var sourceInterface = assembly.GetType(INTERFACE_FULL_NAME);
            var additionMethod = GetImplementationMethod(sourceInterface, sourceClass, ADDITION_METHOD);
            var calculator = Activator.CreateInstance(sourceClass);
            var actual = additionMethod.Invoke(calculator, 
                new object[] {GetFakeData(add, subtract, attributeless)});
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 10, 10, -10)]
        [InlineData(20, -20, 10, 20)]
        public void Should_Returns_Subtraction_When_Calculate_Subtract_Attribute(
            decimal add, decimal subtract, decimal attributeless, decimal expected)
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);            
            var sourceClass = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(sourceClass);

            var sourceInterface = assembly.GetType(INTERFACE_FULL_NAME);
            var subtractionMethod = GetImplementationMethod(sourceInterface, sourceClass, SUBTRACTION_METHOD);
            var calculator = Activator.CreateInstance(sourceClass);
            var actual = subtractionMethod.Invoke(calculator, 
                new object[] {GetFakeData(add, subtract, attributeless)});
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(10, 10, 10, 0)]
        [InlineData(-10, 20, 10, -30)]
        [InlineData(10, -10, 10, 20)]
        [InlineData(-10, -10, 10, 0)]
        public void Should_Returns_Total_When_Calculate_Add_And_Subtract_Attributes(
            decimal add, decimal subtract, decimal attributeless, decimal expected)
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);            
            var sourceClass = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(sourceClass);

            var sourceInterface = assembly.GetType(INTERFACE_FULL_NAME);
            var totalMethod = GetImplementationMethod(sourceInterface, sourceClass, TOTAL_METHOD);
            var calculator = Activator.CreateInstance(sourceClass);
            var actual = totalMethod.Invoke(calculator, 
                new object[] {GetFakeData(add, subtract, attributeless)});
            Assert.Equal(expected, actual);

        }
        
        [Theory]
        [InlineData(10, 20, 10, 0)]
        [InlineData(-10, 20, 10, 0)]
        [InlineData(10, -10, 10, 0)]
        [InlineData(-10, -20, 10, 0)]
        public void Should_Returns_Zero_When_Class_Has_No_Attributes(
            decimal add, decimal subtract, decimal attributeless, decimal expected)
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);            
            var sourceClass = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(sourceClass);

            var sourceInterface = assembly.GetType(INTERFACE_FULL_NAME);
            var totalMethod = GetImplementationMethod(sourceInterface, sourceClass, TOTAL_METHOD);
            var calculator = Activator.CreateInstance(sourceClass);
            var actual = totalMethod.Invoke(calculator, 
                new object[] {GetFakeAttributeLessData(add, subtract, attributeless)});
            Assert.Equal(expected, actual);

        }
    }
}