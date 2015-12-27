namespace library
{
    public class GearPrompter
    {
        private readonly GearboxInfo gearbox;

        private readonly ISuggestionAudit auditor;

        public GearPrompter(GearboxInfo gearbox, ISuggestionAudit auditor)
        {
            this.gearbox = gearbox;
            this.auditor = auditor;
        }

        public GearSuggestion Recommend(PrompterInput input)
        {
            if (!input.IsValid(gearbox.MaxGear))
            {
                throw new InputValidationException();
            }

            var suggestedGear = input.CurrentGear;

            if (input.CurrentGear > 0)
            {
                if (input.Rpm > 2500 && input.CurrentGear < gearbox.MaxGear)
                {
                    suggestedGear++;
                }
                else if (input.Rpm < 1500 && input.CurrentGear > 1)
                {
                    suggestedGear--;
                }
            }

            var result = new GearSuggestion(suggestedGear);
            auditor.Audit(input, result);
            return result;
        }
    }
}
