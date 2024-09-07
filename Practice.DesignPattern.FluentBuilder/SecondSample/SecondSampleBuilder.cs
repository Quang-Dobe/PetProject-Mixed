namespace Practice.DesignPattern.FluentBuilder
{
    public class SecondSampleBuilder
    {
        private int _firstValue;

        private int _secondValue;

        private SecondSample_FirstChildBuilder _firstChildBuilder = SecondSample_FirstChildBuilder.Empty();

        private SecondSample_SecondChildBuilder _secondChildBuilder = SecondSample_SecondChildBuilder.Empty();

        private SecondSampleBuilder() { }

        public static SecondSampleBuilder Empty() => new();

        public SecondSampleBuilder WithFirstValue(int value)
        {
            _firstValue = value;

            return this;
        }

        public SecondSampleBuilder WithSecondValue(int value)
        {
            _secondValue = value;

            return this;
        }

        public SecondSampleBuilder WithSecondSample_FirstChild(Action<SecondSample_FirstChildBuilder> action)
        {
            action(_firstChildBuilder);

            return this;
        }

        public SecondSampleBuilder WithSecondSample_SecondChild(Action<SecondSample_SecondChildBuilder> action)
        {
            action(_secondChildBuilder);

            return this;
        }

        public SecondSample Build()
        {
            return new SecondSample()
            {
                FirstValue = _firstValue,
                SecondValue = _secondValue,
                FirstChild = _firstChildBuilder.Build(),
                SecondChild = _secondChildBuilder.Build()
            };
        }
    }

    public class SecondSample_FirstChildBuilder
    {
        private string _key;

        private string _value;

        private SecondSample_FirstChildBuilder() { }

        public static SecondSample_FirstChildBuilder Empty() => new();

        public SecondSample_FirstChildBuilder WithKey(string key)
        {
            _key = key;

            return this;
        }

        public SecondSample_FirstChildBuilder WithValue(string value)
        {
            _value = value;

            return this;
        }

        public SecondSample_FirstChild Build()
        {
            return new SecondSample_FirstChild()
            {
                Key = _key,
                Value = _value
            };
        }
    }

    public class SecondSample_SecondChildBuilder
    {
        private string _key;

        private string _value;

        private SecondSample_SecondChildBuilder() { }

        public static SecondSample_SecondChildBuilder Empty() => new();

        public SecondSample_SecondChildBuilder WithKey(string key)
        {
            _key = key;

            return this;
        }

        public SecondSample_SecondChildBuilder WithValue(string value)
        {
            _value = value;

            return this;
        }

        public SecondSample_SecondChild Build()
        {
            return new SecondSample_SecondChild()
            {
                Key = _key,
                Value = _value
            };
        }
    }
}
