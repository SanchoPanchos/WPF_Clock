using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WPF_HW1.Model
{
    
    public class User 
    {
       
        public Guid _guid;
        public string _name;
        public string _surname;
        public string _username;
        public string _email;
        public string _password;
        private List<TimeClock> _timeClocks;

        [Key]
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public List<TimeClock> TimeClocks
        {
            get
            {
                return _timeClocks;
            }
            set
            {
                _timeClocks = value;
            }
        }

        public User(string name, string surname, string username, string email, string password, List<TimeClock> timeClocks)
        {
            _guid = Guid.NewGuid();
            _name = name;
            _surname = surname;
            _username = username;
            _email = email;
            _password = password;
            _timeClocks = timeClocks;
        }

        public User()
        {

        }

        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("User");
                HasKey(s => s.Guid);

                Property(p => p.Name)
                    .HasColumnName("Name")
                    .IsRequired();
                Property(p => p.Surname)
                    .HasColumnName("Surname")
                    .IsRequired();
                Property(p => p.Username)
                    .HasColumnName("Username")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsRequired();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();

                HasMany(s => s.TimeClocks)
                    .WithRequired(w => w.User)
                    .HasForeignKey(w => w.UserID)
                    .WillCascadeOnDelete(true);

            }
        }


    }
}
