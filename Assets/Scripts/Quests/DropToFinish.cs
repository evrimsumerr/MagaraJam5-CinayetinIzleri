using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropToFinish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HideObjects"))
        {
            gameObject.transform.parent = collision.transform;
            QuestManager.Instance.Complete();
            gameObject.tag = "Untagged";
            gameObject.layer = 0;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (collision.gameObject.CompareTag("Objects") && QuestManager.Instance.check != null)
        {
            //QuestManager.Instance.Complete();
            QuestManager.Instance.check.SetActive(false);
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("HideObjects"))
    //    {
    //        gameObject.transform.parent = collision.transform;
    //        QuestManager.Instance.check.SetActive(false);
    //    }
    //}
}
