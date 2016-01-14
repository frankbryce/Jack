using System;

namespace Jack.Model
{
    public struct IntelligenceOutput
    {
        public object Object { get; set; }
    }

    public struct IntelligenceOutput<T>
    {
        public T Object { get; set; }

        public static implicit operator IntelligenceOutput(IntelligenceOutput<T> value) => 
            new IntelligenceOutput{ Object = value.Object };

        public static implicit operator IntelligenceOutput<T>(IntelligenceOutput value)
        {
            try {
                return new IntelligenceOutput<T>
                {
                    Object = (T) value.Object
                };
            }
            catch (Exception)
            {
                return new IntelligenceOutput<T>
                {
                    Object = default(T)
                };
            }
        }
    }
}