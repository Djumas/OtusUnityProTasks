using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

public class PlayerLevelHelper : MonoBehaviour
{
    [ShowInInspector] private PlayerLevel _playerLevel;

    [Inject]
    public void Construct(PlayerLevel playerLevel)
    {
        _playerLevel = playerLevel;
    }
}
