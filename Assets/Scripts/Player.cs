using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int _id;
    private Stat _stat;

    // get
    public Stat Stat { get { return _stat; } }
    public int ID { get { return _id; } }

    public Player(int playerId, int maxHp, int maxDamage, int armor, int maxCriticalRate)
    {
        _id = playerId;
        _stat = new Stat(maxHp, maxDamage, armor, maxCriticalRate);
    }

    public void Attack(Player otherPlayer)
    {
        int trueDamage = this._stat.AttackDamage;
        
        if (Random.value * 100f < this._stat.CriticalRate)
        {
            Debug.Log("치명타!");
            trueDamage = Mathf.FloorToInt(trueDamage * 1.5f);
        }
            
        otherPlayer.Attacked(this._stat.AttackDamage);
    }

    public void Attacked(int damage)
    {
        int trueDamage = damage < this._stat.Armor
            ? 0
            : damage - this._stat.Armor;

        Debug.Log(string.Format("플레이어 {0}(이)가 {1}의 데미지를 받았습니다.", _id, trueDamage));
        this._stat.DecreaseHP(trueDamage);
        Debug.Log(string.Format("플레이어 {0}의 남은 체력 : {1}", _id, this._stat.HP));
    }

    public bool IsDie()
    {
        if (this._stat.HP == 0)
        {
            return true;
        }

        return false;
    }
}
