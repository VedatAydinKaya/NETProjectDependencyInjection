namespace DependcyInjection
{
    public class NumGenerator2 : INumGenerator2
    {
        public int RandomValue { get; }

        //private INumGenerator numGenerator;


        public NumGenerator2()
        {
            RandomValue = new Random().Next(1000);

            //numGenerator = generator;
        }

        //public int GetRandomValue()
        //{
        //   return numGenerator.RandomValue;
        //}
        public int GetRandomValue()
        {
            return new Random().Next(1000);
        }
    }
    public interface INumGenerator2
    {
        public int RandomValue { get; }

        public int GetRandomValue();
    }
}
