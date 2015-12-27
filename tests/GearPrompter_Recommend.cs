namespace tests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using library;

    using Xunit;

    public class GearPrompter_Recommend
    {
        [Fact]
        public void Suggest_gear_decrease_upon_low_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(2, LowRpm));
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void Suggest_gear_increase_upon_high_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(1, HighRpm));
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_when_econo_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(2, EconoRpm));
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_upon_low_rpm_when_lowest_gear_chosen_already()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(1, LowRpm));
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void No_change_upon_high_rpm_when_highest_gear_chosen_already()
        {
            var sut = new GearPrompter();
            var maxGear = GearPrompter.MaxGear;
            var result = sut.Recommend(new PrompterInput(maxGear, HighRpm));
            result.NextGear.Should().Be(maxGear);
        }


        [Theory]
        [MemberData("AllRpms")]
        private void No_change_upon_given_rpm_when_reverse_gear_chosen(int givenRpm)
        {
            var sut = new GearPrompter();
            var reverseGear = GearPrompter.ReverseGear;
            var result = sut.Recommend(new PrompterInput(reverseGear, givenRpm));
            result.NextGear.Should().Be(reverseGear);
        }

        [Theory]
        [MemberData("AllRpms")]
        private void No_change_upon_given_rpm_when_neutral_gear_chosen(int givenRpm)
        {
            var sut = new GearPrompter();
            var neutralGear = GearPrompter.NeutralGear;
            var result = sut.Recommend(new PrompterInput(neutralGear, givenRpm));
            result.NextGear.Should().Be(neutralGear);
        }


        [Fact]
        private void Validate_NegativeGear()
        {
            var sut = new GearPrompter();
            Assert.Throws<InputValidationException>(() => sut.Recommend(new PrompterInput(-2, SomeRpm)));
        }

        [Fact]
        private void Validate_NegativeRpm()
        {
            var sut = new GearPrompter();
            Assert.Throws<InputValidationException>(() => sut.Recommend(new PrompterInput(2, -1)));
        }

        [Fact]
        private void Validate_MaxGear()
        {
            var sut = new GearPrompter();
            var maxGear = GearPrompter.MaxGear;
            Assert.Throws<InputValidationException>(
                () => sut.Recommend(new PrompterInput(maxGear + 1, SomeRpm)));
        }

        public static readonly int LowRpm = 1000;

        public static readonly int EconoRpm = 2000;

        public static readonly int HighRpm = 3000;

        public static readonly int SomeRpm = 1500;

        public static IEnumerable<object[]> AllRpms
        {
            get
            {
                yield return new object[] { LowRpm };
                yield return new object[] { EconoRpm };
                yield return new object[] { HighRpm };
                yield return new object[] { SomeRpm };
            }
        }
    }
}
