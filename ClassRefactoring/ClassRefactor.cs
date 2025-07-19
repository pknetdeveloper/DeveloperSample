using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            return swallowType switch
            {
                SwallowType.African => new AfricanSwallow(),
                SwallowType.European => new EuropeanSwallow(),
                _ => throw new ArgumentException($"Unknown swallow type: {swallowType}")
            };
        }
    }

    public abstract class Swallow
    {
        public SwallowLoad Load { get; private set; } = SwallowLoad.None;

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }

    public class AfricanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load == SwallowLoad.Coconut ? 18 : 22;
        }
    }

    public class EuropeanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load == SwallowLoad.Coconut ? 16 : 20;
        }
    }
}