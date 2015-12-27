namespace library
{
    public class GearboxInfo
    {
        public GearboxInfo(int maxGear, int reverseGear, int neutralGear)
        {
            this.MaxGear = maxGear;
            this.ReverseGear = reverseGear;
            this.NeutralGear = neutralGear;
        }

        public int MaxGear { get; }

        public int ReverseGear { get; }

        public int NeutralGear { get; } 

    }
}