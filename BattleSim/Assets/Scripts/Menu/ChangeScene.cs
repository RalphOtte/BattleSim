using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{

    public void SceneChange(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
}
