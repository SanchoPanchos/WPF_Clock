using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace WPF_HW1.Model
{
    public class TimeClock
    {
        public Guid _guid;
        public int _offset;
        public string _name;
        public User _user;
        public Guid _userID;

        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

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

        
        public Guid UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }

        public int Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
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
        public TimeClock() { }
        public TimeClock(int offset, string name, User user)
        {
            _guid = Guid.NewGuid();
            _offset = offset;
            _name = name;
            _user = user;
            _userID = user.Guid;
        }


        public class TimeClockConfiguration : EntityTypeConfiguration<TimeClock>
        {

            public TimeClockConfiguration()
            {
                ToTable("TimeClock");

                HasKey(s => s.Guid);

                Property(p => p.Offset)
                    .HasColumnName("Offset")
                    .IsRequired();

                Property(p => p.Name)
                    .HasColumnName("Name")
                    .IsRequired();

                HasRequired(s => s.User)
                    .WithMany(u => u.TimeClocks)
                    .HasForeignKey(u => u.UserID);
            }
        }

    }

}

