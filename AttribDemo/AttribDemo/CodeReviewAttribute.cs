using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple=true)]
    class CodeReviewAttribute : Attribute
    {
        private string _reviewerName;
        private string _reviewDate;
        private bool _isApproved;

        public CodeReviewAttribute(string name, string date, bool isApproved)
        {
            _reviewerName = name;
            _reviewDate = date;
            _isApproved = isApproved;
        }

        public string ReviewerName
        {
            get
            {
                return _reviewerName;
            }
        }

        public string ReviewDate
        {
            get
            {
                return _reviewDate;
            }
        }

        public bool IsApproved
        {
            get
            {
                return _isApproved; 
            }
        }
    }
}
