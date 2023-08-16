using UnityEngine;

public class BikeShield : MonoBehaviour, IBikeElement
{
    public float health = 50.0f;

    public float Damage(float damage)
    {
        health -= damage;
        return health;
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        
        GUI.Label(new Rect(125f, 0f, 200f, 20f), "Shield Health : " + health);
    }
}