using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject pnlPause;
    public GameController gameController;

    public SceneFader sceneFader;
    public bool inGame = false;
    public GameObject pnlGuide;
    public Text titleGuide;
    public Text textGuide;
    public GameObject pause;
    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.P) && inGame)
            {
                PauseMenu();
            }
    }


    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        // Nếu thua thì load lại màn chơi khi gọi hàm
        gameController.endGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //WaveSpawner.EnemiesAlive = 0;
        //EnemyController.enemy = 0;
    }

    public void PauseMenu()
    {
        // Gọi hàm thì tạm dừng game
        pnlPause.SetActive(!pnlPause.activeSelf);
        pause.SetActive(!pause.activeSelf);
        if (pnlPause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Guide()
    {
        pnlGuide.SetActive(true);
        titleGuide.text = "Hướng dẫn";
        textGuide.text = "Sử dụng các phím W S A D để di chuyển tương ứng với các hướng trên, dưới, trái, phải\n" +
            "Nhấn chuột trái để bắn.\n" +
            "Nhấn phím P để mở menu trong lúc chơi game nhấn lại để đóng hoặc nhấn vào nút close trên màn hình.\n" +
            "Cảm ơn các bạn đã chơi game, chúc các bạn chơi vui vẻ! ";
    }

    public void Close(GameObject gameObject)
    {
        if(inGame)
        {
            PauseMenu();
        }
        else
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }

    public void Play()
    {
        sceneFader.FadeTo("Level01");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
