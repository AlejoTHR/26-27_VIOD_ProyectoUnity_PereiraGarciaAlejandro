using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] int HealthCurrent;
    [SerializeField] int HealthMax;

    [Header("Damage")]
    [SerializeField] float DamageValue;
    
    protected int getHealth(){
        return HealthCurrent;
    }
    protected int getMaxHealth(){
        return HealthMax;
    }
    
    public virtual void ApplyDamage() {}
    public virtual void Applyhealing() {}


}
