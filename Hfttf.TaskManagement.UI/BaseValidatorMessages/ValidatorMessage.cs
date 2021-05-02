namespace Hfttf.TaskManagement.UI.BaseValidatorMessages
{
    public static class ValidatorMessage
    {
        public static string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public static string NotNullMessage { get; } = "{PropertyName} alanı boş geçilemez";
        public static string LengthWarningMessage { get; } = "{PropertyName} alanı max. {MaxLength} karakter olmalı";
    }
}
