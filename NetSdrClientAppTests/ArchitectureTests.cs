using NetArchTest.Rules;
using Xunit;
using System.Reflection;

namespace NetSdrClientAppTests;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "LabSonar.Application";
    private const string InfrastructureNamespace = "LabSonar.Infrastructure";
    
    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        // Arrange
        Assembly applicationAssembly = Assembly.Load(ApplicationNamespace);

        // Act
        var result = Types.InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, 
            "Application layer must not have direct dependency on Infrastructure layer. Violations: " +
            string.Join(", ", result.FailingTypes));
    }
}