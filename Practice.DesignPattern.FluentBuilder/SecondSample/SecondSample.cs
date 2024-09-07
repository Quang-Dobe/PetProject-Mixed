namespace Practice.DesignPattern.FluentBuilder
{
    public class SecondSample
    {
        public int FirstValue { get; set; }

        public int SecondValue { get; set; }

        public SecondSample_FirstChild FirstChild { get; set; }

        public SecondSample_SecondChild SecondChild { get; set; }
    }

    public class SecondSample_FirstChild
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }

    public class SecondSample_SecondChild
    {
        public string Key { set; get; }

        public string Value { set; get; }
    }
}
