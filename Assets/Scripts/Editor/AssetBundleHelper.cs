using UnityEditor;
using UnityEngine;
using System.IO;
using System;

public class CreateAssetBundles
{
    [MenuItem("AssetBundleBuilder/Build All AssetBundle")]
    static void BuildAllAssetBundles()
    {
        //we dont really care about target
        string assetBundleDirectory = "AssetBundles/" + BuildTarget.StandaloneWindows.ToString();
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.StandaloneWindows);
    }
}