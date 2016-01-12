using ConsoleApplication11.Model;

namespace ConsoleApplication11.IntelligentEntity
{
    public class Jack : IntelligentEntity<uint, bool>
    {
        protected override IntelligenceOutput<bool> NextOutput()
        {
            return Input == null ? 
                new IntelligenceOutput<bool> {Object = false} : 
                new IntelligenceOutput<bool> {Object = Input.Object==0};
        }

        public override string ToString() => Output.Object ? "dodge" : "straight";
    }
}