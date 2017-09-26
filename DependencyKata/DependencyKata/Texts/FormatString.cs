namespace DependencyKata.Texts {
    public class FormatString : IText
    {
        private readonly string _formatText;
        private readonly object[] _args;

        public FormatString(string formatText, params object[] args)
        {
            _formatText = formatText;
            _args = args;
        }

        public string AsString() => string.Format(_formatText, _args);
    }
}