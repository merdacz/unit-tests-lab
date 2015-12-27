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
            MaxGear = 5;
            NeutralGear = 0;
            ReverseGear = -1;
            CurrentGear = 0;
            CurrentRpm = SomeRpm;
        }

        public int MaxGear { get; private set; }

        public int ReverseGear { get; }

        public int NeutralGear { get; }

        public int CurrentGear { get; private set; }

        public int CurrentRpm { get; private set; }

        public PrompterInput CurrentInput => new PrompterInput(CurrentGear, CurrentRpm);

        public GearPrompter CreateSut()
        {
            return new GearPrompter(new GearboxInfo(MaxGear, ReverseGear, NeutralGear));
        }
        public GearPrompterFixture WithMaxGear(int maxGear)
        {
            MaxGear = maxGear;
            return this;
        }

        public GearPrompterFixture WithCustomGearChosen(int gear)
        {
            CurrentGear = gear;
            return this;
        }

        public GearPrompterFixture WithHighestGearChosen()
        {
            CurrentGear = MaxGear;
            return this;
        }

        public GearPrompterFixture WithReverseGearChosen()
        {
            CurrentGear = ReverseGear;
            return this;
        }

        public GearPrompterFixture WithNeutralGearChosen()
        {
            CurrentGear = NeutralGear;
            return this;
        }

        public GearPrompterFixture WithLowRpm()
        {
            CurrentRpm = LowRpm;
            return this;
        }

        public GearPrompterFixture WithHighRpm()
        {
            CurrentRpm = HighRpm;
            return this;
        }

        public GearPrompterFixture WithCustomRpm(int rpm) 
        {
            CurrentRpm = rpm;
            return this;    
        }

        public GearPrompterFixture WithEconoRpm()
        {
            CurrentRpm = EconoRpm;
            return this;
        }

        public GearPrompterFixture And()
        {
            return this;    
        }

    }
}