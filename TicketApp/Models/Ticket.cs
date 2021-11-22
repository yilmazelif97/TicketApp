﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
     
    //enumu database kaydedemezsin sadece integer olarak kayedebilirsin o  yüzden enuma integer değerler ata
    //propertiye değer atarken bu yüzden integer değerler ataman gerekiyor 
    public enum StatusofTask
    {
        Open =1,
        Closed=2,
        Assigned=3,
        Review=4,
        Complete=5
    }

    public enum LevelofDificulty 
    { 

        VeryEasy =1,
        Easy=2,
        Medium=3,
        Hard=4,
        VeryHard=5


    }

    public enum Priortiy
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public class Ticket
    {

        public string Ticketno { get; private set; }
        public StatusofTask status { get; private set; } 
        public Priortiy Priortiy { get; private set; }
        public LevelofDificulty LevelofDificulty { get; private set; }
        public string Subject { get; private set; }
        public string Description { get; private set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime AssignedDate { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }



        public Ticket(string description, string subject)
        {

            Ticketno = Guid.NewGuid().ToString();

            status = StatusofTask.Open; //assigned default task status when it created

            OpenDate = DateTime.Now;

            if (subject.Length>50)
            {
                throw new Exception("You can not write subjet more than 50 character");
            }

            Subject = subject;

            if (description.Length >500)
            {
                throw new Exception("You can not write description more than 500 character");
            }

            Description = description;
        }



    }
}
