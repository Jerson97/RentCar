using RentCar.Domain.User;

namespace RentCar.Domain.Abstractions;

public sealed class User : Entity
{
    public User(Guid id, Nombre nombre, Apellido apellido, Email email): base(id) 
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
    }

    public Nombre? Nombre { get; private set; }
    public Apellido? Apellido { get; set; }
    public Email? Email { get; set; }

    public static User Create(Nombre nombre, Apellido apellido, Email email)
    {
        var user = new User(Guid.NewGuid(), nombre, apellido, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        return user;
    }
}