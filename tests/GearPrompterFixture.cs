namespace tests
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using FluentAssertions;

    using library;

    public class GearPrompterFixture
    {
        private static readonly int LowRpm = 1499;

        private static readonly int EconoRpm = 1500;

        private static readonly int HighRpm = 2501;

        private static readonly int SomeRpm = 2000;

        public GearPrompterFixture()
        {
            MaxGear = 5;
            NeutralGear = 0;
            ReverseGear = -1;
            CurrentGear = 0;
            CurrentRpm = SomeRpm;
        }

        private int MaxGear { get; set; }

        private int ReverseGear { get; }

        private int NeutralGear { get; }

        public int CurrentGear { get; private set; }

        public int CurrentRpm { get; private set; }

        public static IEnumerable<int> AllRpms => new[] { LowRpm, EconoRpm, HighRpm, SomeRpm };
  
        public PrompterInput CurrentInput => new PrompterInput(CurrentGear, CurrentRpm);

        public GearFixtureAssertions Assert => new GearFixtureAssertions(this);

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

        public class GearFixtureAssertions
        {
            private readonly GearPrompterFixture fixture;

            public GearFixtureAssertions(GearPrompterFixture fixture)
            {
                this.fixture = fixture;
            }

            public void NoGearChange(GearSuggestion suggestion)
            {
                suggestion.NextGear.Should().Be(fixture.CurrentGear);
            }
        }
    }
}