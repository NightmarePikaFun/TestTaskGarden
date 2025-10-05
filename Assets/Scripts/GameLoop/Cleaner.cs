using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField]
    private CleanerObject cleanerObj;

    private bool cleaner = false;

    public bool CanCleen()
    {
        return cleaner;
    }

    public void EnableClean()
    {
        cleaner = true;
        cleanerObj.EnableCleaner();
    }

    public void DisableClean()
    {
        cleaner = false;
        cleanerObj.DisableCleaner();
    }
}
