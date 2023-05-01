using UnityEngine;
using Calamity.EventSystem;
using Calamity.Primitives;

public class PlayerHealthObserver : MonoBehaviour
{
    [SerializeField] private IntReference healthReference;

    [Space]

    [SerializeField] private GameEvent playerDamagedEvent;
    [SerializeField] private GameEvent playerHealedEvent;
    [SerializeField] private GameEvent playerDeathEvent;

    [Space]

    [SerializeField] private IntReference[] playerHealthThresholdReferences;
    [SerializeField] private GameEvent[] playerHealthThresholdEvents;

    private int lastValue;

    private void Start()
    {
        lastValue = healthReference.Value;
    }

    [ContextMenu("Damage Player")]
    public void TEST_DamagePlayer()
    {
        healthReference.Value -= 1;
    }

    [ContextMenu("Heal Player")]
    public void TEST_HealPlayer()
    {
        healthReference.Value += 1;
    }

    public void OnPlayerHealthChange()
    {
        if (healthReference.Value > lastValue)
        {
            playerHealedEvent?.Invoke();
        }
        else if (healthReference.Value < lastValue)
        {
            playerDamagedEvent?.Invoke();
        }

        lastValue = healthReference.Value;

        for (int i = 0; i < playerHealthThresholdReferences.Length; i++)
        {
            if (healthReference.Value == playerHealthThresholdReferences[i].Value)
            {
                playerHealthThresholdEvents[i].Invoke();
            }
        }

        if (healthReference.Value <= 0)
        {
            playerDeathEvent?.Invoke();
        }
    }
}