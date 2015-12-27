namespace library
{
    public class PrompterInput
    {
        public int CurrentGear { get; }

        public int Rpm { get; }

        public PrompterInput(int currentGear, int rpm)
        {
            CurrentGear = currentGear;
            Rpm = rpm;
        }

        public bool IsValid(int maxGear)
        {
            if (CurrentGear < -1) { return false; }
            if (CurrentGear > maxGear) { return false; }
            if (Rpm < 0) { return false; }
            return true;
        }
    }
}