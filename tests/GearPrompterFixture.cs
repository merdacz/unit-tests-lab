namespace tests
{
    using System.Collections.Generic;

    using library;

    public class GearPrompterFixture
    {
        public static readonly int LowRpm = 1499;

        public static readonly int EconoRpm = 1500;

        public static readonly int HighRpm = 2501;

        public static readonly int SomeRpm = 2000;

        public GearPrompterFixture()
        {
            this.MaxGear = 5;
            this.NeutralGear = 0;
            this.ReverseGear = -1;
        }

        public int MaxGear
        {
            get;
            private set;
        }

        public int ReverseGear
        {
            get;
            private set;
        }

        public int NeutralGear
        {
            get;
            private set;
        }

        public GearPrompter CreateSut()
        {
            return new GearPrompter(new GearboxInfo(this.MaxGear, this.ReverseGear, this.NeutralGear));
        }
        public GearPrompterFixture WithMaxGear(int maxGear)
        {
            this.MaxGear = maxGear;
            return this;
        }
    }
}