using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace SpeechToText
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer synthesizerObject = new SpeechSynthesizer();
        PromptBuilder promptObject = new PromptBuilder();
        SpeechRecognitionEngine speechRecognitionObject = new SpeechRecognitionEngine();
        Choices choicesListObject = new Choices();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            textBox1.Text = String.Empty;

            //This is custom Grammar
            choicesListObject.Add(new string[] { "Hello", "How are you", "Current location", "Current time", "Open Chrome",  "Welcome", "Thank you", "Close" });
            Grammar grammar = new Grammar(new GrammarBuilder(choicesListObject));

            //This is system generated Grammar
            //Grammar grammar = new DictationGrammar();

            try
            {
                speechRecognitionObject.RequestRecognizerUpdate();
                speechRecognitionObject.LoadGrammar(grammar);
                //Auto generated
                speechRecognitionObject.SpeechRecognized += SpeechRecognitionObject_SpeechRecognized; //This is event handler auto generated
                speechRecognitionObject.SetInputToDefaultAudioDevice();
                speechRecognitionObject.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Error");
            }


        }

        ////This is the event handler
        private void SpeechRecognitionObject_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //MI
            //textBox1.Text = textBox1.Text + e.Result.Text.ToString() + Environment.NewLine;

            //MII
            switch (e.Result.Text.ToString())
            {
                case "Hello":
                    synthesizerObject.SpeakAsync("Hello Rachit");
                    break;
                case "How are you":
                    synthesizerObject.SpeakAsync("I am doing great Rachit how about you");
                    break;
                case "Current location":
                    synthesizerObject.SpeakAsync("current location is Jaipur");
                    break;
                case "Current time":
                    synthesizerObject.SpeakAsync("Current time is " +
                                                 DateTime.Now.ToLongTimeString());
                    break;
                case "Thank you":
                    synthesizerObject.SpeakAsync("Pleasure is all mine Rachit");
                    break;
                case "Open Chrome":
                    Process.Start("chrome", "https://www.google.com/");
                    break;
                case "Close":
                    Application.Exit();
                    break;
            }
            textBox1.Text = textBox1.Text + e.Result.Text.ToString() + Environment.NewLine;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            speechRecognitionObject.RecognizeAsyncStop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
