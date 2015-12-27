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
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(2, LowRpm));
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void Suggest_gear_increase_upon_high_rpm()
        {
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(1, HighRpm));
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_when_econo_rpm()
        {
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(2, EconoRpm));
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_upon_low_rpm_when_lowest_gear_chosen_already()
        {
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(1, LowRpm));
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void No_change_upon_high_rpm_when_highest_gear_chosen_already()
        {
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(this.fixture.MaxGear, HighRpm));
            result.NextGear.Should().Be(this.fixture.MaxGear);
        }


        [Theory]
        [MemberData("AllRpms")]
        private void No_change_upon_given_rpm_when_reverse_gear_chosen(int givenRpm)
        {
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(this.fixture.ReverseGear, givenRpm));
            result.NextGear.Should().Be(this.fixture.ReverseGear);
        }

        [Theory]
        [MemberData("AllRpms")]
        private void No_change_upon_given_rpm_when_neutral_gear_chosen(int givenRpm)
        {
            var sut = this.fixture.CreateSut();
            var result = sut.Recommend(new PrompterInput(this.fixture.NeutralGear, givenRpm));
            result.NextGear.Should().Be(this.fixture.NeutralGear);
        }


        [Fact]
        private void Validate_NegativeGear()
        {
            var sut = this.fixture.CreateSut();
            Assert.Throws<InputValidationException>(() => sut.Recommend(new PrompterInput(-2, SomeRpm)));
        }

        [Fact]
        private void Validate_NegativeRpm()
        {
            var sut = this.fixture.CreateSut();
            Assert.Throws<InputValidationException>(() => sut.Recommend(new PrompterInput(2, -1)));
        }

        [Fact]
        private void Validate_MaxGear()
        {
            this.fixture.WithMaxGear(5);
            var sut = this.fixture.CreateSut();
            Assert.Throws<InputValidationException>(
                () => sut.Recommend(new PrompterInput(6, SomeRpm)));
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
