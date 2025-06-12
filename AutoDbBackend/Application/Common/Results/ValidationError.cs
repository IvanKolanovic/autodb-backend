namespace Application.Common.Results;

public sealed record ValidationError(
    string PropertyName,
    string ErrorMessage)
{
    public static ValidationError Create(string propertyName, string errorMessage)
        => new(propertyName, errorMessage);
}