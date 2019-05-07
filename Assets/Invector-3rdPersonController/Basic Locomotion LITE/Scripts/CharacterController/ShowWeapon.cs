using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowWeapon : MonoBehaviour
{
    [SerializeField]
    public GameObject item1;
    [SerializeField]
    public GameObject item2;
    public bool showItem1;
    public bool showItem2;
    public Image image1;
    public Image image2;
    public Image[] itemImages = new Image[2];
    // Use this for initialization
    void Start()
    {
        showItem1 = false;
        showItem2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showItem1 == false)
        {
            item1.SetActive(false);
        }
        if (showItem1 == true)
        {
            item1.SetActive(true);
        }
        if (showItem2 == false)
        {
            item2.SetActive(false);
        }
        if (showItem2 == true)
        {
            item2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && showItem1 == false)
        {
            showItem1 = true;
            showItem2 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && showItem2 == false)
        {
            showItem2 = true;
            showItem1 = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            showItem2 = false;
            showItem1 = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            RemoveItem();
        }
            
    }
    public void AddItem(GameObject itemToAdd)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && item1 == null)
        {
            if (itemToAdd.tag.Equals("Sword"))
            {
                item1 = itemToAdd;
                image1 = itemImages[0];
            }
            if (itemToAdd.tag.Equals("Gun")) { 
                item1 = itemToAdd;
                image1 = itemImages[0];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && item2 == null)
        {
            if (itemToAdd.tag.Equals("Sword"))
            {
                item2 = itemToAdd;
                image2 = itemImages[0];
            }
            if (itemToAdd.tag.Equals("Gun"))
            {
                item2 = itemToAdd;
                image2 = itemImages[0];
            }

        }
    }
    public void RemoveItem()
    {
        if (item1 != null && showItem1 == true)
        {
            item1 = null;
            image1 = null;
            showItem1 = false;

        }
        if (item2 != null && showItem2 == true)
        {
            item2 = null;
            image2 = null;
            showItem2 = false;

        }
    }
}