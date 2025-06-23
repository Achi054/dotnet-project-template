using System.Reflection;

namespace Custom.Persistence;
public static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
