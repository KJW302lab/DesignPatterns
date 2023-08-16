using System;
using UnityEngine;

public class BikeWeapon : MonoBehaviour, IBikeElement
{
    [Header("Range")]
    public int range = 5;
    public int maxRange = 25;
    
    [Header("Strength")]
    public float strength = 25.0f;
    public float maxStrength = 50.0f;

    public void Fire()
    {
        Console.WriteLine("Weapon Fired!");
    }
    
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        
        GUI.Label(new Rect(125f, 40f, 200f, 20f), "Weapon Range : " + range);
        
        GUI.Label(new Rect(125f, 60f, 200f, 20f), "Weapon Strength : " + strength);
    }
}