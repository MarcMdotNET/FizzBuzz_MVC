namespace FizzBuzz_MVC.Models
{
    public class FizzBuzz
    {
        public int FizzValue { get; set; } = 3;
        public int BuzzValue { get; set; } = 5;
        public int StartRange { get; set; } = 1;
        public int EndRange { get; set; } = 100;
        public List<string> Results { get; set; } = new List<string>();
    }
}
