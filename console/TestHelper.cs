namespace console
{
    using System;
    using System.Reflection;

    public static class TestHelper
    {
        private static int counter = 1;

        public static void Test(Action body)
        {
            var scenario = body.GetMethodInfo().Name;
            Console.Write($"Test #{counter}: {scenario}");
            try
            {
                body();
                Console.WriteLine(" --> Test passed. ");
            }
            catch (AssertionException ex)
            {
                Console.Write($" --> Assert failed: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.Write($" --> Unexpected exception: '{ex.Message}'");
            }
            finally
            {
                Console.WriteLine();
                counter++;
            }
        }

        public static void Assert_Equal(int result, int expected)
        {
            if (result == expected)
            {
                return;
            }

            throw new AssertionException($"Expected {expected} but got {result}");
        }
    }
}