using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
///
[System.Serializable]
public class TowerSheetData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  string towername;
  public string Towername { get {return towername; } set { this.towername = value;} }
  
  [SerializeField]
  string description;
  public string Description { get {return description; } set { this.description = value;} }
  
  [SerializeField]
  Bullet bullet;
  public Bullet BULLET { get {return bullet; } set { this.bullet = value;} }
  
  [SerializeField]
  int spritebase;
  public int Spritebase { get {return spritebase; } set { this.spritebase = value;} }
  
  [SerializeField]
  int spritebarrel;
  public int Spritebarrel { get {return spritebarrel; } set { this.spritebarrel = value;} }
  
  [SerializeField]
  int cost;
  public int Cost { get {return cost; } set { this.cost = value;} }
  
  [SerializeField]
  int atkrange;
  public int Atkrange { get {return atkrange; } set { this.atkrange = value;} }
  
  [SerializeField]
  float atkdelay;
  public float Atkdelay { get {return atkdelay; } set { this.atkdelay = value;} }
  
  [SerializeField]
  int atkcount;
  public int Atkcount { get {return atkcount; } set { this.atkcount = value;} }
  
  [SerializeField]
  int bulletpos;
  public int Bulletpos { get {return bulletpos; } set { this.bulletpos = value;} }
  
}