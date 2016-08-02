using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson56
{
    class Program
    {
        static void Main(string[] args)
        {
            Sport.InitBoysSport("box","swim","shoot","bjj","karate","kanoe");
            Sport.InitGirlsSport("gymnastic", "swim", "shoot", "judo", "run", "jump");
            Scout.ListOfScout =new List<Scout>{
                (new Boy() {Name="Patric", Age= 11})
                            .AddSport(Sport.MaleSport[1],23,"good boy")
                            .AddSport("karate",35,"middle level"),
                (new Girl() {Name="Juliya", Age= 10})
                            .AddSport(Sport.FemaleSport[0],50,"very good")
                            .AddSport(Sport.FemaleSport[4],18,"good level"),
                (new Boy() {Name="JayZ", Age= 8})
                            .AddSport(Sport.MaleSport[4],23,"fine")
                            .AddSport(Sport.MaleSport[5],35,"middle level")
                            .AddSport(Sport.MaleSport[0], 42,"so good"),
                (new Girl() {Name="Veronica", Age= 14})
                            .AddSport(Sport.FemaleSport[1],48,"good girl.")
                            .AddSport(Sport.FemaleSport[0],35,"middle level")
                            .AddSport(Sport.FemaleSport[5], 19,"not bad but do so more")
                            .AddSport(Sport.FemaleSport[2], 47,"so good, but you do more ")
            };
            foreach (var item in Scout.ListOfScout)
            {
                item.Experience();
            }
            Menu.Show();
        }
    }
}
