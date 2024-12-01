using OpenTK.Audio.OpenAL;

namespace SuperJet
{
    public class AudioManager
    {
        public static int LoadSound(string filePath)
        {
            int buffer = AL.GenBuffer();
            int source = AL.GenSource();

            AL.Source(source, ALSourcei.Buffer, buffer);
            return source;
        }

        public static void PlaySound(int source)
        {
            AL.SourcePlay(source);
        }
    }
}
