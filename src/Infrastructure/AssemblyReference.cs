using System.Reflection;

namespace Custom.Infrastructure;
public static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
