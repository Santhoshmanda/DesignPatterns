using System;

namespace FacadePattern
{
    // Subsystem Component: Projector
    public class Projector
    {
        public void On() => Console.WriteLine("Projector turned ON.");
        public void Off() => Console.WriteLine("Projector turned OFF.");
        public void SetInput(string input) => Console.WriteLine($"Projector input set to {input}.");
    }

    // Subsystem Component: Sound System
    public class SoundSystem
    {
        public void On() => Console.WriteLine("Sound System turned ON.");
        public void Off() => Console.WriteLine("Sound System turned OFF.");
        public void SetVolume(int level) => Console.WriteLine($"Sound System volume set to {level}.");
    }

    // Subsystem Component: DVD Player
    public class DVDPlayer
    {
        public void On() => Console.WriteLine("DVD Player turned ON.");
        public void Off() => Console.WriteLine("DVD Player turned OFF.");
        public void PlayMovie(string movie) => Console.WriteLine($"Playing movie: {movie}.");
    }

    // Subsystem Component: Lights
    public class Lights
    {
        public void Dim() => Console.WriteLine("Lights dimmed for movie.");
        public void On() => Console.WriteLine("Lights turned ON.");
    }

    // Facade: Home Theater Facade
    public class HomeTheaterFacade
    {
        private readonly Projector _projector;
        private readonly SoundSystem _soundSystem;
        private readonly DVDPlayer _dvdPlayer;
        private readonly Lights _lights;

        public HomeTheaterFacade(Projector projector, SoundSystem soundSystem, DVDPlayer dvdPlayer, Lights lights)
        {
            _projector = projector;
            _soundSystem = soundSystem;
            _dvdPlayer = dvdPlayer;
            _lights = lights;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("\n--- Setting up the Home Theater System ---");
            _lights.Dim();
            _projector.On();
            _projector.SetInput("DVD");
            _soundSystem.On();
            _soundSystem.SetVolume(20);
            _dvdPlayer.On();
            _dvdPlayer.PlayMovie(movie);
            Console.WriteLine("--- Enjoy the movie! ---\n");
        }

        public void EndMovie()
        {
            Console.WriteLine("\n--- Shutting down the Home Theater System ---");
            _dvdPlayer.Off();
            _soundSystem.Off();
            _projector.Off();
            _lights.On();
            Console.WriteLine("--- Goodbye! ---\n");
        }
    }

    // Client Code
    class Program
    {
        static void Main(string[] args)
        {
            // Subsystem Components
            var projector = new Projector();
            var soundSystem = new SoundSystem();
            var dvdPlayer = new DVDPlayer();
            var lights = new Lights();

            // Facade
            var homeTheater = new HomeTheaterFacade(projector, soundSystem, dvdPlayer, lights);

            // Client uses the facade to watch and end the movie
            homeTheater.WatchMovie("Inception");
            homeTheater.EndMovie();
        }
    }
}
