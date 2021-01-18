using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public void StoreChange()
    {
        SceneManager.LoadScene("Store_scene");
    }
    public void LockerChange()
    {
        SceneManager.LoadScene("Locker_scene");
    }
     public void MembershipChange()
    {
        SceneManager.LoadScene("Membership_scene");
    }
    public void UploadChange()
    {
        SceneManager.LoadScene("Upload_scene");
    }



}
