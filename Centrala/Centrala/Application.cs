using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    class Application
    {
        Application() {} //jest prywatny bo konstruktor musi być ale korzystać nie bedziemy
        double appcome; //czas przyjscia
        double apppatience; //czas jaki moze przebywac zgloszenie w kolejce
        double appduration; //czas realizacji zgloszenia
        int streamnumber; // numer strumienia z którego pochodzi to połączenie 

        public Application(double cappcome, double capppatience, double cappduration, int cstreamnumber)
        {
            appcome = cappcome;
            apppatience = capppatience;
            appduration = cappduration;
            streamnumber = cstreamnumber;
        }
        public double Returnappcome() { return appcome; }
        public double Returnapppatience() { return apppatience; }  
        public double Returnappduration() { return appduration; }
        public int Returnstreamnumber() { return streamnumber; }
    }
}
