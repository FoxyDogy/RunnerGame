internal class ProjectionHits
{
    public ProjectionHits(float max, float min)
    {
        Min = min;
        Max = max;
    }

    public float Max { get; }
    public float Min { get; }

    public ProjectionHits AddPadding(float paddingToMax, float paddingToMin)
    {
        return new ProjectionHits(Max + paddingToMax, Min - paddingToMin);
    }
}