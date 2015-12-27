namespace library
{
    using System;

    public class GearPrompter
    {
        public static readonly int MaxGear = 5;

        public GearSuggestion Recommend(PrompterInput input)
        {
            var suggestedGear = input.CurrentGear;

            if (input.Rpm > 2500 && input.CurrentGear < MaxGear)
            {
                suggestedGear++;
            }
            else if (input.Rpm < 1500 && input.CurrentGear > 1)
            {
                suggestedGear--;
            }

            return new GearSuggestion(suggestedGear);
        }
    }
}
