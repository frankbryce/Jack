namespace ConsoleApplication11.Model
{
    public sealed class IntelligenceInput<T>
    {
        public Contentment Contentment { get; set; }
        public T Object { get; set; }
    }
}