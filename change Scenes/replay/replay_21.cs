using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class replay_21 : MonoBehaviour
    {
        public void RetryClicked()
        {
            //SceneManager.LoadScene(21);
            //Time.timeScale = 1;
            SceneManager.LoadScene("DesertRunLvl1_normal");
        }
    }
}