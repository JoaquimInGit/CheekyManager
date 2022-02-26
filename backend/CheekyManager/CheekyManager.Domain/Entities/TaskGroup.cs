using CheekyManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekyManager.Domain.Entities
{
    public class TaskGroup : Entity
    {
        private string _title;
        private string _description;
        private bool _color;
       // private long _userId;
        public string Title 
        {
            get => _title;
            set
            {
                _title = value;
                Update();
            }
                
        }
        public string Description 
        {
            get => _description;
            set 
            {
                _description = value;
                Update();
            }
        }
        public bool Color
        {   
            get => _color;
            set
            {
                _color = value;
                Update();
            }
        }

      /*  public long UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                Update();
            }
        }*/

        public virtual User users { get; set; }
        public virtual ICollection<UnitTask> Tasks { get; set;}

    }
}
