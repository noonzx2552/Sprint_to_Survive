using UnityEngine;
using UnityEngine.SceneManagement;

namespace script.change_Scenes
{
    public class normal_sand : MonoBehaviour
    {
        public void Gonormal()
        {
            SceneManager.LoadScene("DesertRunLvl1_normal");

        }
    }
}