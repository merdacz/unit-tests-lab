namespace library
{
    public class GearboxInfo
    {
        public GearboxInfo(int maxGear)
        {
            this.MaxGear = maxGear;
        }

        public int MaxGear { get; }

        public int ReverseGear { get; } = -1;

        public int NeutralGear { get; } = 0;

    }
}