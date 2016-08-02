using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson56
{
    abstract class Scout
    {
        //static
        public static List<Scout> ListOfScout { get;  set; }
        
        //this
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Sport> ListOfSport { get; protected set; }
        protected int _numberOfSports;
        protected int _allScoreOfSports;
        protected int _avarageScoreOfSports;
        public int NumSports { get { return _numberOfSports; } }
        public int AllScore { get { return _allScoreOfSports; } }
        public int AvarScore { get { return _avarageScoreOfSports; } }
        

        
        public Scout()
        {
            this.ListOfSport = new List<Sport>();
        }
        public void Experience()
        {
            if (this.ListOfSport != null && this.ListOfSport.Count != 0)
            {
                foreach (var item in this.ListOfSport)
                {
                    _allScoreOfSports += item.Score;
                }
                _numberOfSports = this.ListOfSport.Count;
                _avarageScoreOfSports = _allScoreOfSports / _numberOfSports;
            }
            else
            {
                _allScoreOfSports = 0;
                _numberOfSports = -1;
                _avarageScoreOfSports = 0;

            }
        }
        public Scout AddSport(string nameSport, int scoreOfSport, string msgAward)
        {
            this.ListOfSport.Add(new Sport {
                Name = nameSport,
                Score = scoreOfSport,
                MsgAward = msgAward
            });
            return this;
        }
        public void DeleteSport(int idOfSport)
        {
            this.ListOfSport.RemoveAt(idOfSport);
        }
    }
}
