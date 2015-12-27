namespace library
{
    public class PrompterInput
    {
        public int CurrentGear { get; }

        public int Rpm { get; }

        public PrompterInput(int currentGear, int rpm)
        {
            this.CurrentGear = currentGear;
            this.Rpm = rpm;
        }
    }
}