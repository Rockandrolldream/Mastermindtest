using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermindtest
{
    public class Ball
    { 
        public BallColour colour { get; set; }

        public Ball(BallColour colour)
        {
            this.colour = colour;
        }

    }
}
