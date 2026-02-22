namespace SampleAutoTest.TestHelpers
{
    public class JsonContains
    {
        public required string Url { get; set; }
        
        public required AnimalSay Animal {  get; set; }

    }
    public class AnimalSay
    {
        public required string Cat { get; set; }
        public required string Cow { get; set; }
        public required string Dog { get; set; }
        public required string Pig { get; set; }
    }
}
