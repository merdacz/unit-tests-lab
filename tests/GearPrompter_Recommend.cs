namespace tests
{
    using FluentAssertions;

    using library;

    using Xunit;

    public class GearPrompter_Recommend
    {
        [Fact]
        public void Suggest_gear_decrease_upon_low_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(2, 1000));
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void Suggest_gear_increase_upon_high_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(1, 3000));
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_when_econo_rpm()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(2, 2000));
            result.NextGear.Should().Be(2);
        }

        [Fact]
        public void No_change_upon_low_rpm_when_lowest_gear_chosen_already()
        {
            var sut = new GearPrompter();
            var result = sut.Recommend(new PrompterInput(1, 1000));
            result.NextGear.Should().Be(1);
        }

        [Fact]
        public void No_change_upon_high_rpm_when_highest_gear_chosen_already()
        {
            var sut = new GearPrompter();
            var maxGear = GearPrompter.MaxGear;
            var result = sut.Recommend(new PrompterInput(maxGear, 3000));
            result.NextGear.Should().Be(maxGear);
        }


        [Fact]
        private void No_change_upon_high_rpm_when_reverse_gear_chosen()
        {
            var sut = new GearPrompter();
            var reverseGear = GearPrompter.ReverseGear;
            var result = sut.Recommend(new PrompterInput(reverseGear, 3000));
            result.NextGear.Should().Be(reverseGear);
        }

        [Fact]
        private void No_change_upon_high_rpm_when_neutral_gear_chosen()
        {
            var sut = new GearPrompter();
            var neutralGear = GearPrompter.NeutralGear;
            var result = sut.Recommend(new PrompterInput(neutralGear, 3000));
            result.NextGear.Should().Be(neutralGear);
        }
    }
}
