
List<decimal> typedNumbers = new List<decimal>();

decimal result = 0;
int typedOption = 1;
int wantToContinue = 0;

DisplayHeader();

try
{
    typedOption = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Please Type the first number");
    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

    Console.WriteLine("Please Type the second number");
    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

    while (wantToContinue != 2)
    {
        Console.WriteLine("you want to continue inserting numbers? 1. Yes, 2. No");
        wantToContinue = Convert.ToInt32(Console.ReadLine());
        if (wantToContinue == 1)
        {
            int quantityElementsInTheArray = typedNumbers.Count + 1;
            
            Console.WriteLine("Please Type another number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

        }
        
        
    }

    switch (typedOption)
    {
        case 1:
            {
                //foreach (int typedNumber in typedNumbers)
                //{
                //    result = Add(result, typedNumber);
                //   // AddByRef(ref result, typedNumber);
                //    // result += typedNumber;
                //}
                result = AddList(typedNumbers);
            }
            break;
        case 2:
            result = typedNumbers[0];
            for (int i = 1; i < typedNumbers.Count; i++) 
            {
                result -= typedNumbers[i];
            }

            break;
        case 3:
            foreach (int typedNumber in typedNumbers)
            {
                result = multiplicacion(typedNumbers);
            }
            break;
        case 4:
            foreach (int typedNumber in typedNumbers)
            {
                result = division(typedNumbers);
            }
            break;
        default:
            result = 0;
            break;
    }

    Console.WriteLine($"The Result of the operation is:{result}");


}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"you can not divide by zero: {ex.Message}");
}
catch (ArithmeticException ex)
{
    Console.WriteLine($"you can not divide by zero: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"You need to choose a correct option: {ex.Message}");
}
finally
{
    Console.WriteLine("Closing Db Conection");
}



//function
static decimal Add(decimal valueToModify, decimal value)
{
    valueToModify += value;
    return valueToModify;
}

static decimal AddList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (int typedNumber in typedNumbers)
    {
        result = Add(result, typedNumber);
        // AddByRef(ref result, typedNumber);
        // result += typedNumber;
    }
    return result;
}
static decimal multiplicacion(List<decimal> typedNumbers)
{
    decimal result = typedNumbers[0];
    for ( int i =1;i< typedNumbers.Count;i++)
    {
        result *= typedNumbers[i];
    }
    return result;
}
static decimal division(List<decimal> typedNumbers)
{
    decimal result = typedNumbers[0];
    for(int i=1; i<typedNumbers.Count;i++)
    {
        result /= typedNumbers[i];
    }
    return result;
}



static void DisplayHeader()
{
    Console.WriteLine("This is the best calculator");
    Console.WriteLine("Please Type the option number than you want");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1. Sum, \n 2. Substract,  \n 3. Multiplication,  \n 4. Division,  \n 5. Exit");
}