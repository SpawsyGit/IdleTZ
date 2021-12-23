using UnityEngine;

[CreateAssetMenu(
    fileName = "IdleConfig", 
    menuName = "Configs/IdleConfig")]
    
public class IdleConfig : ScriptableObject
{
    public float MaxHealth;
    public float Interval;
    
}
