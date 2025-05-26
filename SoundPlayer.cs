
internal class SoundPlayer
{
    private object properties;
    private byte[] clip_Charlotte_2025_04_23;
    private object value;

    public SoundPlayer(string soundPath)
    {
    }

    public SoundPlayer(object properties, byte[] clip_Charlotte_2025_04_23, object value)
    {
        this.properties = properties;
        this.clip_Charlotte_2025_04_23 = clip_Charlotte_2025_04_23;
        this.value = value;
    }

    internal void Load()
    {
        throw new NotImplementedException();
    }

    internal void Play()
    {
        throw new NotImplementedException();
    }
}