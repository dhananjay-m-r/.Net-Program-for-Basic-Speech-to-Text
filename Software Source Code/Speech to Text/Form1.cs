using System;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Drawing;

namespace Speech_to_Text
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine recognizer;

        public Form1()
        {
            InitializeComponent();
            InitializeSpeechRecognition();
        }

        private void InitializeSpeechRecognition()
        {
            recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.AppendText(e.Result.Text + Environment.NewLine);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            label3.ForeColor = Color.FromArgb(31, 212, 175);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            recognizer.RecognizeAsyncStop();
            label3.ForeColor = Color.FromArgb(255, 105, 123);
        }
    }
}
