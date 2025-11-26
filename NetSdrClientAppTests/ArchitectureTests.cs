using NetArchTest.Rules;
using Xunit;
using System.Reflection;
using System.Linq; // Необхідний для Linq (Select, Enumerable.Empty)

namespace NetSdrClientAppTests;

public class ArchitectureTests
{
    // Визначення просторів імен, які ми тестуємо
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
            "Порушення архітектурного правила: Шар Application не має мати прямих залежностей від шару Infrastructure. Порушення: " +
            // ФІНАЛЬНЕ ВИПРАВЛЕННЯ:
            // 1. Використовуємо ?. для null-безпеки. 
            // 2. Select(t => t.FullName) перетворює Type на String.
            string.Join(", ", result.FailingTypes?.Select(t => t.FullName) ?? Enumerable.Empty<string>())); 
    }

    [Fact]
    public void Infrastructure_Should_Not_Be_Accessed_By_UI()
    {
        // Додатковий приклад: UI (LabSonar) не повинен напряму залежати від Infrastructure
        Assembly uiAssembly = Assembly.Load("LabSonar");

        var result = Types.InAssembly(uiAssembly)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful,
            "Шар UI не повинен мати прямих залежностей від Infrastructure. Порушення: " +
            // ФІНАЛЬНЕ ВИПРАВЛЕННЯ:
            string.Join(", ", result.FailingTypes?.Select(t => t.FullName) ?? Enumerable.Empty<string>()));
    }
}
