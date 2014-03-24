using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipiesWebFormApp.Models
{
    public class ViewModelBase
    {
        public virtual ViewModelBase ConvertFromEntity()
        {
            return null;

        }
    }
}
