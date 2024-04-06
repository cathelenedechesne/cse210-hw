public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address, "MM/dd/yyyy", "hh:mm tt")
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public new string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {_speakerName}\nCapacity: {_capacity}";
    }
}
