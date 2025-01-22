using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class back : MonoBehaviour
    {
        public void GotoMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
