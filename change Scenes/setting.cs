using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class setting : MonoBehaviour
    {
        public void Gosetting()
        {
            SceneManager.LoadScene("Setting");
        }
    }
}
