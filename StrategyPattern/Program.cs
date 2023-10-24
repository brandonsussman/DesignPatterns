using System;

public class Program
{
    public interface IExercise
    {
        void Exercise();
    }

    public class Run : IExercise
    {
        public void Exercise()
        {
            Console.WriteLine("Running");
        }
    }

    public class Walk : IExercise
    {
        public void Exercise()
        {
            Console.WriteLine("Walking");
        }
    }

    public class Workout
    {
        private IExercise _exercise;

        public IExercise Exercise
        {
            set => _exercise = value;
        }

        public void DoExercise()
        {
            _exercise?.Exercise();
        }
    }

    private static void Main(string[] args)
    {
        
        Workout workout = new Workout { Exercise = new Run()};

        workout.DoExercise();
        workout.Exercise= new Walk();

        workout.DoExercise();
     
    }
}
