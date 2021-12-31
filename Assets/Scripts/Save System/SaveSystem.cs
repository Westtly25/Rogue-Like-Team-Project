using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using System;

namespace RogueLike.Save
{
    public static class SaveSystem
    {
        private const string FILE_NAME = "RogueLikeSave.txt";
        private static readonly string SAVE_PATH = Application.dataPath + "/Saves/";

        private static void Initialize()
        {
            if(!Directory.Exists(SAVE_PATH))
            {
                Directory.CreateDirectory(SAVE_PATH);
            }
        }
        
        public static async Task SaveAsync()
        {
            Initialize();

            string saveString = JsonUtility.ToJson(SaveData.Current);

            try
            {
                using (StreamWriter outputFile = new StreamWriter(SAVE_PATH + FILE_NAME))
                {
                    await outputFile.WriteAsync(saveString);
                }

                Debug.Log("Async Write File has completed");
            }
            catch(Exception e)
            {
			    Debug.LogError($"Failed to write to {SAVE_PATH + FILE_NAME} with exception {e}");
            }
        }

        public static async Task LoadAsync()
        {
            if(File.Exists(Application.dataPath + FILE_NAME))
            {
                string load;
                
                try
                {
                    using (StreamReader outputFile = new StreamReader (SAVE_PATH + FILE_NAME))
                    {
                        load = await outputFile.ReadToEndAsync();
                    }

                    SaveData.Current = JsonUtility.FromJson<SaveData>(load);

                    Debug.Log("Async Read File has completed");
                }
                catch(Exception e)
                {
			        Debug.LogError($"Failed to read from {SAVE_PATH + FILE_NAME} with exception {e}");
                }
            }
        }

        public static void Delete()
        {
            if(File.Exists(Application.dataPath + FILE_NAME))
            {
                try
                {
                    File.Delete(SAVE_PATH + FILE_NAME);
                }
                catch(Exception e)
                {
			        Debug.LogError($"Failed to delete {Application.dataPath + FILE_NAME} with exception {e}");
                }
            }
        }
    }
}