namespace AgOpenGPS.Simulation
{
    public interface IConfiguration
    {
        public T Get<T>(string key);
    }

}
