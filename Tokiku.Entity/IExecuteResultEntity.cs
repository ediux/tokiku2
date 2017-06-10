using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tokiku.Entity
{
    public interface IExecuteResultEntity : INotifyPropertyChanged, IDisposable
    {
        IEnumerable<string> Errors { get; set; }
        bool HasError { get; set; }
    }

    public interface IExecuteResultEntity<T> : IExecuteResultEntity where T : class
    {
        T Result { get; set; }
    }
}