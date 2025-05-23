using RentCar.Domain.Users;

namespace RentCar.Domain.Abstractions;

public sealed class User : Entity<UserId>
{
    private User()
    {
        
    }
    public User(UserId id, Nombre nombre, Apellido apellido, Email email): base(id) 
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
        var user = new User(UserId.New(), nombre, apellido, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id!));
        return user;
    }
}