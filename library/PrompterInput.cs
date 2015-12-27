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

        public bool IsValid(int maxGear)
        {
            if (this.CurrentGear < -1) { return false; }
            if (this.CurrentGear > maxGear) { return false; }
            if (this.Rpm < 0) { return false; }
            return true;
        }
    }
}