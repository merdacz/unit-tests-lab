namespace library
{
    using System;

    public class GearPrompter
    {
        public GearSuggestion Recommend(PrompterInput input)
        {
            var suggestedGear = input.CurrentGear;

            if (input.Rpm > 2500)
            {
                suggestedGear++;
            }
            else if (input.Rpm < 1500)
            {
                suggestedGear--;
            }

            return new GearSuggestion(suggestedGear);
        }
    }
}
