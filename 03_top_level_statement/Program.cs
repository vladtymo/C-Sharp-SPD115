Console.WriteLine("------------ Data Types ------------");

/* Data types: 
    - Value tupes: store in stack    | structures (int, float, Nullable, enum ...)
    - Reference types: store in heap | classes (String, Array, Delegates ...)
*/

// ---------------- primitive types
int intVar = 10;
float floatVar = 5.5F;
double doubleVar = 133.99;
bool boolVar = false;
decimal decimalVar = 100000.55M; // 16 - bytes
//...

Console.WriteLine($"int: {intVar}, float: {floatVar}, double: {doubleVar}, bool: {boolVar}");

// objects
object nullObj = null;
object obj = new object();

obj.ToString(); // convert value to string
obj.GetType();  // get Type of the object
obj.Equals(nullObj);
obj.GetHashCode();

string nullStr = null;  // without instance
string emptyStr = "";   // instance without symbols

//nullStr.ToUpper(); // error (NullReferenceException)
emptyStr.ToUpper();  // works

// ---------------- nullable

//decimal salary = null; // error
//Nullable<decimal> salary = null;
decimal? salary = null;

string username = null;

// {variable} ?? {value} - return {value} if {variable} = null
Console.WriteLine($"Your username: {username ?? "no username"}");

if (username != null)
    username.ToUpper();

// ? - null-condition operator
username?.ToUpper();