namespace Shared.Helpers;

public interface IPatchingHelper
{
   void Patch<TSource, TTarget>(TSource source, TTarget target);
}