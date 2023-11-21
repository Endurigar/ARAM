using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(fileName = "ItemInfo", menuName = "UI/ItemInfo")]
    public class ItemInfo : ScriptableObject,IItem
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public float Cost { get; set; }
        [field: SerializeField] public GameObject Icon { get; set; }
        
        public void UseItem()
        {
            throw new System.NotImplementedException();
        }
    }
}