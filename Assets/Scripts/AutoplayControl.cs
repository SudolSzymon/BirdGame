using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoplayControl : MonoBehaviour
{
    const float dificulty = 1.05f;
    public List<GameObject> obstacles;
    public float nextSpawn = 0;
    private bool isPlaying = true;
    public GameObject player;
    public float spawnTime;
    public float speed;
    public Text score;
    private int currentScore = 0;
    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1280, 640, false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (player.GetComponent<AutoPlayBird>().dead)
        {
            isPlaying = false;
        }
    }
    void FixedUpdate()
    {
       
        if (Time.time > nextSpawn && isPlaying)
        {
            nextSpawn = Time.time + spawnTime;
            currentScore++;
            var obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)]);
            obstacle.GetComponent<Rigidbody2D>().velocity = transform.right * speed * -1;
            if (speed <= 30)
            {
                speed = speed * dificulty;
                spawnTime = spawnTime * (1 / dificulty);
                Physics2D.gravity = Physics2D.gravity * dificulty * dificulty;
                player.GetComponent<AutoPlayBird>().changeOfDificulty(dificulty);
            }
        }
    }
    private void OnGUI()
    {
        score.text = currentScore.ToString();
    }
}
