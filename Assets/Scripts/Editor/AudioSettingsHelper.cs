using UnityEngine;
using UnityEditor;
 
// /////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Batch audio import settings modifier.
//
// Modifies all selected audio clips in the project window and applies the requested modification on the
// audio clips. Idea was to have the same choices for multiple files as you would have if you open the
// import settings of a single audio clip. Put this into Assets/Editor and once compiled by Unity you find
// the new functionality in Custom -> Sound. Enjoy! :-)
//
// April 2010. Based on Martin Schultz's texture import settings batch modifier.
//
// /////////////////////////////////////////////////////////////////////////////////////////////////////////
public class ChangeAudioImportSettings : ScriptableObject 
{

    [MenuItem("Audio Helper/Set Default Presets")]
    static void SetDefaultsPresets()
    {
        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips)
        {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            var settings = audioImporter!.defaultSampleSettings;
            
            //force to mono
            audioImporter.forceToMono = true; 
            
            //vorbis 50
            settings.compressionFormat = AudioCompressionFormat.Vorbis;
            settings.quality = 0.5f;
            audioImporter.defaultSampleSettings = settings;
            
            AssetDatabase.ImportAsset(path);
        }
    }
    [MenuItem ("Audio Helper/Set Compression/PCM")]
    static void SetCompressionPCM() 
    {
        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips)
        {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            var settings = audioImporter.defaultSampleSettings;
            settings.compressionFormat = AudioCompressionFormat.PCM;
            audioImporter.defaultSampleSettings = settings;
            AssetDatabase.ImportAsset(path);
        }
    }

    [MenuItem("Audio Helper/Set Compression/Vorbis/1%")]
    static void Vorbis01() => SetVorbisCompression(0.01f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/10%")]
    static void Vorbis10() => SetVorbisCompression(0.1f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/15%")]
    static void Vorbis15() => SetVorbisCompression(0.15f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/20%")]
    static void Vorbis20() => SetVorbisCompression(0.20f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/25%")]
    static void Vorbis25() => SetVorbisCompression(0.25f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/30%")]
    static void Vorbis30() => SetVorbisCompression(0.3f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/40%")]
    static void Vorbis40() => SetVorbisCompression(0.4f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/50%")]
    static void Vorbis50() => SetVorbisCompression(0.5f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/60%")]
    static void Vorbis60() => SetVorbisCompression(0.6f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/70%")]
    static void Vorbis70() => SetVorbisCompression(0.7f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/80%")]
    static void Vorbis80() => SetVorbisCompression(0.8f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/90%")]
    static void Vorbis90() => SetVorbisCompression(0.9f);
    [MenuItem("Audio Helper/Set Compression/Vorbis/100%")]
    static void Vorbis100() => SetVorbisCompression(100f);

    static void SetVorbisCompression(float value)
    {
        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips)
        {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            var settings = audioImporter.defaultSampleSettings;
            settings.compressionFormat = AudioCompressionFormat.Vorbis;
            settings.quality = value;
            audioImporter.defaultSampleSettings = settings;
            AssetDatabase.ImportAsset(path);
        }
    }

    [MenuItem ("Audio Helper/Force To Mono/False")]
    static void ToggleForceToMono_Auto() 
    {
        SelectedToggleForceToMonoSettings(false);
    }
 
    [MenuItem ("Audio Helper/Force To Mono/True")]
    static void ToggleForceToMono_Forced() 
    {
        SelectedToggleForceToMonoSettings(true);
    }
    
    static void SelectedToggleForceToMonoSettings(bool enabled) 
    {
        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips) {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            audioImporter.forceToMono = enabled;
            AssetDatabase.ImportAsset(path);
        }
    }
 
    static Object[] GetSelectedAudioclips()
    {
        return Selection.GetFiltered(typeof(AudioClip), SelectionMode.DeepAssets);
    }
}