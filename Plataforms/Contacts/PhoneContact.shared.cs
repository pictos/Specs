﻿using System;
using System.Collections.Generic;

namespace Plataforms
{
    public readonly struct PhoneContact : IEquatable<PhoneContact>
    {
        public string Name { get; }
        public IEnumerable<string> Numbers { get; }
        public IEnumerable<string> Emails { get; }

        internal PhoneContact(string name, IEnumerable<string> numbers, IEnumerable<string> emails)
        {
            Name = name;
            Numbers = numbers;
            Emails = emails;
        }

        public static bool operator ==(PhoneContact left, PhoneContact right) =>
            Equals(left, right);

        public static bool operator !=(PhoneContact left, PhoneContact right) =>
            !Equals(left, right);

        public override bool Equals(object obj) =>
        (obj is PhoneContact contact) && Equals(contact);

        public bool Equals(PhoneContact other) =>
            (Name, Numbers, Emails) == (other.Name, other.Numbers, other.Emails);

        public override int GetHashCode() =>
            (Name, Numbers, Emails).GetHashCode();
    }
}