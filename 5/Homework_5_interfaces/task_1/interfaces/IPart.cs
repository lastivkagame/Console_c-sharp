namespace task_1.interfaces
{
    interface IPart
    {
        object GetName();

        bool IsIReady();

        void AddToMyPercent(double percent);
    }
}
