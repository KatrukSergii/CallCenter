using System.Collections.Generic;
using CallCenter.Client.Core;
using CallCenter.Client.Storage;

public interface ICallCenter
{
    int ID { get; set; }
    string Name { get; set; }
    IEnumerable<ICampagne> Campaigns { get; }

    IEnumerable<IOperator> Operators { get; }
}