using UnityEngine;

public class Battle : MonoBehaviour
{
    private Player player_0;
    private Player player_1;

    private float time;
    private bool done;

    [SerializeField]
    private float fightCoolTime;

    private void Start()
    {
        done = false;
        time = 0f;

        player_0 = new Player(0, 1000, 15, 9, 30);
        player_1 = new Player(1, 1000, 30, 5, 45);

        Debug.Log("플레이어 0의 Stat");
        Debug.Log(player_0.Stat);

        Debug.Log("플레이어 1의 Stat");
        Debug.Log(player_1.Stat);
    }

    private void Update()
    {
        if (done)
        {
            return;
        }

        time += Time.deltaTime;

        if (time > fightCoolTime)
        {
            time = 0f;

            // 공격 우선권
            if (Random.Range(0, 2) == 0)
            {
                done = Fight(player_0, player_1);
            }
            else
            {
                done = Fight(player_1, player_0);
            }
        }
    }

    private bool Fight(Player playerA, Player playerB)
    {
        // playerA -> playerB
        Debug.LogFormat("플레이어 {0}(이)가 플레이어 {1}을 공격", playerA.ID, playerB.ID);
        playerA.Attack(playerB);

        if (playerB.IsDie())
        {
            Debug.LogFormat("플레이어 {0}(이)가 승리", playerA.ID);
            return true;
        }

        return false;
    }
}
