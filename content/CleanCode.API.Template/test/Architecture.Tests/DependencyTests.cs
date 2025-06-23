using FluentAssertions;

using NetArchTest.Rules;

namespace Custom.Design.Tests;
public class DependencyTests
{
    private const string DomainNamespace = "Custom.Domain";
    private const string ApplicationNamespace = "Custom.Application";
    private const string InfrastructureNamespace = "Custom.Infrastructure";
    private const string PresentationNamespace = "Custom.Presentation";
    private const string PersistenceNamespace = "Custom.Persistence";
    private const string APINamespace = "Custom.API";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Domain.AssemblyReference).Assembly;

        var projectReferencable = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
			APINamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(projectReferencable)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var projectReferencable = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
			APINamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(projectReferencable)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        var projectReferencable = new[]
        {
            PresentationNamespace,
			APINamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(projectReferencable)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;

        var projectReferencable = new[]
        {
			APINamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(projectReferencable)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Persistance_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Persistence.AssemblyReference).Assembly;

        var projectReferencable = new[]
        {
			APINamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(projectReferencable)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Web_Should_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(API.AssemblyReference).Assembly;

        var projectReferencable = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            PersistenceNamespace,
            DomainNamespace,
            ApplicationNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .Should()
            .NotHaveDependencyOnAll(projectReferencable)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}
