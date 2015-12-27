namespace tests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using library;

    using Xunit;

    using static GearPrompterFixture;

    public class GearPrompter_Recommend
    {
        private readonly GearPrompterFixture fixture = new GearPrompterFixture();

        [Fact]
        public void Suggest_gear_decrease_upon_low_rpm()
        {
            fixture.WithCustomGearChosen(2).And().WithLowRpm();
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void Suggest_gear_increase_upon_high_rpm()
        {
            fixture.WithCustomGearChosen(1).And().WithHighRpm();
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_when_econo_rpm()
        {
            fixture.WithCustomGearChosen(2).And().WithEconoRpm();
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_upon_low_rpm_when_lowest_gear_chosen_already()
        {
            fixture.WithCustomGearChosen(1).And().WithLowRpm();
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void No_change_upon_high_rpm_when_highest_gear_chosen_already()
        {
            fixture.WithHighestGearChosen().And().WithHighRpm();
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(fixture.MaxGear);
        }


        [Theory]
        [MemberData("AllRpms")]
        private void No_change_upon_given_rpm_when_reverse_gear_chosen(int rpm)
        {
            fixture.WithReverseGearChosen().And().WithCustomRpm(rpm);
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(fixture.ReverseGear);
        }

        [Theory]
        [MemberData("AllRpms")]
        private void No_change_upon_given_rpm_when_neutral_gear_chosen(int rpm)
        {
            fixture.WithNeutralGearChosen().And().WithCustomRpm(rpm);
            var sut = fixture.CreateSut();
            var result = sut.Recommend(fixture.CurrentInput);
            result.NextGear.Should().Be(fixture.NeutralGear);
        }


        [Fact]
        private void Validate_NegativeGear()
        {
            fixture.WithCustomGearChosen(-2);
            var sut = fixture.CreateSut();
            Assert.Throws<InputValidationException>(() => sut.Recommend(fixture.CurrentInput));
        }

        [Fact]
        private void Validate_NegativeRpm()
        {
            fixture.WithCustomRpm(-1);
            var sut = fixture.CreateSut();
            Assert.Throws<InputValidationException>(() => sut.Recommend(fixture.CurrentInput));
        }

        [Fact]
        private void Validate_MaxGear()
        {
            fixture.WithMaxGear(5).And().WithCustomGearChosen(6);
            var sut = fixture.CreateSut();
            Assert.Throws<InputValidationException>(() => sut.Recommend(fixture.CurrentInput));
        }

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
