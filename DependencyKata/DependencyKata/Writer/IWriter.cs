﻿namespace DependencyKata.Writer
{
    public interface IWriter
    {
        void WriteLine(string text);
        void Write(string text);
    }
}