using System;

public class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private TimeSpan _time;
    private string _dateFormat;
    private string _timeFormat;
    private Address _address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address, string dateFormat, string timeFormat)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _dateFormat = dateFormat;
        _timeFormat = timeFormat;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_address}";
    }

    public string GetFullDetails()
    {
        string eventType;
        if (this.GetType() == typeof(Lecture))
        {
            eventType = "Lecture";
        }
        else if (this.GetType() == typeof(Reception))
        {
            eventType = "Reception";
        }
        else if (this.GetType() == typeof(OutdoorGathering))
        {
            eventType = "Outdoor Gathering";
        }
        else
        {
            eventType = "Generic Event";
        }
        
        return $"Type: {eventType}\n" + GetStandardDetails();
    }

    public string GetShortDescription()
    {
        string eventType;
        if (this.GetType() == typeof(Lecture))
        {
            eventType = "Lecture";
        }
        else if (this.GetType() == typeof(Reception))
        {
            eventType = "Reception";
        }
        else if (this.GetType() == typeof(OutdoorGathering))
        {
            eventType = "Outdoor Gathering";
        }
        else
        {
            eventType = "Generic Event";
        }

        return $"Type: {eventType}\nTitle: {_title}\nDate: {_date.ToShortDateString()}";
    }
}
