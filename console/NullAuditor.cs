namespace console
{
    using library;

    internal class NullAuditor : ISuggestionAudit
    {
        public void Audit(PrompterInput input, GearSuggestion suggestion)
        {
        }
    }
}