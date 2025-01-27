﻿using System.ComponentModel;

namespace LearnHubApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public UserTypes UserType { get; set; }

        [DefaultValue(true)]
        public bool isactive { get; set; }

        public int studentid { get; set; }

        public enum UserTypes
        {
            Admin = 100,
            User = 101,
        }
    }
}
