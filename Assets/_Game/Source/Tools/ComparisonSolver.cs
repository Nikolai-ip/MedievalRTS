namespace _Game.Source.Tools
{
    public static class ComparisonSolver
    {
        public static bool Solve(int a, ComparisonType comparisonType, int b)
        {
            switch (comparisonType)
            {
                case ComparisonType.Equal: return (a == b);
                case ComparisonType.NotEqual: return (a != b);
                case ComparisonType.GreaterThan: return (a > b);
                case ComparisonType.GreaterThanOrEqual: return (a >= b);
                case ComparisonType.LessThan: return (a < b);
                case ComparisonType.LessThanOrEqual: return (a <= b);
                default: return false;
            }
        }
    }
    public enum ComparisonType
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        
    }
}