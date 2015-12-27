namespace library
{
    public interface ISuggestionAudit
    {
        void Audit(PrompterInput input, GearSuggestion suggestion);
    }
}