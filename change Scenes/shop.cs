using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class shop : MonoBehaviour
    {
        public void Gotoshop()
        {
            SceneManager.LoadScene("Shop");
        }
    }
}

