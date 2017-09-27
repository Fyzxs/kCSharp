namespace DependencyKata.Texts {
    public class EqualStrings
    {
        private readonly string _lhs;
        private readonly string _rhs;

        public EqualStrings(string lhs, string rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public bool Value() => _lhs == _rhs;
    }
}