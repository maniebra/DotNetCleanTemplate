namespace DotNetCleanTemplate.Source.Infrastructure.Commons.Documentation;


/// <summary>
/// Example annotation that describes an example (used for swagger).
///
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
public class ExampleAttribute : Attribute
{
    /// <summary>
    /// Example value that goes in the documentation.
    /// </summary>
    public object Value { get; }

    /// <summary>
    /// Example class constructor for the annotation.
    /// </summary>
    /// <param name="value">The value that is going to be shown in API documentation.</param>
    public ExampleAttribute(object value)
    {
        Value = value;
    }
}