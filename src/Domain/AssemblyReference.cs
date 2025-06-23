using System.Reflection;

namespace Custom.Domain;
public static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}
