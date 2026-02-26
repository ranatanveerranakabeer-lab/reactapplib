using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Model
{
    public class ResponseModel//SAMe wohi hy bs ya simple hy//class user ki property bnaty hy
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Exception ErrorResponse { get; set; }
        public IEnumerable<object> Data { get; set; }//yaha gad bd thi ya sirf object accept kraha hy hm chaye object ho   //ai samjh nhii  dakho //object pss horaha hy    to response.data bh object ki demnad kraha hy na ka list ki
    }
}
