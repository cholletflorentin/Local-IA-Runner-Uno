using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LocalIARunner.Uno;

public sealed class ChatMessage : INotifyPropertyChanged
{
    private string _content = "";
    private string _answerA = "";
    private string _answerB = "";

    public string Role { get; set; } = "user";
    public bool IsComparison { get; set; }
    public string ModelA { get; set; } = "";
    public string ModelB { get; set; } = "";
    public string Content
    {
        get => _content;
        set
        {
            if (_content == value) return;
            _content = value;
            OnPropertyChanged();
        }
    }

    public string AnswerA
    {
        get => _answerA;
        set
        {
            if (_answerA == value) return;
            _answerA = value;
            OnPropertyChanged();
        }
    }

    public string AnswerB
    {
        get => _answerB;
        set
        {
            if (_answerB == value) return;
            _answerB = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public sealed class Conversation : INotifyPropertyChanged
{
    private string _title = "Nouvelle discussion";

    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Title
    {
        get => _title;
        set
        {
            if (_title == value) return;
            _title = value;
            OnPropertyChanged();
        }
    }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<ChatMessage> History { get; set; } = [];

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

public sealed class AppState
{
    public string Endpoint { get; set; } = "http://127.0.0.1:8080";
    public string LocalModelPath { get; set; } = "";
    public string LocalModelName { get; set; } = "";
    public List<Conversation> Conversations { get; set; } = [];
}

