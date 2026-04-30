using FluentAssertions;

using NetArchTest.Rules;

namespace Custom.Design.Tests;

public class DependencyTests
{
	private const string DomainNamespace = "Custom.Domain";
	private const string InfrastructureNamespace = "Custom.Infrastructure";
	private const string APINamespace = "Custom.API";

	[Fact]
	public void Domain_Should_Not_HaveDependencyOnOtherProjects()
	{
		// Arrange
		var assembly = typeof(Domain.AssemblyReference).Assembly;

		var projectReferencable = new[]
		{
			APINamespace,
			InfrastructureNamespace,
		};

		// Act
		var testResult = Types
			.InAssembly(assembly)
			.ShouldNot()
			.HaveDependencyOnAny(projectReferencable)
			.GetResult();

		// Assert
		testResult.IsSuccessful.Should().BeTrue();
	}

	[Fact]
	public void Infrastructure_ShouldNot_HaveDependencyOnOtherProjects()
	{
		// Arrange
		var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

		var projectReferencable = new[]
		{
			DomainNamespace,
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
	public void API_ShouldNot_HaveDependencyOnOtherProjects()
	{
		// Arrange
		var assembly = typeof(API.AssemblyReference).Assembly;

		var projectReferencable = new[]
		{
			InfrastructureNamespace,
			DomainNamespace,
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
}
