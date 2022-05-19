namespace DataTransferObjects
{
    public class PresureDto
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public List<float> Presures { get; set; }
        public double Mean  => Presures.Sum()/ Presures.Count;
    }
}