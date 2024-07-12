using System.ComponentModel.DataAnnotations;
using sweetmanager.API.Clients.Domain.Model.Commands;

namespace sweetmanager.API.Clients.Domain.Model.Aggregates
{

    public partial class Client
    {
        public int Id { get; private set; }
        
        [MaxLength(50)]
        public string Name { get; private set; }
        
        [MaxLength(50)]
        public string LastName { get; private set; }
        
        [Range(0, 120)]
        public int Age { get; private set; }
        
        [MaxLength(50)]
        public string Genre { get; private set; }
        
        [MaxLength(50)]
        public string Phone { get; private set; }
        
        [MaxLength(50)]
        public string Email { get; private set; }
        
        [MaxLength(50)]
        public string State { get; private set; }

        public Client()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Age = 0;
            this.Genre = string.Empty;
            this.Phone = "";
            this.Email = string.Empty;
            this.State = string.Empty;
        }

        public Client(int id, string name, string lastName, int age, string genre, string phone, string email,
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