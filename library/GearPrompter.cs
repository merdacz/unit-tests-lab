namespace library
{
    using System;

    public class GearPrompter
    {
        public static readonly int MaxGear = 5;

        public static readonly int ReverseGear = -1;

        public static readonly int NeutralGear = 0;

        public GearSuggestion Recommend(PrompterInput input)
        {
            var suggestedGear = input.CurrentGear;

            if (input.CurrentGear <= 0)
            {
                return new GearSuggestion(suggestedGear);
            }

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
