using System;

namespace Padutronics.Initialization;

public static class ResettableLazyExtensions
{
    public static void Dispose<T>(this ResettableLazy<T> @this)
        where T : IDisposable
    {
        if (@this.IsValueCreated)
        {
            @this.Value.Dispose();
        }
    }
}