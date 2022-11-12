using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Common.Response
{
    public interface IGenericResponse<T>
    {
        public T Result { get; } // if success return Result prop

        public bool IsSuccessful { get; }

        public List<string> Errors { get; } //if operation is fail then fill the list collection
    }
}
