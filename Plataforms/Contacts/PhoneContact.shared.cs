using System;

namespace Plataforms
{
    public readonly struct PhoneContact : IEquatable<PhoneContact>
    {
        public string Name { get; }
        public string Number { get; }
        public string Email { get; }
     
        internal PhoneContact(string name, string number, string email)
        {
            Name = name;
            Number = number;
            Email = email;
        }

        public static bool operator ==(PhoneContact left, PhoneContact right) =>
            Equals(left, right);

        public static bool operator !=(PhoneContact left, PhoneContact right) =>
            !Equals(left, right);

        public override bool Equals(object obj) =>
        (obj is PhoneContact contact) && Equals(contact);

        public bool Equals(PhoneContact other) =>
            (Name, Number, Email) == (other.Name, other.Number, other.Email);

        public override int GetHashCode() =>
            (Name, Number, Email).GetHashCode();
    }
}
