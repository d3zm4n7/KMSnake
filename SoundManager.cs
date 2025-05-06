using System.Media;
using NAudio.Wave;

public class SoundManager
{
    private IWavePlayer musicPlayer;
    private AudioFileReader musicReader;

    public void PlayBackgroundMusic(string path)
    {
        musicPlayer = new WaveOutEvent();
        musicReader = new AudioFileReader(path);
        musicPlayer.Init(musicReader);
        musicPlayer.Play();
    }

    public void PlaySoundEffect(string wavPath)
    {
        SoundPlayer sound = new SoundPlayer(wavPath);
        sound.Play();
    }

    public void StopMusic()
    {
        musicPlayer?.Stop();
        musicReader?.Dispose();
        musicPlayer?.Dispose();
    }
}
