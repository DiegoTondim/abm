namespace ABM.Application.Models
{
    public class LocModel
    {
        public string FirstSegment { get; }
        public string SecondSegment { get; }

        public LocModel(string first, string second)
        {
            FirstSegment = first;
            SecondSegment = second;
        }
    }
}
