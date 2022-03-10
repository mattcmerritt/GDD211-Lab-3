using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemies : MonoBehaviour
{
    private float BasicTime = 1.5f, RangedTime = 3f;
    private float BasicTimer = 1.5f, RangedTimer = 3f;

    [SerializeField]
    private float BoundX, BoundY;
    [Range(0, 20), SerializeField]
    private int BasicEnemyCount, RangedEnemyCount;

    [SerializeField]
    private GameObject BasicEnemyPrefab, RangedEnemyPrefab;

    [SerializeField]
    private GameObject PlayerPrefab;

    private void Start()
    {
        for (int b = 0; b < BasicEnemyCount; b++)
        {
            Spawn(BasicEnemyPrefab);
        }
        for (int r = 0; r < RangedEnemyCount; r++)
        {
            Spawn(RangedEnemyPrefab);
        }
    }

    private void Update()
    {
        if (BasicTimer <= 0f)
        {
            Spawn(BasicEnemyPrefab);
            BasicTimer = BasicTime;
        }
        else
        {
            BasicTimer -= Time.deltaTime;
        }

        if (RangedTimer <= 0f)
        {
            Spawn(RangedEnemyPrefab);
            RangedTimer = RangedTime;
        }
        else
        {
            RangedTime -= Time.deltaTime;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        // This is causing crashes, switching to scene reloading
        //Enemy[] enemies = FindObjectsOfType<Enemy>();
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    Destroy(enemies[i].gameObject);
        //}
        //Projectile[] proj = FindObjectsOfType<Projectile>();
        //for (int i = 0; i < proj.Length; i++)
        //{
        //    Destroy(proj[i].gameObject);
        //}

        //Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
        //FindObjectOfType<SpawnEnemies>().Restart();

        //FindObjectOfType<UI>().ResetScore();
        //FindObjectOfType<UI>().UpdateHealth(100);
        //FindObjectOfType<UI>().HideButton();

        //BasicTimer = 1.5f;
        //RangedTimer = 3f;
        //for (int b = 0; b < BasicEnemyCount; b++)
        //{
        //    Spawn(BasicEnemyPrefab);
        //}
        //for (int r = 0; r < RangedEnemyCount; r++)
        //{
        //    Spawn(RangedEnemyPrefab);
        //}
    }

    private void Spawn(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(Random.Range(-BoundX, BoundX), Random.Range(-BoundY, BoundY), 0f), Quaternion.identity);
    }
}
