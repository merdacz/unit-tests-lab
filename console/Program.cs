namespace console
{
    using System;

    using library;

    class Program
    {
        static void Main(string[] args)
        {
            Test_Suggest_gear_decrease_upon_low_rpm();
            Test_Suggest_gear_increase_upon_high_rpm();
        }

        private static void Test_Suggest_gear_decrease_upon_low_rpm()
        {
            Console.Write("Test #1: Suggest gear decrease upon low rpm");
            try
            {
                var sut = new GearPrompter();
                var result = sut.Recommend(new PrompterInput(2, 1000));
                if (result.NextGear != 1)
                {
                    Console.Write($" --> Assert failed: Expected 1 but got {result.NextGear}");
                }
            }
            catch (Exception ex)
            {
                Console.Write($" --> Unexpected exception: '{ex.Message}'");
            }

            Console.WriteLine();
        }

        private static void Test_Suggest_gear_increase_upon_high_rpm()
        {
            Console.Write("Test #2: Suggest gear increase upon high rpm");
            try
            {
                var sut = new GearPrompter();
                var result = sut.Recommend(new PrompterInput(1, 3000));
                if (result.NextGear != 2)
                {
                    Console.Write($" --> Assert failed: Expected 1 but got {result.NextGear}");
                }
            }
            catch (Exception ex)
            {
                Console.Write($" --> Unexpected exception: '{ex.Message}'");
            }

            Console.WriteLine();
        }
    }
}
