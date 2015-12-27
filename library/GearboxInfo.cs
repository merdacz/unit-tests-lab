namespace library
{
    public class GearboxInfo
    {
        public GearboxInfo(int maxGear, int reverseGear, int neutralGear)
        {
            MaxGear = maxGear;
            ReverseGear = reverseGear;
            NeutralGear = neutralGear;
        }

        public int MaxGear { get; }

        public int ReverseGear { get; }

        public int NeutralGear { get; } 

    }
}