using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] int HealthCurrent;
    [SerializeField] int HealthMax;

    [Header("Damage")]
    [SerializeField] float DamageValue;
    [SerializeField] float HealingValue;
    
    protected int getHealth(){
        return HealthCurrent;
    }
    protected int getMaxHealth(){
        return HealthMax;
    }
    
    public virtual void ApplyDamage(int OtherHealth) {
        OtherHealth -= (int)DamageValue;
    }
    public virtual void Applyhealing(int OtherHealth) {
        OtherHealth += (int)HealingValue;
    }


}
