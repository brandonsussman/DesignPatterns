using System.Runtime.InteropServices;

Light light = new Light();
ICommand onCommand = new SwitchLightOnCommand(light);
ICommand offCommand = new SwitchLightOffCommand(light);  
Remote remote= new Remote();
remote.command = onCommand;
onCommand.execute();
remote.command=offCommand;
offCommand.execute();
public class Light
{
public void switchOn()
    {
        Console.WriteLine("Light On");
    }
public void switchOff() 
    { 
        Console.WriteLine("Light Off");
    }   

}

public interface ICommand 
{
    public void execute();
}

public class SwitchLightOnCommand : ICommand
{
    Light _light;
    public SwitchLightOnCommand(Light light)
    {
        _light= light;
    }

    public void execute() 
    {
        _light.switchOn();
    }
}

public class SwitchLightOffCommand : ICommand
{
    Light _light;
    public SwitchLightOffCommand(Light light)
    {
        _light = light;
    }

    public void execute()
    {
        _light.switchOff();
    }
}

//invoker 
public class Remote
{
    public ICommand command { get; set; }

    public void pressButton()
    {
        command.execute();
    }

}
