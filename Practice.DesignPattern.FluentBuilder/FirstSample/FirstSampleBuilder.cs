namespace Practice.DesignPattern.FluentBuilder
{
    public class FirstSampleBuilder
    {
        private int _firstValue;

        private int _secondValue;

        private int _thirdValue;

        private FirstSampleBuilder() { }

        public static FirstSampleBuilder Empty() => new();

        public FirstSampleBuilder WithFirstValue(int value)
        {
            _firstValue = value;

            return this;
        }

        public FirstSampleBuilder WithSecondValue(int value)
        {
            _secondValue = value;

            return this;
        }

        public FirstSampleBuilder WithThirdValue(int value)
        {
            _thirdValue = value;

            return this;
        }

        public FirstSample Build()
        {
            return new FirstSample()
            {
                FirstValue = _firstValue,
                SecondValue = _secondValue,
                ThirdValue = _thirdValue
            };
        }
    }
}
