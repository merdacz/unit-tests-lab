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
            }
            catch (Exception ex)
            {
                Console.Write($" --> Unexpected exception: '{ex.Message}'");
            }

            Console.WriteLine();
            counter++;
        }
    }
}