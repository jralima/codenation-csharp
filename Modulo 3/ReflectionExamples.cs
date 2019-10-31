/*
This example shows how to dynamically load assembly, how to create object instance, how to invoke method or how to get and set property value.
Create instance from assembly that is in your project References
*/

//The following examples create instances of DateTime class from the System assembly.

// create instance of class DateTime
DateTime dateTime = (DateTime)Activator.CreateInstance(typeof(DateTime));

// create instance of DateTime, use constructor with parameters (year, month, day)
DateTime dateTime = (DateTime)Activator.CreateInstance(typeof(DateTime), new object[] { 2008, 7, 4 });

//Create instance from dynamically loaded assembly

//All the following examples try to access to sample class Calculator from Test.dll assembly. The calculator class can be defined like this.

namespace Test
{
    public class Calculator
    {
        public Calculator() { ... }
        private double _number;
        public double Number { get { ... } set { ... } }
        public void Clear() { ... }
        private void DoClear() { ... }
        public double Add(double number) { ... }
        public static double Pi { ... }
        public static double GetPi() { ... }
    }
}

//Examples of using reflection to load the Test.dll assembly, to create instance of the Calculator class and to access its members (public/private, instance/static).

// dynamically load assembly from file Test.dll
Assembly testAssembly = Assembly.LoadFile(@"c:\Test.dll");

// get type of class Calculator from just loaded assembly
Type calcType = testAssembly.GetType("Test.Calculator");

// create instance of class Calculator
object calcInstance = Activator.CreateInstance(calcType);

// get info about property: public double Number
PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");

// get value of property: public double Number
double value = (double)numberPropertyInfo.GetValue(calcInstance, null);

// set value of property: public double Number
numberPropertyInfo.SetValue(calcInstance, 10.0, null);

// get info about static property: public static double Pi
PropertyInfo piPropertyInfo = calcType.GetProperty("Pi");

// get value of static property: public static double Pi
double piValue = (double)piPropertyInfo.GetValue(null, null);

// invoke public instance method: public void Clear()
calcType.InvokeMember("Clear",
    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
    null, calcInstance, null);

// invoke private instance method: private void DoClear()
calcType.InvokeMember("DoClear",
    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
    null, calcInstance, null);

// invoke public instance method: public double Add(double number)
double value = (double)calcType.InvokeMember("Add",
    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
    null, calcInstance, new object[] { 20.0 });

// invoke public static method: public static double GetPi()
double piValue = (double)calcType.InvokeMember("GetPi",
    BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public,
    null, null, null);

// get value of private field: private double _number
double value = (double)calcType.InvokeMember("_number",
    BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
    null, calcInstance, null);













*********************************************

/// <summary>
/// Utilizando reflection para pegar atributo do objeto
/// </summary>
///
/// <param name="type">O Tipo da instancia.</param>
/// <param name="instance">A instancia do Objeto.</param>
/// <param name="fieldName">O nome do atributo que retornará o erro.</param>
///
/// <returns>O valor do atributo do objeto passado.</returns>
internal static object GetInstanceField(Type type, object instance, string fieldName)
{
    BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
     | BindingFlags.Static;
    FieldInfo field = type.GetField(fieldName, bindFlags);
    return field.GetValue(instance);
}
Pra Chamar é só :

string str = GetInstanceField(typeof(SuaClasse), instancia, "NomeAtributo") as string;



**************************************

http://www.linhadecodigo.com.br/artigo/2695/csharp-40.aspx
https://www.devmedia.com.br/trabalhando-com-reflection-em-csharp/26871
