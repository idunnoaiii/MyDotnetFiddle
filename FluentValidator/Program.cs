// See https://aka.ms/new-console-template for more information


using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using static MyCustomValidators;


Customer customer = new Customer
{
    FromAmount = 14,
    ToAmount = 12,
    Surname = "ahi"
};
    
CustomerValidator validator = new CustomerValidator();

ValidationResult result = validator.Validate(customer);

foreach (var failure in result.Errors)
{
    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
}



public class CustomerValidator : AbstractValidator<Customer> 
{
    public CustomerValidator()
    {
        // RuleFor(x => x.FromAmount)
        //     .NotNull()
        //     .When(x => x.ToAmount.HasValue);
        //
        //
        // RuleFor(x => x.ToAmount)
        //     .NotNull()
        //     .When(x => x.FromAmount.HasValue)
        //     .GreaterThan(x => x.FromAmount)
        //     .When(x => x.FromAmount.HasValue && x.ToAmount.HasValue);

        RuleFor(x => x.Surname)
            .Length(10)
            .WithMessage("Please enter {PropertyName}, The value is {PropertyValue}");

        RuleFor(x => x.Addresses).ListMustContainFewerThan(10);
    }
}

public static class MyCustomValidators {
    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num) {
        return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
    }
}

public class Customer 
{
    public int Id { get; set; }
    public string? Surname { get; set; }
    public string? Forename { get; set; }
    public decimal? Discount { get; set; }
    public string? Address { get; set; }
    public int Age { get; set; }
    public decimal? FromAmount { get; set; }
    public decimal? ToAmount { get; set; }
    
    public List<Address>? Addresses { get; set; }
    
    
}

public class Address
{
    public int Id { get; set; }
    public string? AddressDetail { get; set; }
}