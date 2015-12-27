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
            var sut = new GearPrompter(new GearboxInfo(5, -1, 0), new NullAuditor());
            var result = sut.Recommend(new PrompterInput(2, 1000));
            Assert_Equal(result.NextGear, 1);
        }

        private static void Suggest_gear_increase_upon_high_rpm()
        {
            var sut = new GearPrompter(new GearboxInfo(5, -1, 0), new NullAuditor());
            var result = sut.Recommend(new PrompterInput(1, 3000));
            Assert_Equal(result.NextGear, 2);
        }
    }
}
