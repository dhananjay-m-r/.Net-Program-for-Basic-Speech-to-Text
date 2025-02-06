# C# .Net Windows Forms app for converting speech to text
In this repository is a simple C# .net Windows Forms application that converts speech into text using speech recognition. 

It allows you to speak into your microphone, and the app will transcribe what you say into text on the screen.

### Features:
- Start Recognition: When you click the "Start" button, the app begins listening for speech.
- Stop Recognition: When you click the "Stop" button, it stops listening for speech.
- Display Text: As you speak, the recognized text will appear in the app.


### Application Controls:
- Start Button: Starts the speech recognition process.
- Stop Button: Stops the speech recognition process.

### How to Use:
- Click the "Start" button to begin speaking.
- Click the "Stop" button to stop the recognition.

This is a basic model and inaccuracies maybe observed during the recognition. 

To improve recognition quality, try the following: 
1. Use a Higher-Quality Microphone
2. Improve your Surrounding Audio!

### How It Works:
- Speech Recognition: The app uses `SpeechRecognitionEngine` to listen to your microphone and recognize what you say.
- Display Results: The recognized text is shown in a `RichTextBox` on the screen.
- Change of Colors: The label color changes to show if the app is actively listening (green) or stopped (red).

# Breakdown & Explanation in development of the software and its source code:

## Designing the user interface 
1. First, create a new Windows Forms App (.NET Framework) project in Visual Studio.
2. Add a reference to the System.Speech assembly. You can do this by right-clicking on the project in the Solution Explorer, selecting "Add Reference," and then finding and checking the System.Speech library in the list.
3. Design your form with a RichTextBox and a Button to start and stop the recongnition process.

## Source Code Explanation
### Namespaces:
**System.Speech.Recognition**: This is the namespace that provides classes for speech recognition.

**System.Windows.Forms:** Contains classes for creating Windows-based graphical user interfaces.

**System.Drawing:** Provides basic drawing functionality for Windows Forms applications (e.g., manipulating colors).

### The `Form1` Class:
- This is the main class for the form. It inherits from `Form` and is the entry point for the application.

**SpeechRecognitionEngine recognizer:**
- This object is responsible for performing the speech recognition operations. It listens for audio input from the default device (microphone) and attempts to recognize speech.

### Constructor: `Form1()`
- Calls `InitializeComponent()`, which is auto-generated and initializes the form’s components like buttons, text boxes, etc.
- Calls `InitializeSpeechRecognition()`, which sets up speech recognition and prepares it for listening to input.

### Method: `InitializeSpeechRecognition()`
- Initializes the `SpeechRecognitionEngine (recognizer)`.
- Sets the input to the default audio device (e.g., the microphone) using `SetInputToDefaultAudioDevice()`.
- Loads a dictation grammar with `LoadGrammar(new DictationGrammar())`, which is used for general speech-to-text recognition.
- Subscribes to the `SpeechRecognized` event, which gets triggered when the recognizer successfully identifies speech. It uses the `Recognizer_SpeechRecognized` method to handle this event.

### Event Handler: `Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)`
- When speech is recognized, this event handler is triggered.
- It appends the recognized text (`e.Result.Text`) to a `richTextBox1` control, displaying the speech as text on the form.

### Button Click Handlers:
1. Button1_Click (Start Recognition):
- Starts continuous speech recognition using `recognizer.RecognizeAsync(RecognizeMode.Multiple)`. This allows it to recognize multiple phrases continuously without stopping after one recognition.
- Changes the color of `label3` to a green color to indicate that recognition is active (`Color.FromArgb(31, 212, 175)`).
2. Button2_Click (Stop Recognition):
- Stops the continuous speech recognition using `recognizer.RecognizeAsyncStop()`.
- Changes the color of `label3` to a red color (`Color.FromArgb(255, 105, 123)`) to indicate that recognition is no longer active.
