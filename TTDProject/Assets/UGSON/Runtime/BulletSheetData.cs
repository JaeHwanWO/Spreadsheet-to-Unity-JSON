using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class BulletSheetData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  string bulletname;
  public string Bulletname { get {return bulletname; } set { this.bulletname = value;} }
  
  [SerializeField]
  string description;
  public string Description { get {return description; } set { this.description = value;} }
  
  [SerializeField]
  int damage;
  public int Damage { get {return damage; } set { this.damage = value;} }
  
  [SerializeField]
  BulletType bullettype;
  public BulletType BULLETTYPE { get {return bullettype; } set { this.bullettype = value;} }
  
  [SerializeField]
  int speed;
  public int Speed { get {return speed; } set { this.speed = value;} }
  
  [SerializeField]
  int sprite;
  public int Sprite { get {return sprite; } set { this.sprite = value;} }
  
}