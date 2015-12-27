namespace console
{
    using System;

    using library;

    using static TestHelper;

    class Program
    {
        static void Main(string[] args)
        {
            Test(Suggest_gear_decrease_upon_low_rpm);
            Test(Suggest_gear_increase_upon_high_rpm);
        }

        private static void Suggest_gear_decrease_upon_low_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(2, 1000));
            if (result.NextGear != 1)
            {
                Console.Write($" --> Assert failed: Expected 1 but got {result.NextGear}");
            }
        }

        private static void Suggest_gear_increase_upon_high_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(1, 3000));
            if (result.NextGear != 2)
            {
                Console.Write($" --> Assert failed: Expected 1 but got {result.NextGear}");
            }
        }
    }
}
