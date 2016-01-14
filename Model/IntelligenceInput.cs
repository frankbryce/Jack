using System;

namespace Jack.Model
{
    public struct IntelligenceInput
    {
        public Contentment Contentment { get; set; }
        public object Object { get; set; }
    }

    public struct IntelligenceInput<T>
    {
        public Contentment Contentment { get; set; }
        public T Object { get; set; }

        public static implicit operator IntelligenceInput(IntelligenceInput<T> value) =>
            new IntelligenceInput {
                Contentment = value.Contentment,
                Object = value.Object
            };

        public static implicit operator IntelligenceInput<T>(IntelligenceInput value)
        {
            try
            {
                return new IntelligenceInput<T>
                {
                    Contentment = value.Contentment,
                    Object = (T)value.Object
                };
            }
            catch (Exception)
            {
                return new IntelligenceInput<T>
                {
                    Contentment = value.Contentment,
                    Object = default(T)
                };
            }
        }
    }
}