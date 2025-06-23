using System.Reflection;

namespace Custom.Presentation;
public static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
