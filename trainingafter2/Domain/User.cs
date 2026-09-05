namespace trainingafter2.Domain
{
    public class User
    {
        private string id;
        private string name;
        private bool isActive;

        public User() { }
        public User(string id, string name)
        {
            this.id = id;
            this.name = name;
            this.isActive = true;
        }
        public bool IsActive()
        {
            return isActive;
        }

    }
}
