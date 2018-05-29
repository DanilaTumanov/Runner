using UnityEngine;

/// <summary>
/// Интерфейс, определяющий контроллеры ввода
/// </summary>
public interface IInputController
{

    float HorizontalAxis { get; }
    float VerticalAxis { get; }
    bool Jump { get; }
    bool Shoot { get; }
    bool PlaceTrap { get; }
    bool Interact { get; }
    bool Aim { get; }
    Vector2 AimingPosition { get; }

}
