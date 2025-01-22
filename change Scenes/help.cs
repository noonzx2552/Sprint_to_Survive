using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class help : MonoBehaviour
    {
        public void Gohelp()
        {
            SceneManager.LoadScene("help");
        }
    }
}
