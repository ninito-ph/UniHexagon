namespace UniHexagon.Interfaces
{
    public interface ISimpleVectorArithmetic<T>
    {
        public T Add(T a, T b);
        public T Subtract(T a, T b);
        public T Multiply(T a, T b);
    }
}