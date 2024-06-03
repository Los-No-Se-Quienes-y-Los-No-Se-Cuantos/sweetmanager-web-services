using sweetmanager.API.Clients.Domain.Model.Commands;

namespace sweetmanager.API.Clients.Domain.Model.Aggregates
{

    public partial class Client
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public int Age { get; private set; }
        public string? Genre { get; private set; }
        public int Phone { get; private set; }
        public string? Email { get; private set; }
        public string? State { get; private set; }

        public Client()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Age = 0;
            this.Genre = string.Empty;
            this.Phone = 0;
            this.Email = string.Empty;
            this.State = string.Empty;
        }

        public Client(int id, string name, string lastName, int age, string genre, int phone, string email,
            string state)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Genre = genre;
            this.Phone = phone;
            this.Email = email;
            this.State = state;
        }

        public Client(CreateClientCommand command)
        {
            this.Id = command.Id;
            this.Name = command.Name;
            this.LastName = command.LastName;
            this.Age = command.Age;
            this.Genre = command.Genre;
            this.Phone = command.Phone;
            this.Email = command.Email;
            this.State = command.State;
        }
    }
}