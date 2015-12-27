namespace library
{
    public class GearPrompter
    {
        private readonly GearboxInfo gearbox;

        public GearPrompter(GearboxInfo gearbox)
        {
            this.gearbox = gearbox;
        }

        public GearSuggestion Recommend(PrompterInput input)
        {
            if (!input.IsValid(this.gearbox.MaxGear))
            {
                throw new InputValidationException();
            }

            var suggestedGear = input.CurrentGear;

            if (input.CurrentGear <= 0)
            {
                return new GearSuggestion(suggestedGear);
            }

            if (input.Rpm > 2500 && input.CurrentGear < this.gearbox.MaxGear)
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
