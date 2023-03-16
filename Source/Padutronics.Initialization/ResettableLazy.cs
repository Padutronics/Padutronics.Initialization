using System;

namespace Padutronics.Initialization;

public sealed class ResettableLazy<T>
{
    private readonly Func<Lazy<T>> valueHolderFactory;

    private Lazy<T> valueHolder;

    public ResettableLazy() :
        this(() => new Lazy<T>())
    {
    }

    public ResettableLazy(Func<Lazy<T>> valueHolderFactory)
    {
        this.valueHolderFactory = valueHolderFactory;

        valueHolder = valueHolderFactory();
    }

    public ResettableLazy(Func<T> valueFactory) :
        this(() => new Lazy<T>(valueFactory))
    {
    }

    public bool IsValueCreated => valueHolder.IsValueCreated;

    public T Value => valueHolder.Value;

    public void Reset()
    {
        if (IsValueCreated)
        {
            valueHolder = valueHolderFactory();
        }
    }

    public override string ToString()
    {
        return valueHolder.ToString() ?? throw new Exception("A string representation is null.");
    }
}