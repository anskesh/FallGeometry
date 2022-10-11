namespace Game.Observer
{
    public interface Observer
    {
        public Observable Spawner { get; set; }
        public void Notify();
        public void Notify(int score);
        public void Add(Observable observable);
        public void Remove(Observable observable);
    }
}