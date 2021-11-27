using System;
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
        Completed=5,
        Readyforassignment=6
         
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

        public string Id { get;  set; } = Guid.NewGuid().ToString();
        public StatusofTask status { get;  set; } 
        public Priortiy Priortiy { get;  set; }
        public LevelofDificulty LevelofDificulty { get;  set; }
        public string Subject { get;  set; }
        public string Description { get;  set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime AssignedDate { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string EmployeeID { get; set; }
        public Employee Employee { get; set; }





        public void SetPriority(Priortiy p)
        {
            Priortiy = p;
        }

        public void SetDifficulty(LevelofDificulty l)
        {
            LevelofDificulty = l;
        }

        public void setClosedDate()
        {

        }


        



    }
}
