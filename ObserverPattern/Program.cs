using System;
using System.Collections.Generic;

IPublisher publisher = new Publisher();

IObserver observer1 = new ObserverEnglish();
IObserver observer2 = new ObserverFrench();

publisher.RegisterObserver(observer1);
publisher.RegisterObserver(observer2);

publisher.UpdateName("Alice");
publisher.UpdateName("John");
publisher.UnregisterObserver(observer1);
publisher.UpdateName("Jane");
Console.ReadLine();

public interface IObserver
{
    void UpdateName(string name);
    void DisplayGreeting();
}

public class ObserverEnglish : IObserver
{
    private string _name;

    public void UpdateName(string name)
    {
        _name = name;
    }

    public void DisplayGreeting()
    {
        Console.WriteLine($"Hello, {_name}! Welcome in English.");
    }
}

public class ObserverFrench : IObserver
{
    private string _name;

    public void UpdateName(string name)
    {
        _name = name;
    }

    public void DisplayGreeting()
    {
        Console.WriteLine($"Bonjour, {_name} ! Bienvenue en français.");
    }
}

public interface IPublisher
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void UpdateName(string name);
    void NotifyObservers();
}

public class Publisher : IPublisher
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _name;
    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void UpdateName(string name)
    {
        _name = name;
        NotifyObservers();
    }

    public void NotifyObservers()
    {
        _observers.ForEach(_observer => { 
            _observer.UpdateName(_name);
            _observer.DisplayGreeting();
        });
    }
}


       
