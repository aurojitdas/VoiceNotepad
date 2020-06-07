using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.Threading;

namespace FileIO
{
    class SpeechSynth
    {
        SpeechSynthesizer speechObj;

        public void startReading(String text)

        {
            if (speechObj==null)
            {
                speechObj = new SpeechSynthesizer();               
                speechObj.SpeakAsync(text);
            }
            else
            {
                speechObj.SpeakAsyncCancelAll();
                speechObj.SpeakAsync(text);
            }
            
         

        }

        public void pause()
        {
            if (speechObj.State==SynthesizerState.Speaking)
            {

                speechObj.Pause();
                _ = new SpeechSynthesizer().SpeakAsync("Pausing");
            }
        }

        public void resume()
        {
            if (speechObj.State == SynthesizerState.Paused)
            {
               
                speechObj.Resume();
            }
        }


        public void pauseOrResume()
        {
            if (speechObj.State == SynthesizerState.Speaking)
            {

                speechObj.Pause();
                _ = new SpeechSynthesizer().SpeakAsync("Pausing");
            }
            else if (speechObj.State == SynthesizerState.Paused)
            {

                speechObj.Resume();
            }
        }

        public void stop()
        {
            speechObj.SpeakAsyncCancelAll();
        }
    }
}
