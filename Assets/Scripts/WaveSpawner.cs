using UnityEngine;
using TMPro;
using System.Collections;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Material Organic, Plastic, Metal;
    public float waveCountdown = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 1;
    //private float numOfEnemies = 1f;
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waveCountdown;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            Types.EnemyTypes enemyType;
            enemyType = (Types.EnemyTypes)(MathUtils.GetRandomInt(0, 100) % 3);
            SpawnEnemy(enemyType);
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy(Types.EnemyTypes enemyType)
    {
        switch (enemyType)
        {
            case Types.EnemyTypes.Organic:
                enemyPrefab.GetComponent<Renderer>().material = (Material)Instantiate(Organic);
                enemyPrefab.tag = "OrganicEnemy";
                break;
            case Types.EnemyTypes.Plastic:
                enemyPrefab.GetComponent<Renderer>().material = (Material)Instantiate(Plastic);
                enemyPrefab.tag = "PlasticEnemy";
                break;
            case Types.EnemyTypes.Metal:
                enemyPrefab.GetComponent<Renderer>().material = (Material)Instantiate(Metal);
                enemyPrefab.tag = "MetallicEnemy";
                break;
            default:
                break;
        }
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}