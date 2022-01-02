using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    GameController gameController;
    public string level;
    public SceneFader scene;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        // Nếu thắng thì play Animation
        if (gameController.winGame)
        {
            gameObject.GetComponent<Animator>().SetBool("completed", true);
        }
    }

    //Nếu đủ điều kiện và người chơi chạm vào thì win 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameController.winGame)
        {
            gameController.WinGame();
        }
    }

    // Chuyển sang Level mới
    public void NextLevel()
    {
        scene.FadeTo(level);
        Time.timeScale = 1f;
    }
}
