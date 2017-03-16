using UnityEngine;
using System.Collections;

public class Fists : MonoBehaviour {

    public GameObject[] moveToObjects;
    public GameObject[] moveGrabObject;
    public GameObject MoveDefendObject;
    public GameObject backObject;


    public void Attacks() {
        StartCoroutine(Attacking());
    }

    public void Defends() {
        StartCoroutine(Defending());
    }


    public void Grabs(Transform grabbedObject) {
        StartCoroutine(Grabbing(grabbedObject));
    }

    IEnumerator Defending() {
        transform.position = MoveDefendObject.transform.position;
        yield return new WaitForSeconds(0.5F);
        transform.position = moveToObjects[0].transform.position;
    }

        IEnumerator Grabbing(Transform grabbedObject) {
        transform.position = moveToObjects[1].transform.position;
        yield return new WaitForSeconds(0.2F);
        grabbedObject.transform.position = moveGrabObject[0].transform.position;
        yield return new WaitForSeconds(1F);
        grabbedObject.transform.position = moveGrabObject[1].transform.position;
        yield return new WaitForSeconds(0.2F);
        transform.position = moveToObjects[0].transform.position;
    }

    IEnumerator Attacking() {
        transform.position = moveToObjects[1].transform.position;
        yield return new WaitForSeconds(0.2F);
        transform.position = moveToObjects[0].transform.position;
    }
}
