using System;

class Program
{
    static void Main()
    {
        /*───────────────────────────────────────────────────────────────────────────
        # Problem 1: Division with Exception Handling ─────────────────────────────*/
        try
        {
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine()!);
            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Result: {num1 / num2}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        finally
        {
            Console.WriteLine("Operation complete");  // Always executes
        }
        /* Question: finally ensures code runs whether an exception occurs or not */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 2: Defensive Coding with Validation ─────────────────────────────*/
        int x, y;
        // Validate positive X
        do
        {
            Console.Write("Enter positive X: ");
        } while (!int.TryParse(Console.ReadLine(), out x) || x <= 0);

        // Validate Y > 1
        do
        {
            Console.Write("Enter Y (>1): ");
        } while (!int.TryParse(Console.ReadLine(), out y) || y <= 1);
        /* Question: TryParse avoids FormatException by returning false for invalid input */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 3: Nullable Integer Operations ──────────────────────────────────*/
        int? nullableInt = null;
        int safeValue = nullableInt ?? -1;  // Null-coalescing
        Console.WriteLine($"\nNullable demo: {safeValue}");

        // HasValue vs Value demonstration
        if (nullableInt.HasValue)
            Console.WriteLine($"Value exists: {nullableInt.Value}");
        else
            Console.WriteLine("No value present");
        /* Question: Accessing Value on null throws InvalidOperationException */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 4: Array Bounds Checking ────────────────────────────────────────*/
        int[] numbers = new int[5];
        try
        {
            numbers[5] = 10;  // Invalid index
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("\nCaught array index out of bounds!");
        }
        /* Question: Prevents memory access violations and unstable program state */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 5: 2D Array Row/Column Sums ─────────────────────────────────────*/
        int[,] matrix = new int[3, 3];
        Console.WriteLine("\nEnter 9 numbers for 3x3 matrix:");

        // Input
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = int.Parse(Console.ReadLine()!);

        // Row sums
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                rowSum += matrix[i, j];
            Console.WriteLine($"Row {i + 1} sum: {rowSum}");
        }
        /* Question: GetLength(0) gets row count, GetLength(1) gets column count */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 6: Jagged Array Handling ────────────────────────────────────────*/
        int[][] jaggedArray = new int[3][];
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            jaggedArray[i] = new int[i + 2];  // Varying row sizes
            Console.Write($"Enter {i + 2} numbers for row {i + 1}: ");
            string[] inputs = Console.ReadLine()!.Split();
            for (int j = 0; j < jaggedArray[i].Length; j++)
                jaggedArray[i][j] = int.Parse(inputs[j]);
        }
        /* Question: Jagged arrays have separate memory blocks for each row */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 7: Nullable Reference Types ─────────────────────────────────────*/
        string? nullableString = null;
        if (DateTime.Now.Second % 2 == 0)  // Conditional assignment
            nullableString = "Safe value";
        Console.WriteLine($"\nString length: {nullableString!.Length}"); // Null-forgiveness
        /* Question: Helps identify potential null references at compile time */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 8: Boxing/Unboxing Demonstration ────────────────────────────────*/
        object boxedInt = 42;  // Boxing
        try
        {
            int unboxed = (int)boxedInt;  // Unboxing
            Console.WriteLine($"\nUnboxed value: {unboxed}");
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Invalid unboxing attempt!");
        }
        /* Question: Boxing allocates heap memory, unboxing requires type checking */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 9: out Parameters ───────────────────────────────────────────────*/
        SumAndMultiply(5, 3, out int sum, out int product);
        Console.WriteLine($"\nSum: {sum}, Product: {product}");
        /* Question: out parameters must be assigned before method returns */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 10: Optional/Named Parameters ───────────────────────────────────*/
        PrintRepeated("C# Rocks!", times: 3);  // Named parameter
        /* Question: Ensures clear parameter association when skipping optional params */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 11: Null Propagation Operator ───────────────────────────────────*/
        int[]? maybeNullArray = null;
        Console.WriteLine($"\nArray length: {maybeNullArray?.Length ?? -1}");
        /* Question: ?. short-circuits to null instead of throwing exception */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 12: Switch Expression ───────────────────────────────────────────*/
        Console.Write("\nEnter day name: ");
        string dayInput = Console.ReadLine()!;
        int dayNum = dayInput switch
        {
            "Monday" => 1,
            "Tuesday" => 2,
            "Wednesday" => 3,
            "Thursday" => 4,
            "Friday" => 5,
            "Saturday" => 6,
            "Sunday" => 7,
            _ => -1
        };
        Console.WriteLine($"Day number: {dayNum}");
        /* Question: Preferred for multiple constant value pattern matching */

        /*───────────────────────────────────────────────────────────────────────────
        # Problem 13: params Keyword Usage ────────────────────────────────────────*/
        Console.WriteLine($"Sum of 1+2+3+4: {SumArray(1, 2, 3, 4)}");
        Console.WriteLine($"Sum of array: {SumArray(new int[] { 5, 10, 15 })}");
        /* Question: params must be last parameter and only one allowed per method */
    }

    /*───────────────────────────────────────────────────────────────────────────────
    # Helper Methods ──────────────────────────────────────────────────────────────*/

    static void SumAndMultiply(int a, int b, out int sum, out int product)
    {
        sum = a + b;
        product = a * b;
    }

    static void PrintRepeated(string message, int times = 5)
    {
        for (int i = 0; i < times; i++)
            Console.WriteLine(message);
    }

    static int SumArray(params int[] numbers)
    {
        int total = 0;
        foreach (int num in numbers) total += num;
        return total;
    }
}

/*
ANSWERS TO ALL QUESTIONS:
1. finally block: Ensures cleanup code executes regardless of exceptions
2. int.TryParse: Prevents exceptions by returning boolean success status
3. Nullable<T>.Value: Throws InvalidOperationException if null
4. Array bounds check: Prevents memory access violations
5. GetLength(): Accesses specific dimension size in multi-dimensional arrays
6. Jagged arrays: Each row is independent memory block vs rectangular's single block
7. Nullable references: Enable null safety checks at compile time
8. Boxing/Unboxing: Causes heap allocation and type checking overhead
9. out parameters: Must be assigned before method exit
10. Optional params: Prevent ambiguous parameter order
11. Null propagation: Short-circuits null access attempts
12. Switch expressions: Clean pattern matching for multiple values
13. params: Allows variable arguments but has positional constraints
*/