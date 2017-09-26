using System;

namespace DependencyKata.Texts {
    public class ReverseString : IText
    {
        private readonly string _text;

        public ReverseString(string text) => _text = text;

        public string AsString()
        {
            char[] array = _text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}