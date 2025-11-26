using System;

namespace LabSonar.Application
{
    // Цей інтерфейс дозволяє нам підміняти час у тестах
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}