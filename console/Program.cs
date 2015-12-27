namespace console
{
    using System;

    using library;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Test #1: Suggest gear decrease upon low rpm");
            try {
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
    }
}
