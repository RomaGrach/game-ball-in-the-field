
using System.Collections.Generic;

namespace SaveData
{
    [System.Serializable]
    public class ForSaving
    {
        public string Name;

        public int[] listabs;

        public int[,] listabs2;

        public List<List<int>> intListSave;

        public ForSaving()
        {
            Name = "Player";
            listabs = new int[] { 1, 1 };
            listabs2 = new int[,] { { 1, 1 } };
            intListSave = new List<List<int>> { new List<int> { 0, 1 } };
        }
    }
}