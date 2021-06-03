using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camera_App.DataContracts
{
    public interface IPeopleClient
    {
        [Post("people")]
        Task AddPersonAsync([Body] Person p);
    }
}
