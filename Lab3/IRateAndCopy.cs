namespace Tlab._1
{
    internal interface IRateAndCopy
    {
        double Rating { get; }
        IRateAndCopy DeepCopy();
    }
}