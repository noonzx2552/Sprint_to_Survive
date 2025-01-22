using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class normal_jungle : MonoBehaviour
    {
        public void Gonormal()
        {
            SceneManager.LoadScene("green_normal");

        }
    }
}