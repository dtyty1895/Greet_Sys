using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriLibCore;
using TriLibCore.General;
public class TestLoader : MonoBehaviour
{
    public string ModelPath= "C:\\Users\\Vincent\\Desktop\\dianjiao.stl";

        private void OnGUI()
        {
            // Displays a button to begin the model loading process.
            if (GUILayout.Button("Load Model from File"))
            {
           

//取消下面注?，就是??加?的demo，?自官网。
            //    // Creates an AssetLoaderOptions instance.
            //    // AssetLoaderOptions is a class used to configure many aspects of the loading process.
            //    // We won't change the default settings this time, so we can use the instance as it is.
                var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();

             //Creates the AssetLoaderFilePicker instance.
             //AssetLoaderFilePicker is a class that allows users to select models from the local file system.
           // var assetLoaderFilePicker = AssetLoaderFilePicker.CreateInstance();  //??被修改?CreateInstance（）
               var assetLoaderFilePicker = AssetLoaderFilePicker.Create();
             //Shows the model selection file-picker.
               assetLoaderFilePicker.LoadModelFromFilePickerAsync("Select a File", OnLoad, OnMaterialsLoad, OnProgress, OnBeginLoad, OnError, null, assetLoaderOptions);
        }
        }

        // This event is called when the model is about to be loaded.
        // You can use this event to do some loading preparation, like showing a loading screen in platforms without threading support.
        // This event receives a Boolean indicating if any file has been selected on the file-picker dialog.
        private void OnBeginLoad(bool anyModelSelected)
        {

        }

        // This event is called when the model loading progress changes.
        // You can use this event to update a loading progress-bar, for instance.
        // The "progress" value comes as a normalized float (goes from 0 to 1).
        // Platforms like UWP and WebGL don't call this method at this moment, since they don't use threads.
        private void OnProgress(AssetLoaderContext assetLoaderContext, float progress)
        {

        }

        // This event is called when there is any critical error loading your model.
        // You can use this to show a message to the user.
        private void OnError(IContextualizedError contextualizedError)
        {

        }

        // This event is called when all model GameObjects and Meshes have been loaded.
        // There may still Materials and Textures processing at this stage.
        private void OnLoad(AssetLoaderContext assetLoaderContext)
        {
            // The root loaded GameObject is assigned to the "assetLoaderContext.RootGameObject" field.
            // If you want to make sure the GameObject will be visible only when all Materials and Textures have been loaded, you can disable it at this step.
            var myLoadedGameObject = assetLoaderContext.RootGameObject;
            myLoadedGameObject.SetActive(false);
        }

        // This event is called after OnLoad when all Materials and Textures have been loaded.
        // This event is also called after a critical loading error, so you can clean up any resource you want to.
        public void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
        {
            // The root loaded GameObject is assigned to the "assetLoaderContext.RootGameObject" field.
            // You can make the GameObject visible again at this step if you prefer to.
            var myLoadedGameObject = assetLoaderContext.RootGameObject;
            myLoadedGameObject.SetActive(true);
        }

}
