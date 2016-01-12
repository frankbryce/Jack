namespace ConsoleApplication11.Model
{
    public struct IntelligenceInput<T>
    {
        public Contentment Contentment { get; set; }
        public T Object { get; set; }
    }
}