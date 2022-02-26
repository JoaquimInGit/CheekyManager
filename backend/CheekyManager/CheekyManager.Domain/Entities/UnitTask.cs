using CheekyManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekyManager.Domain.Entities
{
    public class UnitTask : Entity
    {
        private string _title;
        private string _description;
        private bool _completed;
        //private long _taskGroupId;
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
        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                Update();
            }
        }
       /* public long TaskGroupId
        {
            get => _taskGroupId;
            set
            {
                _taskGroupId = value;
                Update();
            }
        }*/
        public virtual TaskGroup TaskGroup { get; set; } 
    }
}
