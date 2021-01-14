namespace task_1
{
    class Hothouse
    {
        private double temperature;
        private double maxTemperature;
        private double minTemperature;

        public delegate void HotHouseDeleg(Hothouse house);

        public event HotHouseDeleg toohot;
        public event HotHouseDeleg toocold;
        public event HotHouseDeleg well;

        private static int count;

        static Hothouse()
        {
            count = 1;
        }

        public double Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;

                if (temperature <= minTemperature || temperature >= maxTemperature)
                {
                    do
                    {
                        if (temperature <= minTemperature)
                        {
                            count = 0;
                            toocold?.Invoke(this);
                        }
                        else if (temperature >= maxTemperature)
                        {
                            count = 0;
                            toohot?.Invoke(this);
                        }

                    } while (temperature < minTemperature || temperature > maxTemperature);
                }
                else
                {
                    if (count > 0)
                    {
                        well?.Invoke(this);
                    }
                }

                count = 1;
            }
        }

        public Hothouse(double minTemperature = 0, double maxTemperature = 0, double temperature = 0)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            Temperature = temperature;
        }
    }
}
