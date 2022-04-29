using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private float _criticalRate;
    private int _attackDamage;
    private int _armor;
    private int _hp;

    public int AttackDamage { get { return _attackDamage; } }
    public int Armor { get { return _armor; } }
    public float CriticalRate { get { return _criticalRate; } }
    public int HP { get { return _hp; } }

    public Stat(int maxHp, int maxDamage, int armor, float maxCriticalRate)
    {
        if (maxHp < 501)
        {
            maxHp = 501;
        }

        _hp = Random.Range(500, maxHp);
        _attackDamage = Random.Range(1, maxDamage);
        _armor = armor;
        _criticalRate = Mathf.Floor(Random.Range(0f, maxCriticalRate) * 100f) * 0.01f;
    }

    public void DecreaseHP(int damage)
    {
        this._hp -= damage;

        if (this._hp < 0)
        {
            this._hp = 0;
        }
    }

    public override string ToString()
    {
        return string.Format(
            "체력: {0}\n공격력: {1}\n방어력: {2}\n크리티컬 확률: {3}\n"
            , this._hp, this._attackDamage, this._armor, this._criticalRate
        );
    }
}
