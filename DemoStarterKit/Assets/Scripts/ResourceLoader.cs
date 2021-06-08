using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour {
    public static ResourceLoader _instance = null;
    public static ResourceLoader Instance { get { return _instance; } }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        }
    }

    public Sprite LoadSprite_TowerBase(int index) {
        return Resources.Load<Sprite>(string.Format("Sprites/Tower/sprite_tower_base_{0}", index.ToString()));
    }

    public Sprite LoadSprite_TowerBarrel(int index) {
        return Resources.Load<Sprite>(string.Format("Sprites/Tower/sprite_tower_barrel_{0}", index.ToString()));
    }

    public MyTower Load_Tower(TowerSheetData data) {
        MyTower result = Instantiate(Resources.Load("Prefabs/TowerPrefab") as GameObject).GetComponent<MyTower>();
        result.SetData(data);
        return result;
    }

    public GameObject Load_Bullet(BulletType type) {
        GameObject bullet = Instantiate(Resources.Load("Prefabs/BulletPrefab") as GameObject);
        bullet.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("Sprites/Tower/sprite_bullet_{0}", (int)type));
        return bullet;
    }

}
